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
            this.GLViewLeft = new OpenTK.GLControl();
            this.GLViewRight = new OpenTK.GLControl();
            this.hScroll = new System.Windows.Forms.HScrollBar();
            this.densityGroup = new System.Windows.Forms.GroupBox();
            this.densityMin = new System.Windows.Forms.TextBox();
            this.densityMax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.viewGroup = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.display = new System.Windows.Forms.GroupBox();
            this.drawModeGroup = new System.Windows.Forms.GroupBox();
            this.radioDrawQuads = new System.Windows.Forms.RadioButton();
            this.radioQuadsStrip = new System.Windows.Forms.RadioButton();
            this.radioTexture = new System.Windows.Forms.RadioButton();
            this.filenamesGroup = new System.Windows.Forms.GroupBox();
            this.filepathLeft = new System.Windows.Forms.TextBox();
            this.filepathRight = new System.Windows.Forms.TextBox();
            this.browseLeft = new System.Windows.Forms.Button();
            this.browseRight = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.densityGroup.SuspendLayout();
            this.viewGroup.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.display.SuspendLayout();
            this.drawModeGroup.SuspendLayout();
            this.filenamesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GLViewLeft
            // 
            this.GLViewLeft.BackColor = System.Drawing.Color.Black;
            this.GLViewLeft.Location = new System.Drawing.Point(9, 19);
            this.GLViewLeft.Name = "GLViewLeft";
            this.GLViewLeft.Size = new System.Drawing.Size(400, 400);
            this.GLViewLeft.TabIndex = 0;
            this.GLViewLeft.VSync = false;
            this.GLViewLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.GLViewLeft_Paint);
            // 
            // GLViewRight
            // 
            this.GLViewRight.BackColor = System.Drawing.Color.Black;
            this.GLViewRight.Location = new System.Drawing.Point(415, 19);
            this.GLViewRight.Name = "GLViewRight";
            this.GLViewRight.Size = new System.Drawing.Size(400, 400);
            this.GLViewRight.TabIndex = 1;
            this.GLViewRight.VSync = false;
            this.GLViewRight.Paint += new System.Windows.Forms.PaintEventHandler(this.GLViewRight_Paint);
            // 
            // hScroll
            // 
            this.hScroll.Location = new System.Drawing.Point(9, 422);
            this.hScroll.Name = "hScroll";
            this.hScroll.Size = new System.Drawing.Size(806, 17);
            this.hScroll.TabIndex = 3;
            this.hScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScroll_Scroll);
            // 
            // densityGroup
            // 
            this.densityGroup.Controls.Add(this.label2);
            this.densityGroup.Controls.Add(this.label1);
            this.densityGroup.Controls.Add(this.densityMax);
            this.densityGroup.Controls.Add(this.densityMin);
            this.densityGroup.Location = new System.Drawing.Point(9, 10);
            this.densityGroup.Name = "densityGroup";
            this.densityGroup.Size = new System.Drawing.Size(158, 78);
            this.densityGroup.TabIndex = 4;
            this.densityGroup.TabStop = false;
            this.densityGroup.Text = "Плотность";
            // 
            // densityMin
            // 
            this.densityMin.Location = new System.Drawing.Point(39, 19);
            this.densityMin.Name = "densityMin";
            this.densityMin.Size = new System.Drawing.Size(108, 20);
            this.densityMin.TabIndex = 0;
            this.densityMin.WordWrap = false;
            this.densityMin.TextChanged += new System.EventHandler(this.densityMin_TextChanged);
            // 
            // densityMax
            // 
            this.densityMax.Location = new System.Drawing.Point(39, 45);
            this.densityMax.Name = "densityMax";
            this.densityMax.Size = new System.Drawing.Size(108, 20);
            this.densityMax.TabIndex = 1;
            this.densityMax.TextChanged += new System.EventHandler(this.densityMax_TextChanged);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max:";
            // 
            // viewGroup
            // 
            this.viewGroup.Controls.Add(this.GLViewLeft);
            this.viewGroup.Controls.Add(this.GLViewRight);
            this.viewGroup.Controls.Add(this.hScroll);
            this.viewGroup.Location = new System.Drawing.Point(9, 94);
            this.viewGroup.Name = "viewGroup";
            this.viewGroup.Size = new System.Drawing.Size(829, 448);
            this.viewGroup.TabIndex = 5;
            this.viewGroup.TabStop = false;
            this.viewGroup.Text = "Отображение";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 24);
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
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // display
            // 
            this.display.Controls.Add(this.filenamesGroup);
            this.display.Controls.Add(this.drawModeGroup);
            this.display.Controls.Add(this.densityGroup);
            this.display.Controls.Add(this.viewGroup);
            this.display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.display.Enabled = false;
            this.display.Location = new System.Drawing.Point(0, 24);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(869, 567);
            this.display.TabIndex = 7;
            this.display.TabStop = false;
            // 
            // drawModeGroup
            // 
            this.drawModeGroup.Controls.Add(this.radioTexture);
            this.drawModeGroup.Controls.Add(this.radioQuadsStrip);
            this.drawModeGroup.Controls.Add(this.radioDrawQuads);
            this.drawModeGroup.Location = new System.Drawing.Point(173, 10);
            this.drawModeGroup.Name = "drawModeGroup";
            this.drawModeGroup.Size = new System.Drawing.Size(106, 78);
            this.drawModeGroup.TabIndex = 6;
            this.drawModeGroup.TabStop = false;
            this.drawModeGroup.Text = "Отрисовка";
            // 
            // radioDrawQuads
            // 
            this.radioDrawQuads.Location = new System.Drawing.Point(6, 16);
            this.radioDrawQuads.Name = "radioDrawQuads";
            this.radioDrawQuads.Size = new System.Drawing.Size(94, 20);
            this.radioDrawQuads.TabIndex = 0;
            this.radioDrawQuads.Text = "Quads";
            this.radioDrawQuads.UseVisualStyleBackColor = true;
            this.radioDrawQuads.CheckedChanged += new System.EventHandler(this.radioDrawSwitcher);
            // 
            // radioQuadsStrip
            // 
            this.radioQuadsStrip.Location = new System.Drawing.Point(6, 33);
            this.radioQuadsStrip.Name = "radioQuadsStrip";
            this.radioQuadsStrip.Size = new System.Drawing.Size(94, 20);
            this.radioQuadsStrip.TabIndex = 1;
            this.radioQuadsStrip.Text = "QuadsStrip";
            this.radioQuadsStrip.UseVisualStyleBackColor = true;
            this.radioQuadsStrip.CheckedChanged += new System.EventHandler(this.radioDrawSwitcher);
            // 
            // radioTexture
            // 
            this.radioTexture.Checked = true;
            this.radioTexture.Location = new System.Drawing.Point(6, 50);
            this.radioTexture.Name = "radioTexture";
            this.radioTexture.Size = new System.Drawing.Size(94, 20);
            this.radioTexture.TabIndex = 2;
            this.radioTexture.TabStop = true;
            this.radioTexture.Text = "Texture";
            this.radioTexture.UseVisualStyleBackColor = true;
            this.radioTexture.CheckedChanged += new System.EventHandler(this.radioDrawSwitcher);
            // 
            // filenamesGroup
            // 
            this.filenamesGroup.Controls.Add(this.label4);
            this.filenamesGroup.Controls.Add(this.label3);
            this.filenamesGroup.Controls.Add(this.browseRight);
            this.filenamesGroup.Controls.Add(this.browseLeft);
            this.filenamesGroup.Controls.Add(this.filepathRight);
            this.filenamesGroup.Controls.Add(this.filepathLeft);
            this.filenamesGroup.Location = new System.Drawing.Point(285, 10);
            this.filenamesGroup.Name = "filenamesGroup";
            this.filenamesGroup.Size = new System.Drawing.Size(553, 78);
            this.filenamesGroup.TabIndex = 7;
            this.filenamesGroup.TabStop = false;
            this.filenamesGroup.Text = "Данные";
            // 
            // filepathLeft
            // 
            this.filepathLeft.Enabled = false;
            this.filepathLeft.Location = new System.Drawing.Point(62, 19);
            this.filepathLeft.Name = "filepathLeft";
            this.filepathLeft.Size = new System.Drawing.Size(416, 20);
            this.filepathLeft.TabIndex = 0;
            // 
            // filepathRight
            // 
            this.filepathRight.Enabled = false;
            this.filepathRight.Location = new System.Drawing.Point(62, 45);
            this.filepathRight.Name = "filepathRight";
            this.filepathRight.Size = new System.Drawing.Size(416, 20);
            this.filepathRight.TabIndex = 1;
            // 
            // browseLeft
            // 
            this.browseLeft.Location = new System.Drawing.Point(484, 17);
            this.browseLeft.Name = "browseLeft";
            this.browseLeft.Size = new System.Drawing.Size(55, 23);
            this.browseLeft.TabIndex = 2;
            this.browseLeft.Text = "...";
            this.browseLeft.UseVisualStyleBackColor = true;
            this.browseLeft.Click += new System.EventHandler(this.openLeft);
            // 
            // browseRight
            // 
            this.browseRight.Location = new System.Drawing.Point(484, 43);
            this.browseRight.Name = "browseRight";
            this.browseRight.Size = new System.Drawing.Size(55, 23);
            this.browseRight.TabIndex = 3;
            this.browseRight.Text = "...";
            this.browseRight.UseVisualStyleBackColor = true;
            this.browseRight.Click += new System.EventHandler(this.openRight);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Левый:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Правый:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 591);
            this.Controls.Add(this.display);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.densityGroup.ResumeLayout(false);
            this.densityGroup.PerformLayout();
            this.viewGroup.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.display.ResumeLayout(false);
            this.drawModeGroup.ResumeLayout(false);
            this.filenamesGroup.ResumeLayout(false);
            this.filenamesGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl GLViewLeft;
        private OpenTK.GLControl GLViewRight;
        private System.Windows.Forms.HScrollBar hScroll;
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
        private System.Windows.Forms.GroupBox drawModeGroup;
        private System.Windows.Forms.RadioButton radioDrawQuads;
        private System.Windows.Forms.RadioButton radioTexture;
        private System.Windows.Forms.RadioButton radioQuadsStrip;
        private System.Windows.Forms.GroupBox filenamesGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browseRight;
        private System.Windows.Forms.Button browseLeft;
        private System.Windows.Forms.TextBox filepathRight;
        private System.Windows.Forms.TextBox filepathLeft;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

