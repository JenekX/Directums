using System;
using System.Linq;
using Directums.Client.Classes;
using Directums.Client.DirectumsService;
using System.Collections.Generic;

namespace Directums.Client.Forms.Client
{
    public partial class MessageForm : DirectumsForm
    {
        private int idUserWith;

        private bool FillMessages()
        {
            var messages = Config.Client.GetUserMessages(idUserWith);
            if (messages == null)
            {
                return false;
            }

            var user = Config.Client.GetUserInfo(idUserWith);
            if (user == null)
            {
                return false;
            }

            var users = new Dictionary<int, User>();
            users.Add(Config.User.Id, Config.User);
            users.Add(user.Id, user);

            int i = 0;
            string text = "";
            foreach (var message in messages)
            {
                string row = @"
                    <div class=""{0}"">
                        <table class=""message-table"">
                            <tr>
                                <td><b>{1}</b></td>
                                <td align=""right"" class=""td-created"">{2}</td>
                            </tr>
                            <tr>
                                <td colspan=""2"">{3}</td>
                            </tr>
                        </table>
                    </div>";

                string messageText = string.Join("", message.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None).Select(x => "<div>" + x + "</div>"));

                text += string.Format(row, (i++ % 2 == 0 ? "gray" : "cyan"), users[message.IdUserFrom].GetLoginWithName(), message.Created.ToString(), messageText);
            }

            htmlPanel.Text = @"
                <html>
                    <head>
                        <style type=""text/css"">
                            body
                            {
                                margin: 0px;
                            }

                            .message-table
                            {
                                width: 100%;
                            }

                            .td-created
                            {
                                width: 160px;
                            }

                            table, tr, td
                            {
                                border-width: 0px;
                            }

                            .gray
                            {   
                                background-color: #E8FFE0;
                                border: 1px solid black;
                                corner-radius: 3px;
                                margin-bottom: 3px;
                            }
                            
                            .cyan
                            {
                                background-color: #B5D2FF;
                                border: 1px solid black;
                                corner-radius: 3px;
                                margin-bottom: 3px;
                            }
                        </style>
                    </head>
                    <body>
                        " + text + @"
                    </body>
                </html>";

            return true;
        }

        private bool Initialize(int idUserWith)
        {
            this.idUserWith = idUserWith;

            return FillMessages();
        }

        public MessageForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public static void Execute(DirectumsForm ownerForm, int idUserWith)
        {
            var form = new MessageForm(ownerForm.Config);
            if (form.Initialize(idUserWith))
            {
                form.ShowDialog(ownerForm);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = tbMessage.Text.Trim();

            if (Config.Client.AddMessage(idUserWith, message))
            {
                FillMessages();
            }
            else
            {
                DialogHelper.Error(this, "Во время отправки сообщения произошла ошибка.");
            }
        }
    }
}