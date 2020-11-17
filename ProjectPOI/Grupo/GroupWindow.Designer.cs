namespace Grupo
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
            this.CrearGrupoBtn = new System.Windows.Forms.Button();
            this.ChatMembersIn = new System.Windows.Forms.ListBox();
            this.ChatNameIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CrearGrupoBtn
            // 
            this.CrearGrupoBtn.Location = new System.Drawing.Point(56, 384);
            this.CrearGrupoBtn.Name = "CrearGrupoBtn";
            this.CrearGrupoBtn.Size = new System.Drawing.Size(200, 47);
            this.CrearGrupoBtn.TabIndex = 0;
            this.CrearGrupoBtn.Text = "Crear Grupo";
            this.CrearGrupoBtn.UseVisualStyleBackColor = true;
            // 
            // ChatMembersIn
            // 
            this.ChatMembersIn.FormattingEnabled = true;
            this.ChatMembersIn.Location = new System.Drawing.Point(72, 120);
            this.ChatMembersIn.Name = "ChatMembersIn";
            this.ChatMembersIn.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ChatMembersIn.Size = new System.Drawing.Size(168, 238);
            this.ChatMembersIn.TabIndex = 1;
            // 
            // ChatNameIn
            // 
            this.ChatNameIn.Location = new System.Drawing.Point(80, 56);
            this.ChatNameIn.Name = "ChatNameIn";
            this.ChatNameIn.Size = new System.Drawing.Size(164, 20);
            this.ChatNameIn.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre del Grupo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Integrantes del Grupo:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 445);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChatNameIn);
            this.Controls.Add(this.ChatMembersIn);
            this.Controls.Add(this.CrearGrupoBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CrearGrupoBtn;
        private System.Windows.Forms.ListBox ChatMembersIn;
        private System.Windows.Forms.TextBox ChatNameIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

