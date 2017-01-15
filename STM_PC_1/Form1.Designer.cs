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
            this.label1 = new System.Windows.Forms.Label();
            this.endpointTextBox = new System.Windows.Forms.TextBox();
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.freqTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.windowTypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumFrequencyNumericUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // amplitudePictureBox
            // 
            this.amplitudePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.amplitudePictureBox.Location = new System.Drawing.Point(12, 30);
            this.amplitudePictureBox.Name = "amplitudePictureBox";
            this.amplitudePictureBox.Size = new System.Drawing.Size(401, 196);
            this.amplitudePictureBox.TabIndex = 2;
            this.amplitudePictureBox.TabStop = false;
            // 
            // freqResolutionTextBox
            // 
            this.freqResolutionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.freqResolutionTextBox.Location = new System.Drawing.Point(114, 242);
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
            this.maximumFrequencyNumericUpDown.Location = new System.Drawing.Point(13, 242);
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
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(484, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Get config";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(484, 184);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
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
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Endpoint";
            // 
            // endpointTextBox
            // 
            this.endpointTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endpointTextBox.Location = new System.Drawing.Point(484, 27);
            this.endpointTextBox.Name = "endpointTextBox";
            this.endpointTextBox.Size = new System.Drawing.Size(100, 20);
            this.endpointTextBox.TabIndex = 13;
            this.endpointTextBox.TextChanged += new System.EventHandler(this.endpointTextBox_TextChanged);
            // 
            // delayTextBox
            // 
            this.delayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delayTextBox.Location = new System.Drawing.Point(484, 53);
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(100, 20);
            this.delayTextBox.TabIndex = 15;
            this.delayTextBox.TextChanged += new System.EventHandler(this.delayTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Delay";
            // 
            // freqTextBox
            // 
            this.freqTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.freqTextBox.Location = new System.Drawing.Point(484, 79);
            this.freqTextBox.Name = "freqTextBox";
            this.freqTextBox.Size = new System.Drawing.Size(100, 20);
            this.freqTextBox.TabIndex = 17;
            this.freqTextBox.TextChanged += new System.EventHandler(this.freqTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Freq";
            // 
            // portTextBox
            // 
            this.portTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.portTextBox.Location = new System.Drawing.Point(484, 105);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 19;
            this.portTextBox.TextChanged += new System.EventHandler(this.portTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(419, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Port";
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeTextBox.Location = new System.Drawing.Point(484, 131);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.sizeTextBox.TabIndex = 21;
            this.sizeTextBox.TextChanged += new System.EventHandler(this.sizeTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Size";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(419, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Wind";
            // 
            // windowTypeComboBox
            // 
            this.windowTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowTypeComboBox.FormattingEnabled = true;
            this.windowTypeComboBox.Items.AddRange(new object[] {
            "RECTANGLE",
            "HANN",
            "FLAT_TOP"});
            this.windowTypeComboBox.Location = new System.Drawing.Point(484, 157);
            this.windowTypeComboBox.Name = "windowTypeComboBox";
            this.windowTypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.windowTypeComboBox.TabIndex = 23;
            this.windowTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 275);
            this.Controls.Add(this.windowTypeComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sizeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.freqTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.delayTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endpointTextBox);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox endpointTextBox;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox freqTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox windowTypeComboBox;
    }
}

