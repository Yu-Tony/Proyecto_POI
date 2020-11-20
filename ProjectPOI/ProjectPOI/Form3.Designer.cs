namespace ProjectPOI
{
    partial class Form3
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChatNameOut = new System.Windows.Forms.TextBox();
            this.ChatMembersAdd = new System.Windows.Forms.ListBox();
            this.AddMembersBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Seleccionar Integrantes para Agregar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre del Grupo:";
            // 
            // ChatNameOut
            // 
            this.ChatNameOut.Location = new System.Drawing.Point(62, 50);
            this.ChatNameOut.Name = "ChatNameOut";
            this.ChatNameOut.ReadOnly = true;
            this.ChatNameOut.Size = new System.Drawing.Size(164, 20);
            this.ChatNameOut.TabIndex = 12;
            // 
            // ChatMembersAdd
            // 
            this.ChatMembersAdd.FormattingEnabled = true;
            this.ChatMembersAdd.Location = new System.Drawing.Point(54, 114);
            this.ChatMembersAdd.Name = "ChatMembersAdd";
            this.ChatMembersAdd.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ChatMembersAdd.Size = new System.Drawing.Size(168, 238);
            this.ChatMembersAdd.TabIndex = 11;
            // 
            // AddMembersBtn
            // 
            this.AddMembersBtn.Location = new System.Drawing.Point(38, 378);
            this.AddMembersBtn.Name = "AddMembersBtn";
            this.AddMembersBtn.Size = new System.Drawing.Size(200, 47);
            this.AddMembersBtn.TabIndex = 10;
            this.AddMembersBtn.Text = "Añadir Integrantes";
            this.AddMembersBtn.UseVisualStyleBackColor = true;
            this.AddMembersBtn.Click += new System.EventHandler(this.AddMembersBtn_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChatNameOut);
            this.Controls.Add(this.ChatMembersAdd);
            this.Controls.Add(this.AddMembersBtn);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ChatNameOut;
        private System.Windows.Forms.ListBox ChatMembersAdd;
        private System.Windows.Forms.Button AddMembersBtn;
    }
}