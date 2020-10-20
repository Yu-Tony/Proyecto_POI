namespace ProjectPOI
{
    partial class Form1
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
            this.WriteMessage = new System.Windows.Forms.TextBox();
            this.Send_Button = new System.Windows.Forms.Button();
            this.File_Button = new System.Windows.Forms.Button();
            this.Emoji_Button = new System.Windows.Forms.Button();
            this.User_LogIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Connect_LogIn = new System.Windows.Forms.Button();
            this.Password_Login = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Sing_In_Chng = new System.Windows.Forms.Button();
            this.Log_In_Chng = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SignIn_Button = new System.Windows.Forms.Button();
            this.Mail_LogIn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WriteMessage
            // 
            this.WriteMessage.Location = new System.Drawing.Point(180, 522);
            this.WriteMessage.Name = "WriteMessage";
            this.WriteMessage.Size = new System.Drawing.Size(420, 20);
            this.WriteMessage.TabIndex = 1;
            // 
            // Send_Button
            // 
            this.Send_Button.Location = new System.Drawing.Point(606, 523);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(63, 19);
            this.Send_Button.TabIndex = 2;
            this.Send_Button.Text = "Send";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // File_Button
            // 
            this.File_Button.Location = new System.Drawing.Point(675, 523);
            this.File_Button.Name = "File_Button";
            this.File_Button.Size = new System.Drawing.Size(63, 19);
            this.File_Button.TabIndex = 3;
            this.File_Button.Text = "File";
            this.File_Button.UseVisualStyleBackColor = true;
            // 
            // Emoji_Button
            // 
            this.Emoji_Button.Location = new System.Drawing.Point(744, 522);
            this.Emoji_Button.Name = "Emoji_Button";
            this.Emoji_Button.Size = new System.Drawing.Size(63, 19);
            this.Emoji_Button.TabIndex = 4;
            this.Emoji_Button.Text = "Emoji";
            this.Emoji_Button.UseVisualStyleBackColor = true;
            // 
            // User_LogIn
            // 
            this.User_LogIn.Location = new System.Drawing.Point(84, 170);
            this.User_LogIn.Name = "User_LogIn";
            this.User_LogIn.Size = new System.Drawing.Size(287, 20);
            this.User_LogIn.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(81, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuario";
            // 
            // Connect_LogIn
            // 
            this.Connect_LogIn.BackColor = System.Drawing.Color.GhostWhite;
            this.Connect_LogIn.Location = new System.Drawing.Point(207, 298);
            this.Connect_LogIn.Name = "Connect_LogIn";
            this.Connect_LogIn.Size = new System.Drawing.Size(75, 23);
            this.Connect_LogIn.TabIndex = 7;
            this.Connect_LogIn.Text = "Conectarse";
            this.Connect_LogIn.UseVisualStyleBackColor = false;
            this.Connect_LogIn.Click += new System.EventHandler(this.Connect_LogIn_Click);
            // 
            // Password_Login
            // 
            this.Password_Login.Location = new System.Drawing.Point(84, 237);
            this.Password_Login.Name = "Password_Login";
            this.Password_Login.PasswordChar = '*';
            this.Password_Login.Size = new System.Drawing.Size(287, 20);
            this.Password_Login.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.GhostWhite;
            this.label2.Location = new System.Drawing.Point(80, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Constraseña";
            // 
            // Sing_In_Chng
            // 
            this.Sing_In_Chng.BackColor = System.Drawing.Color.GhostWhite;
            this.Sing_In_Chng.Location = new System.Drawing.Point(11, 12);
            this.Sing_In_Chng.Name = "Sing_In_Chng";
            this.Sing_In_Chng.Size = new System.Drawing.Size(75, 23);
            this.Sing_In_Chng.TabIndex = 12;
            this.Sing_In_Chng.Text = "Registrarse";
            this.Sing_In_Chng.UseVisualStyleBackColor = false;
            this.Sing_In_Chng.Click += new System.EventHandler(this.Sing_In_Chng_Click);
            // 
            // Log_In_Chng
            // 
            this.Log_In_Chng.BackColor = System.Drawing.Color.GhostWhite;
            this.Log_In_Chng.Location = new System.Drawing.Point(11, 12);
            this.Log_In_Chng.Name = "Log_In_Chng";
            this.Log_In_Chng.Size = new System.Drawing.Size(75, 23);
            this.Log_In_Chng.TabIndex = 13;
            this.Log_In_Chng.Text = "Conectarse";
            this.Log_In_Chng.UseVisualStyleBackColor = false;
            this.Log_In_Chng.Visible = false;
            this.Log_In_Chng.Click += new System.EventHandler(this.Log_In_Chng_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.SignIn_Button);
            this.panel1.Controls.Add(this.Mail_LogIn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Log_In_Chng);
            this.panel1.Controls.Add(this.Sing_In_Chng);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 561);
            this.panel1.TabIndex = 10;
            // 
            // SignIn_Button
            // 
            this.SignIn_Button.Location = new System.Drawing.Point(206, 355);
            this.SignIn_Button.Name = "SignIn_Button";
            this.SignIn_Button.Size = new System.Drawing.Size(75, 23);
            this.SignIn_Button.TabIndex = 16;
            this.SignIn_Button.Text = "Registrarse";
            this.SignIn_Button.UseVisualStyleBackColor = true;
            this.SignIn_Button.Click += new System.EventHandler(this.SignIn_Button_Click_1);
            // 
            // Mail_LogIn
            // 
            this.Mail_LogIn.Location = new System.Drawing.Point(83, 310);
            this.Mail_LogIn.Name = "Mail_LogIn";
            this.Mail_LogIn.Size = new System.Drawing.Size(287, 20);
            this.Mail_LogIn.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.GhostWhite;
            this.label3.Location = new System.Drawing.Point(80, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Correo";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(502, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 561);
            this.panel2.TabIndex = 14;
            // 
            // listBoxMessages
            // 
            this.listBoxMessages.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.Location = new System.Drawing.Point(179, 40);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(627, 481);
            this.listBoxMessages.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.listBoxMessages);
            this.Controls.Add(this.Password_Login);
            this.Controls.Add(this.Connect_LogIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.User_LogIn);
            this.Controls.Add(this.Emoji_Button);
            this.Controls.Add(this.File_Button);
            this.Controls.Add(this.Send_Button);
            this.Controls.Add(this.WriteMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox WriteMessage;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.Button File_Button;
        private System.Windows.Forms.Button Emoji_Button;
        private System.Windows.Forms.TextBox User_LogIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Connect_LogIn;
        private System.Windows.Forms.TextBox Password_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Sing_In_Chng;
        private System.Windows.Forms.Button Log_In_Chng;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox Mail_LogIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SignIn_Button;
        private System.Windows.Forms.ListBox listBoxMessages;
    }
}

