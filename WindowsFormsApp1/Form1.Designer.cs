namespace WindowsFormsApp1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LoadImgA = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Abertura = new System.Windows.Forms.Button();
            this.Fechamento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 198);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(396, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(201, 198);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // LoadImgA
            // 
            this.LoadImgA.Location = new System.Drawing.Point(12, 216);
            this.LoadImgA.Name = "LoadImgA";
            this.LoadImgA.Size = new System.Drawing.Size(201, 23);
            this.LoadImgA.TabIndex = 3;
            this.LoadImgA.Text = "Carregar Imagem 1";
            this.LoadImgA.UseVisualStyleBackColor = true;
            this.LoadImgA.Click += new System.EventHandler(this.LoadImgA_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(396, 216);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Salvar Resultado";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Abertura
            // 
            this.Abertura.Location = new System.Drawing.Point(239, 72);
            this.Abertura.Name = "Abertura";
            this.Abertura.Size = new System.Drawing.Size(128, 23);
            this.Abertura.TabIndex = 6;
            this.Abertura.Text = "Abertura";
            this.Abertura.UseVisualStyleBackColor = true;
            this.Abertura.Click += new System.EventHandler(this.Abertura_Click);
            // 
            // Fechamento
            // 
            this.Fechamento.Location = new System.Drawing.Point(239, 143);
            this.Fechamento.Name = "Fechamento";
            this.Fechamento.Size = new System.Drawing.Size(128, 23);
            this.Fechamento.TabIndex = 7;
            this.Fechamento.Text = "Fechamento";
            this.Fechamento.UseVisualStyleBackColor = true;
            this.Fechamento.Click += new System.EventHandler(this.Fechamento_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 271);
            this.Controls.Add(this.Fechamento);
            this.Controls.Add(this.Abertura);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.LoadImgA);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button LoadImgA;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Abertura;
        private System.Windows.Forms.Button Fechamento;
    }
}

