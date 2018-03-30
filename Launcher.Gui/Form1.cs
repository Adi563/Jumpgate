﻿using System;
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
            
            // Capture screen and check if OK button appeared
            var bitmap = new System.Drawing.Bitmap(382-320, 343-320);
            var graphics = System.Drawing.Graphics.FromImage(bitmap);
            var color = System.Drawing.Color.Black;
            while ( !(color.R == 22 && color.G == 54 && color.B == 22))
            {
                graphics.CopyFromScreen(320, 320, 0, 0, new System.Drawing.Size(bitmap.Width, bitmap.Height), System.Drawing.CopyPixelOperation.SourceCopy);
                color = bitmap.GetPixel(10, 10);
                System.Threading.Thread.Sleep(500);
            }

            // Click connect
            User32.SendMessage(process.MainWindowHandle, 0x200, 0, 0x014B015F);
            User32.SendMessage(process.MainWindowHandle, 0x201, 0, 0);
            User32.SendMessage(process.MainWindowHandle, 0x202, 0, 0);

            // Click login
            User32.SendMessage(process.MainWindowHandle, 0x200, 0, 0x011A01B6);
            User32.SendMessage(process.MainWindowHandle, 0x201, 0, 0);
            User32.SendMessage(process.MainWindowHandle, 0x202, 0, 0);

            if (!checkBoxChatLog.Checked) { return; }

            System.Threading.Thread.Sleep(5000);
            
            var threadChatLogging = new System.Threading.Thread(StartChatLogging);
            threadChatLogging.Start();
        }

        private void StartChatLogging()
        {
            new ChatLogger.ChatImageProcessor().ScreenCaptureTest(textBoxChatLogFilePath.Text);
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