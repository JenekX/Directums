using Directums.Client.Classes;
using System;
using System.Linq;

namespace Directums.Client.Forms.Client
{
    public partial class MessagesForm : DirectumsForm
    {
        private bool FillMessages()
        {
            var messages = Config.Client.GetMessages();
            if (messages == null)
            {
                return false;
            }

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
                string userName = message.UserName;
                if (message.NotReadCount > 0)
                {
                    userName += " <b>(" + message.NotReadCount.ToString() + ")</b>";
                }

                text += string.Format(row, (i++ % 2 == 0 ? "gray" : "cyan"), userName, message.Created.ToString(), messageText);
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

        private bool FillGroups()
        {
            tvGroups.Nodes.Clear();

            var groups = Config.Client.GetGroupsContent();
            if (groups == null)
            {
                return false;
            }

            foreach (var group in groups)
            {
                var groupNode = tvGroups.Nodes.Add(group.Name);

                foreach (var user in group.Users)
                {
                    var userNode = groupNode.Nodes.Add(user.Value);
                    userNode.Tag = user.Key;
                }
            }

            return true;
        }

        private bool Initialize()
        {
            return FillMessages() && FillGroups();
        }

        public MessagesForm(DirectumsConfig config) : base(config)
        {
            InitializeComponent();
        }

        public static void Execute(DirectumsForm ownerForm)
        {
            var form = new MessagesForm(ownerForm.Config);
            if (form.Initialize())
            {
                form.ShowDialog(ownerForm);
            }
        }

        private void tvGroups_DoubleClick(object sender, System.EventArgs e)
        {
            if (tvGroups.SelectedNode.Level != 1)
            {
                return;
            }

            int idUserWith = (int)tvGroups.SelectedNode.Tag;

            MessageForm.Execute(this, idUserWith);

            FillMessages();
        }
    }
}