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
                UseShellExecute = false
            };
            var process = System.Diagnostics.Process.Start(processStartInfo);

            if (!checkBoxAutoLogin.Checked) { return; }

            System.Threading.Thread.Sleep(7000);

            // Click connect
            User32.SendMessage(process.MainWindowHandle, 0x200, 0, 0x014B015F);
            User32.SendMessage(process.MainWindowHandle, 0x201, 0, 0);
            User32.SendMessage(process.MainWindowHandle, 0x202, 0, 0);

            // Click login
            User32.SendMessage(process.MainWindowHandle, 0x200, 0, 0x011A01B6);
            User32.SendMessage(process.MainWindowHandle, 0x201, 0, 0);
            User32.SendMessage(process.MainWindowHandle, 0x202, 0, 0);
        }
    }
}