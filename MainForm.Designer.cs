namespace EyeAssistant
{
    partial class MainForm
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
            this.densityGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.densityMax = new System.Windows.Forms.TextBox();
            this.densityMin = new System.Windows.Forms.TextBox();
            this.viewGroup = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GLView = new OpenTK.GLControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.trackSlopeQ = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.trackSgnOffQ = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackSgnOffI = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.trackSlopeI = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.display = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.densityGroup.SuspendLayout();
            this.viewGroup.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSlopeQ)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSgnOffQ)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSgnOffI)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSlopeI)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.display.SuspendLayout();
            this.SuspendLayout();
            // 
            // densityGroup
            // 
            this.densityGroup.Controls.Add(this.label2);
            this.densityGroup.Controls.Add(this.label1);
            this.densityGroup.Controls.Add(this.densityMax);
            this.densityGroup.Controls.Add(this.densityMin);
            this.densityGroup.Location = new System.Drawing.Point(9, 10);
            this.densityGroup.Name = "densityGroup";
            this.densityGroup.Size = new System.Drawing.Size(308, 50);
            this.densityGroup.TabIndex = 4;
            this.densityGroup.TabStop = false;
            this.densityGroup.Text = "Значения TX LO на текущем кадре";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Min:";
            // 
            // densityMax
            // 
            this.densityMax.Enabled = false;
            this.densityMax.Location = new System.Drawing.Point(191, 19);
            this.densityMax.Name = "densityMax";
            this.densityMax.Size = new System.Drawing.Size(108, 20);
            this.densityMax.TabIndex = 1;
            // 
            // densityMin
            // 
            this.densityMin.Enabled = false;
            this.densityMin.Location = new System.Drawing.Point(39, 19);
            this.densityMin.Name = "densityMin";
            this.densityMin.Size = new System.Drawing.Size(108, 20);
            this.densityMin.TabIndex = 0;
            this.densityMin.WordWrap = false;
            // 
            // viewGroup
            // 
            this.viewGroup.Controls.Add(this.groupBox5);
            this.viewGroup.Controls.Add(this.groupBox4);
            this.viewGroup.Controls.Add(this.groupBox3);
            this.viewGroup.Controls.Add(this.groupBox2);
            this.viewGroup.Controls.Add(this.groupBox1);
            this.viewGroup.Location = new System.Drawing.Point(9, 66);
            this.viewGroup.Name = "viewGroup";
            this.viewGroup.Size = new System.Drawing.Size(606, 620);
            this.viewGroup.TabIndex = 5;
            this.viewGroup.TabStop = false;
            this.viewGroup.Text = "Отображение";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.GLView);
            this.groupBox5.Location = new System.Drawing.Point(145, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(452, 433);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "dco Q";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "dco I";
            // 
            // GLView
            // 
            this.GLView.BackColor = System.Drawing.Color.Black;
            this.GLView.Location = new System.Drawing.Point(6, 28);
            this.GLView.Name = "GLView";
            this.GLView.Size = new System.Drawing.Size(400, 400);
            this.GLView.TabIndex = 1;
            this.GLView.VSync = false;
            this.GLView.Paint += new System.Windows.Forms.PaintEventHandler(this.GLViewLeft_Paint);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.trackSlopeQ);
            this.groupBox4.Location = new System.Drawing.Point(145, 533);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(452, 78);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Slope";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(10, 58);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(13, 13);
            this.label28.TabIndex = 18;
            this.label28.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(150, 58);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(13, 13);
            this.label27.TabIndex = 17;
            this.label27.Text = "1";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(289, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(13, 13);
            this.label26.TabIndex = 16;
            this.label26.Text = "2";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(430, 58);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(13, 13);
            this.label25.TabIndex = 13;
            this.label25.Text = "3";
            // 
            // trackSlopeQ
            // 
            this.trackSlopeQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackSlopeQ.LargeChange = 3;
            this.trackSlopeQ.Location = new System.Drawing.Point(3, 16);
            this.trackSlopeQ.Maximum = 3;
            this.trackSlopeQ.Name = "trackSlopeQ";
            this.trackSlopeQ.Size = new System.Drawing.Size(446, 59);
            this.trackSlopeQ.TabIndex = 11;
            this.trackSlopeQ.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackSlopeQ.Value = 3;
            this.trackSlopeQ.Scroll += new System.EventHandler(this.vhScroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.trackSgnOffQ);
            this.groupBox3.Location = new System.Drawing.Point(145, 450);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 80);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Offset";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 61);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(16, 13);
            this.label24.TabIndex = 27;
            this.label24.Text = "-3";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(69, 61);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 13);
            this.label23.TabIndex = 26;
            this.label23.Text = "-2";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(128, 61);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 13);
            this.label22.TabIndex = 25;
            this.label22.Text = "-1";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(188, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 13);
            this.label21.TabIndex = 24;
            this.label21.Text = "-0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(245, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "+0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(306, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "+1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(366, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "+2";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(427, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "+3";
            // 
            // trackSgnOffQ
            // 
            this.trackSgnOffQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackSgnOffQ.LargeChange = 3;
            this.trackSgnOffQ.Location = new System.Drawing.Point(3, 16);
            this.trackSgnOffQ.Maximum = 3;
            this.trackSgnOffQ.Minimum = -4;
            this.trackSgnOffQ.Name = "trackSgnOffQ";
            this.trackSgnOffQ.Size = new System.Drawing.Size(446, 61);
            this.trackSgnOffQ.TabIndex = 10;
            this.trackSgnOffQ.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackSgnOffQ.Scroll += new System.EventHandler(this.vhScroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.trackSgnOffI);
            this.groupBox2.Location = new System.Drawing.Point(75, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(64, 433);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Offset";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 410);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "-3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "-2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "-1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "-0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "+0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "+1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "+2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "+3";
            // 
            // trackSgnOffI
            // 
            this.trackSgnOffI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackSgnOffI.LargeChange = 3;
            this.trackSgnOffI.Location = new System.Drawing.Point(3, 16);
            this.trackSgnOffI.Maximum = 3;
            this.trackSgnOffI.Minimum = -4;
            this.trackSgnOffI.Name = "trackSgnOffI";
            this.trackSgnOffI.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackSgnOffI.Size = new System.Drawing.Size(58, 414);
            this.trackSgnOffI.TabIndex = 10;
            this.trackSgnOffI.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackSgnOffI.Value = -1;
            this.trackSgnOffI.Scroll += new System.EventHandler(this.vhScroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.trackSlopeI);
            this.groupBox1.Location = new System.Drawing.Point(9, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(60, 433);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slope";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 410);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(44, 281);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(43, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(43, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "3";
            // 
            // trackSlopeI
            // 
            this.trackSlopeI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackSlopeI.LargeChange = 3;
            this.trackSlopeI.Location = new System.Drawing.Point(3, 16);
            this.trackSlopeI.Maximum = 3;
            this.trackSlopeI.Name = "trackSlopeI";
            this.trackSlopeI.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackSlopeI.Size = new System.Drawing.Size(54, 414);
            this.trackSlopeI.TabIndex = 9;
            this.trackSlopeI.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackSlopeI.Value = 3;
            this.trackSlopeI.Scroll += new System.EventHandler(this.vhScroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // display
            // 
            this.display.Controls.Add(this.densityGroup);
            this.display.Controls.Add(this.viewGroup);
            this.display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.display.Enabled = false;
            this.display.Location = new System.Drawing.Point(0, 24);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(624, 694);
            this.display.TabIndex = 7;
            this.display.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 718);
            this.Controls.Add(this.display);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.densityGroup.ResumeLayout(false);
            this.densityGroup.PerformLayout();
            this.viewGroup.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSlopeQ)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSgnOffQ)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSgnOffI)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSlopeI)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.display.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox densityGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox densityMax;
        private System.Windows.Forms.TextBox densityMin;
        private System.Windows.Forms.GroupBox viewGroup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.GroupBox display;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private OpenTK.GLControl GLView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar trackSlopeQ;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar trackSgnOffQ;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar trackSgnOffI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackSlopeI;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}

