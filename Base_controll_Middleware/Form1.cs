using Base_controll_Middleware.Properties;
using System;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace Base_controll_Middleware
{
    public partial class Form1 : Form
    {
        private HttpListener httpListener;
        private MqttClient m_cClient;
        string topic = null;
        string XmlFilePath = Path.Combine(
                                            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
                                            "ConfigurationsAppControll.xml"
                                          );



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prepareForm();
            StartHttpListener();
            StartMqttClient();
        }



        private void StartHttpListener()
        {
            Console.WriteLine("################## #######################################");
            httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:5000/test/api/notification/");
            httpListener.Start();
            httpListener.BeginGetContext(OnRequestReceived, null);
        }

        private void OnRequestReceived(IAsyncResult result)
        {
            if (httpListener == null || !httpListener.IsListening)
                return;

            var context = httpListener.EndGetContext(result);
            httpListener.BeginGetContext(OnRequestReceived, null);

            if (context.Request.HttpMethod == "POST")
            {
                if (checkBoxHttp.Checked)
                {
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                    {
                        var xmlContent = reader.ReadToEnd();
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(xmlContent);

                        saveContentAtXmlFile(xmlDocument);

                        Invoke(new Action(() =>
                        {
                            PopulateData(xmlDocument);
                        }));
                    }

                    context.Response.StatusCode = 200;
                    context.Response.Close();
                }
                else
                {
                    context.Response.StatusCode = 403;
                    context.Response.Close();
                }

            }
            else
            {
                context.Response.StatusCode = 405;
                context.Response.Close();
            }
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

                m_cClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            }
            catch (Exception ex)
            {
                label1.Text = "Erro ao conectar MQTT: " + ex.Message;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (httpListener != null && httpListener.IsListening)
            {
                httpListener.Stop();
                httpListener.Close();
            }

            if (m_cClient != null && m_cClient.IsConnected)
            {
                m_cClient.Disconnect();
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
                PopulateData(doc);
            }));


            Console.WriteLine("Received = " + receivedMessage + " on topic " + e.Topic);
        }


        private void PopulateData(XmlDocument doc)
        {

            XmlNode notTnode = doc.SelectSingleNode("//NotificationTrigger");

            string eventCode = (notTnode["Event"].InnerText);

            XmlNode recordNode = notTnode.SelectSingleNode("//Record");

            string[] arrayRec = new string[6];

            arrayRec[0] = eventCode;
            arrayRec[1] = recordNode.Attributes["id"].Value;
            arrayRec[2] = recordNode["name"].InnerText;
            arrayRec[3] = recordNode["content"].InnerText;
            arrayRec[4] = recordNode["creation_datetime"].InnerText;
            arrayRec[5] = recordNode["parent"].InnerText;

            string[] columnA = new string[6];


            columnA[0] = "evento";
            columnA[1] = "id";
            columnA[2] = "name";
            columnA[3] = "content";
            columnA[4] = "creation_datetime";
            columnA[5] = "parent";
            dataGridView1.Rows.Insert(0, new object[] { "-------------", "--------------------------------" });
            for (int i = 5; i >= 0; i--)
            {
                string cellAValue = string.Join("\n", columnA[i]);
                string cellBValue = string.Join("\n", arrayRec[i]);

                dataGridView1.Rows.Insert(0, new object[] { cellAValue, cellBValue });
            }
        }



        private void prepareForm()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.RowHeadersVisible = false; // Ocultar coluna extra de cabeçalho

            DataGridViewTextBoxColumn columnA = new DataGridViewTextBoxColumn
            {
                Name = "Container Info",
                HeaderText = "Container Info",
                Width = (int)(dataGridView1.Width * 0.3),
                ReadOnly = true
            };

            DataGridViewTextBoxColumn columnB = new DataGridViewTextBoxColumn
            {
                Name = "Value",
                HeaderText = "Value",
                Width = (int)(dataGridView1.Width * 0.7),
                DefaultCellStyle = { WrapMode = DataGridViewTriState.False }
            };

            // Adicionar as colunas ao DataGridView
            dataGridView1.Columns.Add(columnA);
            dataGridView1.Columns.Add(columnB);

            checkedListBox1.Items.Clear(); // Limpar os itens existentes, se necessário

            // Adicionar os itens à CheckedListBox
            checkedListBox1.Items.Add("Application");
            checkedListBox1.Items.Add("Container");
            checkedListBox1.Items.Add("Notification");
            checkedListBox1.Items.Add("Record");

            // Evento para marcar automaticamente a opção selecionada
            checkedListBox1.SelectedIndexChanged += (sender, e) =>
            {
                // Garantir que apenas uma opção seja selecionada
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i == checkedListBox1.SelectedIndex)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            };

            comboBoxMethod.Items.Clear();
            comboBoxMethod.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxXml.Multiline = true;  // Habilitar múltiplas linhas
            textBoxXml.WordWrap = true;   // Quebra de palavras automática
            textBoxXml.ScrollBars = ScrollBars.Vertical;

            // Adicionar as opções ao dropdown
            comboBoxMethod.Items.Add("Locate");
            comboBoxMethod.Items.Add("Get");
            comboBoxMethod.Items.Add("Create");
            comboBoxMethod.Items.Add("Edit");
            comboBoxMethod.Items.Add("Delete");
            comboBoxMethod.Text = "Locate";


            textBoxAppName.Visible = false;
            labelAppName.Visible = false;

            textBoxContainerName.Visible = false;
            labelContainerName.Visible = false;

            textBoxNotificationName.Visible = false;
            textBoxRecord.Visible = false;
            labelNotificationName.Visible = false;
            // Configurar para selecionar apenas uma opção
            checkedListBox1.ItemCheck += (sender, e) =>
            {
                // Verifica se a opção está sendo selecionada
                if (e.NewValue == CheckState.Checked)
                {
                    // Desmarca todas as outras opções
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (i != e.Index)
                        {
                            checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                }
            };
        }

        private void updateForm(string method, string resource)
        {
            if (method == "Edit" || method == "Create")
                textBoxXml.ReadOnly = false;
            else { textBoxXml.ReadOnly = true; }

            if (method == "Get" || method == "Edit" || method == "Delete")
            {
                labelXml.Text = "XML Receive";
               

               

                if (resource == "Application")
                {
                    textBoxAppName.Visible = true;
                    labelAppName.Visible = true;

                    textBoxContainerName.Visible = false;
                    labelContainerName.Visible = false;

                    textBoxNotificationName.Visible = false;
                    textBoxRecord.Visible = false;
                    labelNotificationName.Visible = false;
                }
                else if (resource == "Container")
                {
                    textBoxAppName.Visible = true;
                    labelAppName.Visible = true;

                    textBoxContainerName.Visible = true;
                    labelContainerName.Visible = true;

                    textBoxNotificationName.Visible = false;
                    textBoxRecord.Visible = false;
                    labelNotificationName.Visible = false;
                }
                else if (resource == "Notification")
                {
                    textBoxAppName.Visible = true;
                    labelAppName.Visible = true;

                    textBoxContainerName.Visible = true;
                    labelContainerName.Visible = true;

                    textBoxNotificationName.Visible = true;
                    textBoxRecord.Visible = false;
                    labelNotificationName.Visible = true;
                    labelNotificationName.Text = "Notification Name";
                }
                else if (resource == "Record")
                {
                    textBoxAppName.Visible = true;
                    labelAppName.Visible = true;

                    textBoxContainerName.Visible = true;
                    labelContainerName.Visible = true;

                    textBoxNotificationName.Visible = false;
                    textBoxRecord.Visible = true;
                    labelNotificationName.Visible = true;
                    labelNotificationName.Text = "Record Name";
                }
            }
            else if (method == "Create" || method == "Locate")
            {
                labelXml.Text = "XML Request";
                if (resource == "Application")
                {
                    textBoxAppName.Visible = false;
                    labelAppName.Visible = false;

                    textBoxContainerName.Visible = false;
                    labelContainerName.Visible = false;

                    textBoxNotificationName.Visible = false;
                    textBoxRecord.Visible = false;
                    labelNotificationName.Visible = false;
                }
                else if (resource == "Container")
                {
                    textBoxAppName.Visible = true;
                    labelAppName.Visible = true;

                    textBoxContainerName.Visible = false;
                    labelContainerName.Visible = false;

                    textBoxNotificationName.Visible = false;
                    textBoxRecord.Visible = false;
                    labelNotificationName.Visible = false;
                }
                else if (resource == "Notification")
                {
                    textBoxAppName.Visible = true;
                    labelAppName.Visible = true;

                    textBoxContainerName.Visible = true;
                    labelContainerName.Visible = true;

                    textBoxNotificationName.Visible = false;
                    textBoxRecord.Visible = false;
                    labelNotificationName.Visible = false;
                    labelNotificationName.Text = "Notification Name";
                }
                else if (resource == "Record")
                {
                    textBoxAppName.Visible = true;
                    labelAppName.Visible = true;

                    textBoxContainerName.Visible = true;
                    labelContainerName.Visible = true;

                    textBoxNotificationName.Visible = false;
                    textBoxRecord.Visible = false;
                    labelNotificationName.Visible = false;
                    labelNotificationName.Text = "Record Name";
                }
            }


        }




        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateForm(comboBoxMethod.Text, checkedListBox1.Text);
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateForm(comboBoxMethod.Text, checkedListBox1.Text);
        }

        private void buttonSubscrive_Click(object sender, EventArgs e)
        {
            if (topic != null)
            {
                m_cClient.Unsubscribe(new string[] { topic });

            }
            topic = $"api/somiod/{textBoxAppNameMqqt.Text}/{textBoxContainerNameMqtt.Text}";
            labelAtualChannel.Text = topic;
            m_cClient.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }


        private async void button1_Click(object sender, EventArgs e)//enviar pedido
        {

            try
            {


                string method = comboBoxMethod.Text;
                string baseUrl = "http://localhost:52431/api/somiod/";

                // Construir o endpoint com base nos TextBoxes visíveis
                string endpoint = baseUrl;

                if (textBoxAppName.Visible && !string.IsNullOrWhiteSpace(textBoxAppName.Text))
                    endpoint += $"{textBoxAppName.Text}/";
                if (textBoxContainerName.Visible && !string.IsNullOrWhiteSpace(textBoxContainerName.Text))
                    endpoint += $"{textBoxContainerName.Text}/";
                if (textBoxNotificationName.Visible && !string.IsNullOrWhiteSpace(textBoxNotificationName.Text))
                {

                    endpoint += $"Notification/{textBoxNotificationName.Text}";
                }

                else if (textBoxRecord.Visible && !string.IsNullOrWhiteSpace(textBoxRecord.Text))
                {
                    endpoint += $"Record/{textBoxRecord.Text}";
                }

                string responseContent;
                // Lógica de métodos
                if (method == "Create" || method == "Edit")
                {
                    // Preparar o conteúdo em XML para envio
                    string xmlContent = textBoxXml.Text;
                    if (string.IsNullOrWhiteSpace(xmlContent))
                    {
                        MessageBox.Show("Por favor, insira conteúdo XML no campo antes de continuar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Escolher o método correto e enviar
                    HttpMethod httpMethod = method == "Create" ? HttpMethod.Post : new HttpMethod("PATCH");
                    responseContent = await SendRequestAsync(endpoint, httpMethod, xmlContent);
                }
                else
                {
                    // Para Get, Locate e Delete, apenas exibe o resultado
                    HttpMethod httpMethod = method == "Get" || method == "Locate" ? HttpMethod.Get : HttpMethod.Delete;
                    string locate = null;
                    if (method == "Locate")
                        locate = checkedListBox1.Text.ToLower();

                    responseContent = await SendRequestAsync(endpoint, httpMethod, null, locate);
                }
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseContent);

                // Salvar o XML formatado como string
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    NewLineOnAttributes = true,
                    IndentChars = "\t"
                };

                using (var stringWriter = new System.IO.StringWriter())
                using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    xmlDoc.Save(xmlWriter);
                    string formattedXml = stringWriter.ToString();
                    textBoxXml.Text = formattedXml;
                }
            }
            catch (Exception ex)
            {

            }
        }



        private async Task<string> SendRequestAsync(string endpoint, HttpMethod method, string content, string locate = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(method, endpoint);

                    if (content != null)
                    {
                        request.Content = new StringContent(content, Encoding.UTF8, "application/xml");
                    }
                    if(locate != null)
                    request.Headers.Add("somiod-locate", locate);

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {

                        // Retornar o conteúdo da resposta se for um GET
                        if (method.ToString() != "Delete")
                        {
                            MessageBox.Show("Pedido realizado com sucesso");

                            return await response.Content.ReadAsStringAsync();
                        }
                        MessageBox.Show("Eliminado com sucesso");

                    }
                    else
                    {
                        MessageBox.Show($"Erro ao enviar o pedido: {response.StatusCode}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar o pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return string.Empty;
        }

        private async void buttonExamples_Click(object sender, EventArgs e)
        {
            //consoante o metodo preenche automaticamente
            //tanto a boxXml como as 3 boxs do app,cont, not/rec
            string method = comboBoxMethod.Text;
            string resource = checkedListBox1.Text;

            textBoxAppName.Text = "App1";

            textBoxContainerName.Text = "Container1";


            textBoxNotificationName.Text = "Notification1a";



            textBoxRecord.Text = "Record1";



            textBoxAppNameMqqt.Text = "App1";
            textBoxContainerNameMqtt.Text = "Container1";


            if (method == "Edit")
            {
                if (resource == "Application")
                {
                    string newName = $"app-{Guid.NewGuid()}";
                    textBoxXml.Text = $"<name> {newName} </name>";
                }
                else if (resource == "Container")
                {
                    string newName = $"container-{Guid.NewGuid()}";
                    textBoxXml.Text = $"<name> {newName} </name>";
                }
                else if (resource == "Notification")
                {
                    textBoxXml.Text = "<enabled > true </enabled>";
                }
            }
            else if (method == "Create")
            {
                if (resource == "Application")
                {
                    textBoxXml.Text =
                       $"<Application>" + Environment.NewLine +
                       $"    <name>app1</name>" + Environment.NewLine +
                       $"</Application>";
                }
                else if (resource == "Container")
                {
                    textBoxXml.Text =
                       "<Container>" + Environment.NewLine +
                       "    <name>container1</name>" + Environment.NewLine +
                       "</Container>";
                }
                else if (resource == "Notification")
                {
                    textBoxXml.Text =
                       "<Notification>" + Environment.NewLine +
                       "    <name>not1</name>" + Environment.NewLine +
                       "    <enabled>true</enabled>" + Environment.NewLine +
                       "    <endpoint>http://localhost:5000/test/api/notification</endpoint>" + Environment.NewLine +
                       "    <event>2</event>" + Environment.NewLine +
                       "</Notification>";
                }
                else if (resource == "Record")
                {
                    textBoxXml.Text =
                       "<Record>" + Environment.NewLine +
                       "    <name>rec1</name>" + Environment.NewLine +
                       "    <content>order arrived</content>" + Environment.NewLine +
                       "</Record>";
                }

            }



        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxAppName.Clear();
            textBoxContainerName.Clear();
            textBoxAppNameMqqt.Clear();
            textBoxNotificationName.Clear();
            textBoxRecord.Clear();
            textBoxContainerNameMqtt.Clear();
            textBoxXml.Clear();

        }

        public void saveContentAtXmlFile(XmlDocument docNot)
        {
            try
            {
                XmlDocument configDoc = new XmlDocument();
                configDoc.Load(XmlFilePath);

                // le intervalo de tempo e nome do arquivo de saida
                DateTime startTime = DateTime.Parse(configDoc.SelectSingleNode("//Start").InnerText);
                DateTime endTime = DateTime.Parse(configDoc.SelectSingleNode("//End").InnerText);
                string outputFile = configDoc.SelectSingleNode("//OutputFile").InnerText;
                outputFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\", outputFile);
                Console.WriteLine($"Intervalo: {startTime} - {endTime}");
                Console.WriteLine($"Arquivo de saída: {outputFile}");

                XmlDocument outputDoc = new XmlDocument();

                // verifica se o arquivo de saída ja existe
                if (System.IO.File.Exists(outputFile))
                {
                    outputDoc.Load(outputFile);
                }
                else
                {
                    return;
                }

                XmlElement rootElement = outputDoc.DocumentElement;

                // filtra notificaoees pelo intervalo de tempo ao usar creation_datetime
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





        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }





    }







}
