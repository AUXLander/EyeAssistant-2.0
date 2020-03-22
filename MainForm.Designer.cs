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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // GLViewLeft
            // 
            this.GLViewLeft.BackColor = System.Drawing.Color.Black;
            this.GLViewLeft.Location = new System.Drawing.Point(12, 191);
            this.GLViewLeft.Name = "GLViewLeft";
            this.GLViewLeft.Size = new System.Drawing.Size(400, 400);
            this.GLViewLeft.TabIndex = 0;
            this.GLViewLeft.VSync = false;
            this.GLViewLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.GLViewLeft_Paint);
            // 
            // GLViewRight
            // 
            this.GLViewRight.BackColor = System.Drawing.Color.Black;
            this.GLViewRight.Location = new System.Drawing.Point(418, 191);
            this.GLViewRight.Name = "GLViewRight";
            this.GLViewRight.Size = new System.Drawing.Size(400, 400);
            this.GLViewRight.TabIndex = 1;
            this.GLViewRight.VSync = false;
            this.GLViewRight.Paint += new System.Windows.Forms.PaintEventHandler(this.GLViewRight_Paint);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 97);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(776, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 603);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.GLViewRight);
            this.Controls.Add(this.GLViewLeft);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl GLViewLeft;
        private OpenTK.GLControl GLViewRight;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

