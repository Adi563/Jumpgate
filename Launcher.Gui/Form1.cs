using System;
using System.Windows.Forms;

namespace Launcher.Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBoxUser.DataSource = new User[]
            {
                new User { UserName = "Adi563", Password = "hanswurscht" },
                new User { UserName = "@Broker01", Password = "NqKuKbE1e" },
            };
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            var user = (User)comboBoxUser.SelectedItem;
            using (var stream = new System.IO.FileStream(@"C:\Games\Jumpgate\user.bin", System.IO.FileMode.Create))
            {
                Launcher.WriteUserFile(stream, user.UserName, user.Password);
            }

            using (var stream = new System.IO.FileStream($@"C:\Games\Jumpgate\{user.UserName}.chn", System.IO.FileMode.Create))
            {
                Launcher.WriteUserChatFile(stream, textBoxChatRoom.Text);
            }

            var processStartInfo = new System.Diagnostics.ProcessStartInfo
            {
                CreateNoWindow = false,
                FileName = @"C:\Games\Jumpgate\Jumpgate.exe",
                WorkingDirectory = @"C:\Games\Jumpgate\",
            };
            System.Diagnostics.Process.Start(processStartInfo);
        }
    }
}