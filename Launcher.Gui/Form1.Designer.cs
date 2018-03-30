namespace Launcher.Gui
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label chatLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label labelUser;
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.checkBoxAutoLogin = new System.Windows.Forms.CheckBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user = new Launcher.Gui.DataSets.User();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonRemoveUser = new System.Windows.Forms.Button();
            this.buttonSaveUsers = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.checkBoxChatLog = new System.Windows.Forms.CheckBox();
            this.textBoxChatLogFilePath = new System.Windows.Forms.TextBox();
            passwordLabel = new System.Windows.Forms.Label();
            chatLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            labelUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(10, 67);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(56, 13);
            passwordLabel.TabIndex = 9;
            passwordLabel.Text = "Password:";
            // 
            // chatLabel
            // 
            chatLabel.AutoSize = true;
            chatLabel.Location = new System.Drawing.Point(10, 93);
            chatLabel.Name = "chatLabel";
            chatLabel.Size = new System.Drawing.Size(32, 13);
            chatLabel.TabIndex = 11;
            chatLabel.Text = "Chat:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(10, 41);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 12;
            nameLabel.Text = "Name:";
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new System.Drawing.Point(10, 14);
            labelUser.Name = "labelUser";
            labelUser.Size = new System.Drawing.Size(32, 13);
            labelUser.TabIndex = 14;
            labelUser.Text = "User:";
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Location = new System.Drawing.Point(93, 140);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(75, 23);
            this.buttonLaunch.TabIndex = 5;
            this.buttonLaunch.Text = "Launch";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // checkBoxAutoLogin
            // 
            this.checkBoxAutoLogin.AutoSize = true;
            this.checkBoxAutoLogin.Checked = true;
            this.checkBoxAutoLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoLogin.Location = new System.Drawing.Point(10, 144);
            this.checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            this.checkBoxAutoLogin.Size = new System.Drawing.Size(77, 17);
            this.checkBoxAutoLogin.TabIndex = 4;
            this.checkBoxAutoLogin.Text = "Auto Login";
            this.checkBoxAutoLogin.UseVisualStyleBackColor = true;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "User";
            this.userBindingSource.DataSource = this.user;
            // 
            // user
            // 
            this.user.DataSetName = "User";
            this.user.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Password", true));
            this.passwordTextBox.Location = new System.Drawing.Point(72, 64);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 2;
            // 
            // chatTextBox
            // 
            this.chatTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Chat", true));
            this.chatTextBox.Location = new System.Drawing.Point(72, 90);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(100, 20);
            this.chatTextBox.TabIndex = 3;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(178, 11);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(22, 23);
            this.buttonAddUser.TabIndex = 6;
            this.buttonAddUser.Text = "+";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonRemoveUser
            // 
            this.buttonRemoveUser.Location = new System.Drawing.Point(206, 11);
            this.buttonRemoveUser.Name = "buttonRemoveUser";
            this.buttonRemoveUser.Size = new System.Drawing.Size(22, 23);
            this.buttonRemoveUser.TabIndex = 7;
            this.buttonRemoveUser.Text = "-";
            this.buttonRemoveUser.UseVisualStyleBackColor = true;
            this.buttonRemoveUser.Click += new System.EventHandler(this.buttonRemoveUser_Click);
            // 
            // buttonSaveUsers
            // 
            this.buttonSaveUsers.Location = new System.Drawing.Point(178, 35);
            this.buttonSaveUsers.Name = "buttonSaveUsers";
            this.buttonSaveUsers.Size = new System.Drawing.Size(50, 23);
            this.buttonSaveUsers.TabIndex = 8;
            this.buttonSaveUsers.Text = "Save";
            this.buttonSaveUsers.UseVisualStyleBackColor = true;
            this.buttonSaveUsers.Click += new System.EventHandler(this.buttonSaveUsers_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.DataSource = this.userBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.ValueMember = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Name", true));
            this.textBoxName.Location = new System.Drawing.Point(72, 38);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 15;
            // 
            // checkBoxChatLog
            // 
            this.checkBoxChatLog.AutoSize = true;
            this.checkBoxChatLog.Checked = true;
            this.checkBoxChatLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChatLog.Location = new System.Drawing.Point(10, 116);
            this.checkBoxChatLog.Name = "checkBoxChatLog";
            this.checkBoxChatLog.Size = new System.Drawing.Size(69, 17);
            this.checkBoxChatLog.TabIndex = 16;
            this.checkBoxChatLog.Text = "Chat Log";
            this.checkBoxChatLog.UseVisualStyleBackColor = true;
            // 
            // textBoxChatLogFilePath
            // 
            this.textBoxChatLogFilePath.Location = new System.Drawing.Point(85, 114);
            this.textBoxChatLogFilePath.Name = "textBoxChatLogFilePath";
            this.textBoxChatLogFilePath.Size = new System.Drawing.Size(260, 20);
            this.textBoxChatLogFilePath.TabIndex = 17;
            this.textBoxChatLogFilePath.Text = "C:\\Games\\Jumpgate\\chatlog.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 171);
            this.Controls.Add(this.textBoxChatLogFilePath);
            this.Controls.Add(this.checkBoxChatLog);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(labelUser);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonSaveUsers);
            this.Controls.Add(this.buttonRemoveUser);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(nameLabel);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(chatLabel);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.checkBoxAutoLogin);
            this.Controls.Add(this.buttonLaunch);
            this.Name = "Form1";
            this.Text = "Jumpgate Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.CheckBox checkBoxAutoLogin;
        private DataSets.User user;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonRemoveUser;
        private System.Windows.Forms.Button buttonSaveUsers;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.CheckBox checkBoxChatLog;
        private System.Windows.Forms.TextBox textBoxChatLogFilePath;
    }
}

