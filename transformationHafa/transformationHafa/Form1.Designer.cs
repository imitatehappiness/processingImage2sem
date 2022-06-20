namespace transformationHafa
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadImg = new System.Windows.Forms.Button();
            this.LineHAFA = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CircleHAFA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CircleHAFAAnyR = new System.Windows.Forms.Button();
            this.FindMoney = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadImg
            // 
            this.LoadImg.Location = new System.Drawing.Point(4, 13);
            this.LoadImg.Name = "LoadImg";
            this.LoadImg.Size = new System.Drawing.Size(100, 23);
            this.LoadImg.TabIndex = 0;
            this.LoadImg.Text = "LoadImg";
            this.LoadImg.UseVisualStyleBackColor = true;
            this.LoadImg.Click += new System.EventHandler(this.LoadImg_Click);
            // 
            // LineHAFA
            // 
            this.LineHAFA.Location = new System.Drawing.Point(4, 43);
            this.LineHAFA.Name = "LineHAFA";
            this.LineHAFA.Size = new System.Drawing.Size(100, 23);
            this.LineHAFA.TabIndex = 1;
            this.LineHAFA.Text = "LineHAFA";
            this.LineHAFA.UseVisualStyleBackColor = true;
            this.LineHAFA.Click += new System.EventHandler(this.LineHAFA_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(110, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(798, 530);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // CircleHAFA
            // 
            this.CircleHAFA.Location = new System.Drawing.Point(4, 73);
            this.CircleHAFA.Name = "CircleHAFA";
            this.CircleHAFA.Size = new System.Drawing.Size(100, 23);
            this.CircleHAFA.TabIndex = 3;
            this.CircleHAFA.Text = "CircleHAFAFixR";
            this.CircleHAFA.UseVisualStyleBackColor = true;
            this.CircleHAFA.Click += new System.EventHandler(this.CircleHAFA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "coordMove";
            // 
            // CircleHAFAAnyR
            // 
            this.CircleHAFAAnyR.Location = new System.Drawing.Point(4, 129);
            this.CircleHAFAAnyR.Name = "CircleHAFAAnyR";
            this.CircleHAFAAnyR.Size = new System.Drawing.Size(100, 23);
            this.CircleHAFAAnyR.TabIndex = 5;
            this.CircleHAFAAnyR.Text = "CircleHAFAAnyR";
            this.CircleHAFAAnyR.UseVisualStyleBackColor = true;
            this.CircleHAFAAnyR.Click += new System.EventHandler(this.CircleHAFAAnyR_Click);
            // 
            // FindMoney
            // 
            this.FindMoney.Location = new System.Drawing.Point(4, 159);
            this.FindMoney.Name = "FindMoney";
            this.FindMoney.Size = new System.Drawing.Size(100, 23);
            this.FindMoney.TabIndex = 6;
            this.FindMoney.Text = "FindMoney";
            this.FindMoney.UseVisualStyleBackColor = true;
            this.FindMoney.Click += new System.EventHandler(this.FindMoney_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "sum: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FindMoney);
            this.Controls.Add(this.CircleHAFAAnyR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CircleHAFA);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LineHAFA);
            this.Controls.Add(this.LoadImg);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadImg;
        private System.Windows.Forms.Button LineHAFA;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CircleHAFA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CircleHAFAAnyR;
        private System.Windows.Forms.Button FindMoney;
        private System.Windows.Forms.Label label2;
    }
}

