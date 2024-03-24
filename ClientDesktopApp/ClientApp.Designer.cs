namespace ClientDesktopApp
{
    partial class ClientApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_ip = new TextBox();
            textBox_serverTime = new TextBox();
            textBox_message = new TextBox();
            ipAddress = new Label();
            Message = new Label();
            serverTime = new Label();
            btnSend = new Button();
            checkStorage = new Button();
            SuspendLayout();
            // 
            // textBox_ip
            // 
            textBox_ip.Location = new Point(337, 114);
            textBox_ip.Name = "textBox_ip";
            textBox_ip.Size = new Size(252, 23);
            textBox_ip.TabIndex = 0;
            // 
            // textBox_serverTime
            // 
            textBox_serverTime.Location = new Point(337, 205);
            textBox_serverTime.Name = "textBox_serverTime";
            textBox_serverTime.Size = new Size(252, 23);
            textBox_serverTime.TabIndex = 1;
            textBox_serverTime.TextChanged += textBox_serverTime_TextChanged;
            // 
            // textBox_message
            // 
            textBox_message.Location = new Point(337, 163);
            textBox_message.Name = "textBox_message";
            textBox_message.Size = new Size(252, 23);
            textBox_message.TabIndex = 2;
            // 
            // ipAddress
            // 
            ipAddress.AutoSize = true;
            ipAddress.Location = new Point(252, 122);
            ipAddress.Name = "ipAddress";
            ipAddress.Size = new Size(62, 15);
            ipAddress.TabIndex = 3;
            ipAddress.Text = "Ip Address";
            // 
            // Message
            // 
            Message.AutoSize = true;
            Message.Location = new Point(252, 166);
            Message.Name = "Message";
            Message.Size = new Size(53, 15);
            Message.TabIndex = 4;
            Message.Text = "Message";
            // 
            // serverTime
            // 
            serverTime.AutoSize = true;
            serverTime.Location = new Point(252, 208);
            serverTime.Name = "serverTime";
            serverTime.Size = new Size(68, 15);
            serverTime.TabIndex = 5;
            serverTime.Text = "Server Time";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(252, 284);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // checkStorage
            // 
            checkStorage.Location = new Point(337, 284);
            checkStorage.Name = "checkStorage";
            checkStorage.Size = new Size(100, 23);
            checkStorage.TabIndex = 7;
            checkStorage.Text = "Check Storage";
            checkStorage.UseVisualStyleBackColor = true;
            checkStorage.Click += checkStorage_Click;
            // 
            // ClientApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkStorage);
            Controls.Add(btnSend);
            Controls.Add(serverTime);
            Controls.Add(Message);
            Controls.Add(ipAddress);
            Controls.Add(textBox_message);
            Controls.Add(textBox_serverTime);
            Controls.Add(textBox_ip);
            Name = "ClientApp";
            Text = "ClientApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_ip;
        private TextBox textBox_serverTime;
        private TextBox textBox_message;
        private Label ipAddress;
        private Label Message;
        private Label serverTime;
        private Button btnSend;
        private Button checkStorage;
    }
}