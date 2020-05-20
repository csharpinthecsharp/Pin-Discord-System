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

namespace PreachP_V
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string CreatePassword(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            while (0 < length--)
            {
                stringBuilder.Append("1234567890"[random.Next("1234567890".Length)]);
            }
            return stringBuilder.ToString();
        }


        private void logintext_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.logintext.TextAlign = HorizontalAlignment.Center;
            this.pinrandom.Text = this.CreatePassword(4);
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(new StringContent("Preach PIN"), "username");
            multipartFormDataContent.Add(new StringContent("https://cdn.discordapp.com/attachments/711725421691011173/711726318911225918/Sans_titre-1.png"), "avatar_url");
            multipartFormDataContent.Add(new StringContent(string.Concat(new string[]
            {
                "-------------------------\n**Computer :** ",
                Environment.UserName,
                "\n**PIN : **",
                this.pinrandom.Text
            })), "content");
            try
            {
                HttpResponseMessage result = httpClient.PostAsync(Settings.Webhook, multipartFormDataContent).Result;
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = this.pinrandom.Text == this.logintext.Text;
            if (flag)
            {
                //If code is good


            }
            else
            {
                //If code is false
            }
        }
    }
    }
    

