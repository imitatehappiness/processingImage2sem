namespace Scale
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
            this.LoadPic = new System.Windows.Forms.Button();
            this.OldImg = new System.Windows.Forms.PictureBox();
            this.NewImg = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.Scale = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Interpolation = new System.Windows.Forms.CheckBox();
            this.Angel = new System.Windows.Forms.NumericUpDown();
            this.Rotate1 = new System.Windows.Forms.Button();
            this.RGBHistogram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OldImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angel)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadPic
            // 
            this.LoadPic.Location = new System.Drawing.Point(10, 511);
            this.LoadPic.Name = "LoadPic";
            this.LoadPic.Size = new System.Drawing.Size(102, 40);
            this.LoadPic.TabIndex = 0;
            this.LoadPic.Text = "LoadPic";
            this.LoadPic.UseVisualStyleBackColor = true;
            this.LoadPic.Click += new System.EventHandler(this.LoadPic_Click);
            // 
            // OldImg
            // 
            this.OldImg.Location = new System.Drawing.Point(2, 0);
            this.OldImg.Name = "OldImg";
            this.OldImg.Size = new System.Drawing.Size(377, 393);
            this.OldImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.OldImg.TabIndex = 1;
            this.OldImg.TabStop = false;
            this.OldImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OldImg_MouseDown);
            this.OldImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OldImg_MouseMove);
            this.OldImg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OldImg_MouseUp);
            // 
            // NewImg
            // 
            this.NewImg.Location = new System.Drawing.Point(611, 0);
            this.NewImg.Name = "NewImg";
            this.NewImg.Size = new System.Drawing.Size(377, 393);
            this.NewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.NewImg.TabIndex = 2;
            this.NewImg.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(118, 528);
            this.trackBar1.Minimum = -9;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(182, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "increase: 1";
            // 
            // Scale
            // 
            this.Scale.Location = new System.Drawing.Point(11, 555);
            this.Scale.Name = "Scale";
            this.Scale.Size = new System.Drawing.Size(101, 32);
            this.Scale.TabIndex = 5;
            this.Scale.Text = "Scale";
            this.Scale.UseVisualStyleBackColor = true;
            this.Scale.Click += new System.EventHandler(this.Scale_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // Interpolation
            // 
            this.Interpolation.AutoSize = true;
            this.Interpolation.Location = new System.Drawing.Point(11, 594);
            this.Interpolation.Name = "Interpolation";
            this.Interpolation.Size = new System.Drawing.Size(84, 17);
            this.Interpolation.TabIndex = 7;
            this.Interpolation.Text = "Interpolation";
            this.Interpolation.UseVisualStyleBackColor = true;
            this.Interpolation.CheckedChanged += new System.EventHandler(this.Interpolation_CheckedChanged);
            // 
            // Angel
            // 
            this.Angel.Location = new System.Drawing.Point(306, 511);
            this.Angel.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.Angel.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.Angel.Name = "Angel";
            this.Angel.Size = new System.Drawing.Size(75, 20);
            this.Angel.TabIndex = 8;
            // 
            // Rotate1
            // 
            this.Rotate1.Location = new System.Drawing.Point(306, 538);
            this.Rotate1.Name = "Rotate1";
            this.Rotate1.Size = new System.Drawing.Size(75, 23);
            this.Rotate1.TabIndex = 9;
            this.Rotate1.Text = "Rotate x y ";
            this.Rotate1.UseVisualStyleBackColor = true;
            this.Rotate1.Click += new System.EventHandler(this.Rotate1_Click);
            // 
            // RGBHistogram
            // 
            this.RGBHistogram.Location = new System.Drawing.Point(306, 567);
            this.RGBHistogram.Name = "RGBHistogram";
            this.RGBHistogram.Size = new System.Drawing.Size(75, 23);
            this.RGBHistogram.TabIndex = 11;
            this.RGBHistogram.Text = "Histogram";
            this.RGBHistogram.UseVisualStyleBackColor = true;
            this.RGBHistogram.Click += new System.EventHandler(this.RGBHistogram_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 617);
            this.Controls.Add(this.RGBHistogram);
            this.Controls.Add(this.Rotate1);
            this.Controls.Add(this.Angel);
            this.Controls.Add(this.Interpolation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Scale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.NewImg);
            this.Controls.Add(this.OldImg);
            this.Controls.Add(this.LoadPic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OldImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadPic;
        private System.Windows.Forms.PictureBox OldImg;
        private System.Windows.Forms.PictureBox NewImg;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Scale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Interpolation;
        private System.Windows.Forms.NumericUpDown Angel;
        private System.Windows.Forms.Button Rotate1;
        private System.Windows.Forms.Button RGBHistogram;
    }
}

