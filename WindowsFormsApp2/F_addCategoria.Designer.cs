namespace WindowsFormsApp2
{
    partial class F_addCategoria
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
            this.label6 = new System.Windows.Forms.Label();
            this.rxtDescricao = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCatNome = new System.Windows.Forms.TextBox();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Descrição";
            // 
            // rxtDescricao
            // 
            this.rxtDescricao.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rxtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rxtDescricao.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rxtDescricao.Location = new System.Drawing.Point(35, 105);
            this.rxtDescricao.Name = "rxtDescricao";
            this.rxtDescricao.Size = new System.Drawing.Size(337, 152);
            this.rxtDescricao.TabIndex = 15;
            this.rxtDescricao.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nome da Categoria";
            // 
            // txtCatNome
            // 
            this.txtCatNome.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatNome.Location = new System.Drawing.Point(182, 40);
            this.txtCatNome.Name = "txtCatNome";
            this.txtCatNome.Size = new System.Drawing.Size(190, 29);
            this.txtCatNome.TabIndex = 11;
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.BackColor = System.Drawing.Color.Tan;
            this.btn_adicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adicionar.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar.Location = new System.Drawing.Point(280, 293);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(92, 35);
            this.btn_adicionar.TabIndex = 17;
            this.btn_adicionar.Text = "Adicionar";
            this.btn_adicionar.UseVisualStyleBackColor = false;
            this.btn_adicionar.Click += new System.EventHandler(this.Btn_adicionar_Click);
            // 
            // F_addCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 339);
            this.Controls.Add(this.btn_adicionar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rxtDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCatNome);
            this.Name = "F_addCategoria";
            this.Text = "F_addCategoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rxtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCatNome;
        private System.Windows.Forms.Button btn_adicionar;
    }
}