namespace STM_PC_1
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
            this.amplitudePictureBox = new System.Windows.Forms.PictureBox();
            this.freqResolutionTextBox = new System.Windows.Forms.TextBox();
            this.maximumFrequencyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uDPStreamingPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.udpStreamingPortTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.sTMConfigurationIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stmConfigurationIpTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumFrequencyNumericUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // amplitudePictureBox
            // 
            this.amplitudePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.amplitudePictureBox.Location = new System.Drawing.Point(12, 30);
            this.amplitudePictureBox.Name = "amplitudePictureBox";
            this.amplitudePictureBox.Size = new System.Drawing.Size(432, 301);
            this.amplitudePictureBox.TabIndex = 2;
            this.amplitudePictureBox.TabStop = false;
            // 
            // freqResolutionTextBox
            // 
            this.freqResolutionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.freqResolutionTextBox.Location = new System.Drawing.Point(114, 345);
            this.freqResolutionTextBox.Name = "freqResolutionTextBox";
            this.freqResolutionTextBox.ReadOnly = true;
            this.freqResolutionTextBox.Size = new System.Drawing.Size(100, 20);
            this.freqResolutionTextBox.TabIndex = 4;
            // 
            // maximumFrequencyNumericUpDown
            // 
            this.maximumFrequencyNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.maximumFrequencyNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maximumFrequencyNumericUpDown.Location = new System.Drawing.Point(13, 345);
            this.maximumFrequencyNumericUpDown.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.maximumFrequencyNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maximumFrequencyNumericUpDown.Name = "maximumFrequencyNumericUpDown";
            this.maximumFrequencyNumericUpDown.Size = new System.Drawing.Size(95, 20);
            this.maximumFrequencyNumericUpDown.TabIndex = 6;
            this.maximumFrequencyNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maximumFrequencyNumericUpDown.ValueChanged += new System.EventHandler(this.maximumFrequencyNumericUpDown_ValueChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(369, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Get config";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(288, 344);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Set config";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.networkInterfaceToolStripMenuItem,
            this.uDPStreamingPortToolStripMenuItem,
            this.sTMConfigurationIPToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // networkInterfaceToolStripMenuItem
            // 
            this.networkInterfaceToolStripMenuItem.Name = "networkInterfaceToolStripMenuItem";
            this.networkInterfaceToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.networkInterfaceToolStripMenuItem.Text = "Network interface";
            this.networkInterfaceToolStripMenuItem.DropDownOpening += new System.EventHandler(this.networkInterfaceToolStripMenuItem_DropDownOpening);
            // 
            // uDPStreamingPortToolStripMenuItem
            // 
            this.uDPStreamingPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.udpStreamingPortTextBox});
            this.uDPStreamingPortToolStripMenuItem.Name = "uDPStreamingPortToolStripMenuItem";
            this.uDPStreamingPortToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.uDPStreamingPortToolStripMenuItem.Text = "UDP streaming port";
            this.uDPStreamingPortToolStripMenuItem.DropDownOpening += new System.EventHandler(this.uDPStreamingPortToolStripMenuItem_DropDownOpening);
            // 
            // udpStreamingPortTextBox
            // 
            this.udpStreamingPortTextBox.Name = "udpStreamingPortTextBox";
            this.udpStreamingPortTextBox.Size = new System.Drawing.Size(100, 23);
            this.udpStreamingPortTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.udpStreamingPortTextBox_KeyDown);
            // 
            // sTMConfigurationIPToolStripMenuItem
            // 
            this.sTMConfigurationIPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stmConfigurationIpTextBox});
            this.sTMConfigurationIPToolStripMenuItem.Name = "sTMConfigurationIPToolStripMenuItem";
            this.sTMConfigurationIPToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.sTMConfigurationIPToolStripMenuItem.Text = "STM configuration IP";
            this.sTMConfigurationIPToolStripMenuItem.DropDownOpening += new System.EventHandler(this.sTMConfigurationIPToolStripMenuItem_DropDownOpening);
            // 
            // stmConfigurationIpTextBox
            // 
            this.stmConfigurationIpTextBox.Name = "stmConfigurationIpTextBox";
            this.stmConfigurationIpTextBox.Size = new System.Drawing.Size(100, 23);
            this.stmConfigurationIpTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stmConfigurationIpTextBox_KeyDown);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(463, 349);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(65, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 378);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.maximumFrequencyNumericUpDown);
            this.Controls.Add(this.freqResolutionTextBox);
            this.Controls.Add(this.amplitudePictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "STM32 Project";
            ((System.ComponentModel.ISupportInitialize)(this.amplitudePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumFrequencyNumericUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.PictureBox amplitudePictureBox;
        private System.Windows.Forms.TextBox freqResolutionTextBox;
        private System.Windows.Forms.NumericUpDown maximumFrequencyNumericUpDown;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uDPStreamingPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox udpStreamingPortTextBox;
        private System.Windows.Forms.ToolStripMenuItem sTMConfigurationIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox stmConfigurationIpTextBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

