using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using static System.Net.WebRequestMethods;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Reflection.Emit;
using System.Xml;
using System.IO;

namespace App_A_Light
{
    public partial class AppA : Form
    {
        private MqttClient m_cClient;
        string topic = null;
        string XmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\ConfigurationsAppA.xml");


        public AppA()
        {
            InitializeComponent();
        }

        private void AppA_Load(object sender, EventArgs e)
        {
            StartMqttClient();
            prepareApplication();

        }

        private void StartMqttClient()
        {

            // m_cClient = new MqttClient(brokerAddress);
            m_cClient = new MqttClient("127.0.0.1");


            try
            {
                // Conectar ao broker MQTT
                m_cClient.Connect(Guid.NewGuid().ToString());
                if (!m_cClient.IsConnected)
                {
                    Console.WriteLine("MQTT nao conectado!");
                    return;
                }
                topic = $"api/somiod/Lighthing/light_bulb";
                m_cClient.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

                m_cClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar MQTT: " + ex.Message);
            }
        }




        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string receivedMessage = Encoding.UTF8.GetString(e.Message);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(receivedMessage);

            saveContentAtXmlFile(doc);

            Invoke(new Action(() =>
            {
                controlLight(doc);
            }));


            Console.WriteLine("Received = " + receivedMessage + " on topic " + e.Topic);
        }

        public void saveContentAtXmlFile(XmlDocument docNot)
        {
            try
            {
                XmlDocument configDoc = new XmlDocument();
                configDoc.Load(XmlFilePath);

                // Lê intervalo de tempo e nome do arquivo de saída
                DateTime startTime = DateTime.Parse(configDoc.SelectSingleNode("//Start").InnerText);
                DateTime endTime = DateTime.Parse(configDoc.SelectSingleNode("//End").InnerText);
                string outputFile = configDoc.SelectSingleNode("//OutputFile").InnerText;
                outputFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\", outputFile);
                Console.WriteLine($"Intervalo: {startTime} - {endTime}");
                Console.WriteLine($"Arquivo de saída: {outputFile}");

                XmlDocument outputDoc = new XmlDocument();

                // Verifica se o arquivo de saída já existe
                if (System.IO.File.Exists(outputFile))
                {
                    outputDoc.Load(outputFile);
                }
                else
                {
                    return;
                }

                XmlElement rootElement = outputDoc.DocumentElement;

                // Filtra notificações pelo intervalo de tempo usando creation_datetime
                XmlNode notificationNode = docNot.SelectSingleNode("//NotificationTrigger");
                if (notificationNode != null)
                {
                    XmlNode recordNode = notificationNode.SelectSingleNode("Record/creation_datetime");
                    if (recordNode != null)
                    {
                        DateTime creationTime = DateTime.Parse(recordNode.InnerText);
                        if (creationTime >= startTime && creationTime <= endTime)
                        {
                            XmlNode importedNode = outputDoc.ImportNode(notificationNode, true);
                            rootElement.AppendChild(importedNode);
                        }

                    }

                }

                // Salva no arquivo especificado
                outputDoc.Save(outputFile);
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"Erro XML: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro de formato de data/hora: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        private void controlLight(XmlDocument doc)
        {

            XmlNode notTnode = doc.SelectSingleNode("//NotificationTrigger");

            string eventCode = (notTnode["Event"].InnerText);

            XmlNode recordNode = notTnode.SelectSingleNode("//Record");



            if (recordNode["content"].InnerText.Equals("On"))
            {
                pictureBoxLightOff.Visible = false;
                pictureBoxLightOn.Visible = true;
            }
            if (recordNode["content"].InnerText.Equals("Off"))
            {
                pictureBoxLightOff.Visible = true;
                pictureBoxLightOn.Visible = false;
            }
        }


        private void prepareApplication()
        {
            //createAppContNotiIfNotAlreadyExist("Lighthing", "light_bulb", "sub1", "mqtt://192.168.1.2:1883");
            createAppContNotiIfNotAlreadyExist("Lighthing", "light_bulb", "sub1", "mqtt://127.0.0.1");

        }



        private async Task createAppContNotiIfNotAlreadyExist(string nameApplication, string nameContainer, string nameNotification, string mqttUrl)
        {



            string endpoint = $"http://localhost:52431/api/somiod/{nameApplication}";
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestGet = new HttpRequestMessage(HttpMethod.Get, endpoint);
                HttpResponseMessage responseGet = await client.SendAsync(requestGet);
                if (!responseGet.IsSuccessStatusCode)
                {
                    endpoint = $"http://localhost:52431/api/somiod";
                    string content =
                           $"<Application>" +
                           $"    <name>{nameApplication}</name>" +
                           $"</Application>";
                    HttpRequestMessage requestPost = new HttpRequestMessage(HttpMethod.Post, endpoint);
                    requestPost.Content = new StringContent(content, Encoding.UTF8, "application/xml");
                    HttpResponseMessage response = await client.SendAsync(requestPost);

                    if (!responseGet.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pedimos desculpa, mas não conseguimos inicializar a aplicação no Somiod");
                    }
                }

                createIfContainerNotAlreadyExist(nameApplication, nameContainer, nameNotification, mqttUrl);

            }


        }
        private async Task createIfContainerNotAlreadyExist(string nameApplication, string nameContainer, string nameNotification, string mqttUrl)
        {
            string endpoint = $"http://localhost:52431/api/somiod/{nameApplication}/{nameContainer}";
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestGet = new HttpRequestMessage(HttpMethod.Get, endpoint);
                HttpResponseMessage responseGet = await client.SendAsync(requestGet);
                if (!responseGet.IsSuccessStatusCode)
                {
                    endpoint = $"http://localhost:52431/api/somiod/{nameApplication}";
                    string content =
                           $"<Container>" +
                           $"    <name>{nameContainer}</name>" +
                           $"</Container>";
                    HttpRequestMessage requestPost = new HttpRequestMessage(HttpMethod.Post, endpoint);
                    requestPost.Content = new StringContent(content, Encoding.UTF8, "application/xml");
                    HttpResponseMessage response = await client.SendAsync(requestPost);

                    if (!responseGet.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pedimos desculpa, mas não conseguimos inicializar o Container no Somiod");
                    }
                }

                createIfNotificationNotAlreadyExist(nameApplication, nameContainer, nameNotification, mqttUrl);
            }
        }

        private async Task createIfNotificationNotAlreadyExist(string nameApplication, string nameContainer, string nameNotification, string mqttUrl)
        {
            string endpoint = $"http://localhost:52431/api/somiod/{nameApplication}/{nameContainer}/Notification/{nameNotification}";
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestGet = new HttpRequestMessage(HttpMethod.Get, endpoint);
                HttpResponseMessage responseGet = await client.SendAsync(requestGet);
                if (!responseGet.IsSuccessStatusCode)
                {
                    endpoint = $"http://localhost:52431/api/somiod/{nameApplication}/{nameContainer}";
                    string content =
                           $"<Notification>" +
                           $"    <name>{nameNotification}</name>" +
                           $"    <enabled>true</enabled>" +
                           $"    <endpoint>{mqttUrl}</endpoint>" +
                           $"    <event>1</event>" +
                           $"</Notification>";
                    HttpRequestMessage requestPost = new HttpRequestMessage(HttpMethod.Post, endpoint);
                    requestPost.Content = new StringContent(content, Encoding.UTF8, "application/xml");
                    HttpResponseMessage response = await client.SendAsync(requestPost);


                    if (!responseGet.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pedimos desculpa, mas não conseguimos inicializar a Notificação no Somiod");
                    }
                }


            }
        }
    }
}
