namespace Filter
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LowFilter = new System.Windows.Forms.Button();
            this.HightFiler = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Median = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Gaus = new System.Windows.Forms.Button();
            this.Laplas = new System.Windows.Forms.Button();
            this.Roberts = new System.Windows.Forms.Button();
            this.Sobel = new System.Windows.Forms.Button();
            this.Previt = new System.Windows.Forms.Button();
            this.Kirsh = new System.Windows.Forms.Button();
            this.Embossing = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Shift = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(462, 435);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(525, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(477, 435);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // LowFilter
            // 
            this.LowFilter.Location = new System.Drawing.Point(18, 19);
            this.LowFilter.Name = "LowFilter";
            this.LowFilter.Size = new System.Drawing.Size(75, 23);
            this.LowFilter.TabIndex = 2;
            this.LowFilter.Text = "LowFilter";
            this.LowFilter.UseVisualStyleBackColor = true;
            this.LowFilter.Click += new System.EventHandler(this.LowFilter_Click);
            // 
            // HightFiler
            // 
            this.HightFiler.Location = new System.Drawing.Point(18, 48);
            this.HightFiler.Name = "HightFiler";
            this.HightFiler.Size = new System.Drawing.Size(75, 23);
            this.HightFiler.TabIndex = 3;
            this.HightFiler.Text = "HightFiler";
            this.HightFiler.UseVisualStyleBackColor = true;
            this.HightFiler.Click += new System.EventHandler(this.HightFiler_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(12, 455);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(76, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Median
            // 
            this.Median.Location = new System.Drawing.Point(99, 19);
            this.Median.Name = "Median";
            this.Median.Size = new System.Drawing.Size(75, 23);
            this.Median.TabIndex = 5;
            this.Median.Text = "MedianFiter";
            this.Median.UseVisualStyleBackColor = true;
            this.Median.Click += new System.EventHandler(this.Median_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // Gaus
            // 
            this.Gaus.Location = new System.Drawing.Point(99, 48);
            this.Gaus.Name = "Gaus";
            this.Gaus.Size = new System.Drawing.Size(75, 23);
            this.Gaus.TabIndex = 7;
            this.Gaus.Text = "GausFiter";
            this.Gaus.UseVisualStyleBackColor = true;
            this.Gaus.Click += new System.EventHandler(this.Gaus_Click);
            // 
            // Laplas
            // 
            this.Laplas.Location = new System.Drawing.Point(6, 21);
            this.Laplas.Name = "Laplas";
            this.Laplas.Size = new System.Drawing.Size(75, 23);
            this.Laplas.TabIndex = 8;
            this.Laplas.Text = "Laplas";
            this.Laplas.UseVisualStyleBackColor = true;
            this.Laplas.Click += new System.EventHandler(this.Laplas_Click);
            // 
            // Roberts
            // 
            this.Roberts.Location = new System.Drawing.Point(6, 50);
            this.Roberts.Name = "Roberts";
            this.Roberts.Size = new System.Drawing.Size(75, 23);
            this.Roberts.TabIndex = 9;
            this.Roberts.Text = "Roberts";
            this.Roberts.UseVisualStyleBackColor = true;
            this.Roberts.Click += new System.EventHandler(this.Roberts_Click);
            // 
            // Sobel
            // 
            this.Sobel.Location = new System.Drawing.Point(88, 21);
            this.Sobel.Name = "Sobel";
            this.Sobel.Size = new System.Drawing.Size(75, 23);
            this.Sobel.TabIndex = 10;
            this.Sobel.Text = "Sobel";
            this.Sobel.UseVisualStyleBackColor = true;
            this.Sobel.Click += new System.EventHandler(this.Sobel_Click);
            // 
            // Previt
            // 
            this.Previt.Location = new System.Drawing.Point(88, 50);
            this.Previt.Name = "Previt";
            this.Previt.Size = new System.Drawing.Size(75, 23);
            this.Previt.TabIndex = 11;
            this.Previt.Text = "Previt";
            this.Previt.UseVisualStyleBackColor = true;
            this.Previt.Click += new System.EventHandler(this.Previt_Click);
            // 
            // Kirsh
            // 
            this.Kirsh.Location = new System.Drawing.Point(170, 21);
            this.Kirsh.Name = "Kirsh";
            this.Kirsh.Size = new System.Drawing.Size(75, 23);
            this.Kirsh.TabIndex = 12;
            this.Kirsh.Text = "Kirsh";
            this.Kirsh.UseVisualStyleBackColor = true;
            this.Kirsh.Click += new System.EventHandler(this.Kirsh_Click);
            // 
            // Embossing
            // 
            this.Embossing.Location = new System.Drawing.Point(251, 50);
            this.Embossing.Name = "Embossing";
            this.Embossing.Size = new System.Drawing.Size(121, 23);
            this.Embossing.TabIndex = 13;
            this.Embossing.Text = "Embossing";
            this.Embossing.UseVisualStyleBackColor = true;
            this.Embossing.Click += new System.EventHandler(this.Embossing_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Выдавленный",
            "Вдавленный"});
            this.comboBox1.Location = new System.Drawing.Point(251, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.Tag = "";
            // 
            // Shift
            // 
            this.Shift.Location = new System.Drawing.Point(378, 50);
            this.Shift.Name = "Shift";
            this.Shift.Size = new System.Drawing.Size(160, 23);
            this.Shift.TabIndex = 16;
            this.Shift.Text = "shift and difference";
            this.Shift.UseVisualStyleBackColor = true;
            this.Shift.Click += new System.EventHandler(this.Shift_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Вертикальные края",
            "Горизонтальные края",
            "Диагональные края"});
            this.comboBox2.Location = new System.Drawing.Point(379, 23);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(159, 21);
            this.comboBox2.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Laplas);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.Roberts);
            this.groupBox1.Controls.Add(this.Shift);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.Sobel);
            this.groupBox1.Controls.Add(this.Embossing);
            this.groupBox1.Controls.Add(this.Previt);
            this.groupBox1.Controls.Add(this.Kirsh);
            this.groupBox1.Location = new System.Drawing.Point(228, 476);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 89);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "edge reinforcement";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LowFilter);
            this.groupBox2.Controls.Add(this.HightFiler);
            this.groupBox2.Controls.Add(this.Gaus);
            this.groupBox2.Controls.Add(this.Median);
            this.groupBox2.Location = new System.Drawing.Point(12, 481);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 84);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 579);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button LowFilter;
        private System.Windows.Forms.Button HightFiler;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button Median;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Gaus;
        private System.Windows.Forms.Button Laplas;
        private System.Windows.Forms.Button Roberts;
        private System.Windows.Forms.Button Sobel;
        private System.Windows.Forms.Button Previt;
        private System.Windows.Forms.Button Kirsh;
        private System.Windows.Forms.Button Embossing;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Shift;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

