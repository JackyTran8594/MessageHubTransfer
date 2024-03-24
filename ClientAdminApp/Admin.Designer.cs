namespace ClientAdminApp
{
    partial class Admin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxMessage = new TextBox();
            textBoxTimeServer = new TextBox();
            MessageServer = new Label();
            TimeServer = new Label();
            SuspendLayout();
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(368, 105);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(354, 23);
            textBoxMessage.TabIndex = 0;
            // 
            // textBoxTimeServer
            // 
            textBoxTimeServer.Location = new Point(368, 154);
            textBoxTimeServer.Name = "textBoxTimeServer";
            textBoxTimeServer.Size = new Size(354, 23);
            textBoxTimeServer.TabIndex = 1;
            // 
            // MessageServer
            // 
            MessageServer.AutoSize = true;
            MessageServer.Location = new Point(266, 108);
            MessageServer.Name = "MessageServer";
            MessageServer.Size = new Size(85, 15);
            MessageServer.TabIndex = 2;
            MessageServer.Text = "MessageServer";
            // 
            // TimeServer
            // 
            TimeServer.AutoSize = true;
            TimeServer.Location = new Point(283, 162);
            TimeServer.Name = "TimeServer";
            TimeServer.Size = new Size(68, 15);
            TimeServer.TabIndex = 3;
            TimeServer.Text = "Time Server";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TimeServer);
            Controls.Add(MessageServer);
            Controls.Add(textBoxTimeServer);
            Controls.Add(textBoxMessage);
            Name = "Admin";
            Text = "AdminApp";
            Load += Admin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxMessage;
        private TextBox textBoxTimeServer;
        private Label MessageServer;
        private Label TimeServer;
    }
}
