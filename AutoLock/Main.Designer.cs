namespace AutoLock
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        // Dispose method...

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnRecordStart = new Button();
            btnAutoLockStart = new Button();
            btnMinimize = new Button();
            btnStop = new Button();
            lblStatus = new Label();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            restoreToolStripMenuItem = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            panel2 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnRecordStart
            // 
            btnRecordStart.BackColor = SystemColors.ButtonHighlight;
            btnRecordStart.FlatAppearance.BorderColor = Color.White;
            btnRecordStart.FlatAppearance.BorderSize = 0;
            btnRecordStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRecordStart.ForeColor = Color.DimGray;
            btnRecordStart.Image = Properties.Resources.icons8_facial_recognition_64px;
            btnRecordStart.ImageAlign = ContentAlignment.MiddleLeft;
            btnRecordStart.Location = new Point(27, 36);
            btnRecordStart.Name = "btnRecordStart";
            btnRecordStart.Size = new Size(205, 57);
            btnRecordStart.TabIndex = 1;
            btnRecordStart.Text = "Start";
            btnRecordStart.UseVisualStyleBackColor = false;
            btnRecordStart.Click += btnRecordStart_Click;
            // 
            // btnAutoLockStart
            // 
            btnAutoLockStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAutoLockStart.ForeColor = Color.FromArgb(64, 64, 64);
            btnAutoLockStart.Image = Properties.Resources.icons8_Facial_Recognition_64px_1;
            btnAutoLockStart.ImageAlign = ContentAlignment.MiddleLeft;
            btnAutoLockStart.Location = new Point(27, 33);
            btnAutoLockStart.Name = "btnAutoLockStart";
            btnAutoLockStart.Size = new Size(205, 57);
            btnAutoLockStart.TabIndex = 2;
            btnAutoLockStart.Text = "Start";
            btnAutoLockStart.UseVisualStyleBackColor = true;
            btnAutoLockStart.Click += btnAutoLockStart_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Image = Properties.Resources.minimize_window_32px;
            btnMinimize.ImageAlign = ContentAlignment.TopCenter;
            btnMinimize.Location = new Point(33, 441);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(100, 62);
            btnMinimize.TabIndex = 3;
            btnMinimize.Text = "Minimize";
            btnMinimize.TextAlign = ContentAlignment.BottomCenter;
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnStop
            // 
            btnStop.Image = Properties.Resources.stop_32px;
            btnStop.ImageAlign = ContentAlignment.TopCenter;
            btnStop.Location = new Point(152, 441);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 62);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop";
            btnStop.TextAlign = ContentAlignment.BottomCenter;
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(255, 128, 128);
            lblStatus.Location = new Point(0, 471);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(478, 44);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status:";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipTitle = "Auto Lock";
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Auto Lock v1.0";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { restoreToolStripMenuItem, stopToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(129, 76);
            // 
            // restoreToolStripMenuItem
            // 
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.Size = new Size(128, 24);
            restoreToolStripMenuItem.Text = "Restore";
            restoreToolStripMenuItem.Click += restoreToolStripMenuItem_Click;
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(128, 24);
            stopToolStripMenuItem.Text = "Stop";
            stopToolStripMenuItem.Click += stopToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(128, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(btnMinimize);
            panel1.Controls.Add(btnStop);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(286, 515);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(165, 3);
            label1.Name = "label1";
            label1.Size = new Size(109, 148);
            label1.TabIndex = 6;
            label1.Text = "Auto \r\nLock";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.LogoApp;
            pictureBox2.Location = new Point(6, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(152, 148);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAutoLockStart);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(64, 64, 64);
            groupBox2.Location = new Point(12, 316);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 107);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Enable Auto Lock";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRecordStart);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(64, 64, 64);
            groupBox1.Location = new Point(12, 186);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(257, 107);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Record your face data";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(lblStatus);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(286, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(478, 515);
            panel2.TabIndex = 10;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(224, 224, 224);
            label2.Location = new Point(6, 430);
            label2.Name = "label2";
            label2.Size = new Size(450, 32);
            label2.TabIndex = 10;
            label2.Text = "BY: SAFAA JASSIM KHAEED | TECNO U";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(478, 471);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Main
            // 
            BackColor = SystemColors.Control;
            ClientSize = new Size(764, 515);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "Auto Lock ";
            FormClosing += Form1_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnRecordStart;
        private System.Windows.Forms.Button btnAutoLockStart;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Panel panel1;
        private GroupBox groupBox1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label2;
    }
}
