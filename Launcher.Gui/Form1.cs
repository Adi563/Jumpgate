using System;
using System.Windows.Forms;

namespace Launcher.Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var userDataSet = (DataSets.User)userBindingSource.DataSource;
            if(System.IO.File.Exists("Users.xml"))
            { userDataSet.ReadXml("Users.xml"); }
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            var dataRowView = (System.Data.DataRowView)userBindingSource.Current;
            var userRow = (DataSets.User.UserRow)dataRowView.Row;

            using (var stream = new System.IO.FileStream(@"C:\Games\Jumpgate\user.bin", System.IO.FileMode.Create))
            {
                Logic.WriteUserFile(stream, userRow.Name, userRow.Password);
            }

            using (var stream = new System.IO.FileStream($@"C:\Games\Jumpgate\{userRow.Name}.chn", System.IO.FileMode.Create))
            {
                Logic.WriteUserChatFile(stream, chatTextBox.Text);
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

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            userBindingSource.AddNew();
        }

        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            if(userBindingSource.Count > 0)
            { userBindingSource.RemoveCurrent(); }
        }

        private void buttonSaveUsers_Click(object sender, EventArgs e)
        {
            userBindingSource.EndEdit();
            var userDataSet = (DataSets.User)userBindingSource.DataSource;

            userDataSet.WriteXml("Users.xml");
        }
    }
}