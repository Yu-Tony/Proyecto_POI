namespace ProjectPOI
{
    partial class Form2
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
            this.ChatNameIn = new System.Windows.Forms.TextBox();
            this.ChatMembersIn = new System.Windows.Forms.ListBox();
            this.CrearGrupoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Integrantes del Grupo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre del Grupo:";
            // 
            // ChatNameIn
            // 
            this.ChatNameIn.Location = new System.Drawing.Point(56, 48);
            this.ChatNameIn.Name = "ChatNameIn";
            this.ChatNameIn.Size = new System.Drawing.Size(164, 20);
            this.ChatNameIn.TabIndex = 7;
            // 
            // ChatMembersIn
            // 
            this.ChatMembersIn.FormattingEnabled = true;
            this.ChatMembersIn.Location = new System.Drawing.Point(48, 112);
            this.ChatMembersIn.Name = "ChatMembersIn";
            this.ChatMembersIn.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ChatMembersIn.Size = new System.Drawing.Size(168, 238);
            this.ChatMembersIn.TabIndex = 6;
            this.ChatMembersIn.SelectedIndexChanged += new System.EventHandler(this.ChatMembersIn_SelectedIndexChanged);
            // 
            // CrearGrupoBtn
            // 
            this.CrearGrupoBtn.Location = new System.Drawing.Point(32, 376);
            this.CrearGrupoBtn.Name = "CrearGrupoBtn";
            this.CrearGrupoBtn.Size = new System.Drawing.Size(200, 47);
            this.CrearGrupoBtn.TabIndex = 5;
            this.CrearGrupoBtn.Text = "Crear Grupo";
            this.CrearGrupoBtn.UseVisualStyleBackColor = true;
            this.CrearGrupoBtn.Click += new System.EventHandler(this.CrearGrupoBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChatNameIn);
            this.Controls.Add(this.ChatMembersIn);
            this.Controls.Add(this.CrearGrupoBtn);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ChatNameIn;
        private System.Windows.Forms.ListBox ChatMembersIn;
        private System.Windows.Forms.Button CrearGrupoBtn;
    }
}