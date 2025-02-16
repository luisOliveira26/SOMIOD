using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AppB_ControlLight
{
    public partial class AppB : Form
    {
        public AppB()
        {
            InitializeComponent();
            createAppSwitchIfNotAlreadyExist("switch");
        }

        private async void buttonOn_Click(object sender, EventArgs e)
        {
            sendButtonClick("On");
        }
        private void buttonOff_Click(object sender, EventArgs e)
        {
            sendButtonClick("Off");

        }

        private async void sendButtonClick(string estado)
        {
            string endpoint = $"http://localhost:52431/api/somiod/Lighthing/light_bulb";
            using (var client = new HttpClient())
            {
                string content =
                "<Record>" +
                "  <name>recStat</name>" +
                $"  <content>{estado}</content>" +
                "</Record>";

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, endpoint);
                request.Content = new StringContent(content, Encoding.UTF8, "application/xml");
                HttpResponseMessage response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Pedimos desculpa, mas ocorreu um erro");
                }
            }
        }


        private async Task createAppSwitchIfNotAlreadyExist(string nameApplication)
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

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pedimos desculpa, mas não conseguimos inicializar a aplicação switch no Somiod");
                    }
                }


            }


        }

        private void AppB_Load(object sender, EventArgs e)
        {
        }

        
    }
}
