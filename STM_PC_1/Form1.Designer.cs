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
            this.maximumFrequencyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.getConfigButton = new System.Windows.Forms.Button();
            this.setConfigButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.endpointTextBox = new System.Windows.Forms.TextBox();
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.freqTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.windowTypeComboBox = new System.Windows.Forms.ComboBox();
            this.maxAmpValScrollBar = new System.Windows.Forms.HScrollBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.amplitudePictureBox.Location = new System.Drawing.Point(12, 27);
            this.amplitudePictureBox.Name = "amplitudePictureBox";
            this.amplitudePictureBox.Size = new System.Drawing.Size(227, 251);
            this.amplitudePictureBox.TabIndex = 2;
            this.amplitudePictureBox.TabStop = false;
            // 
            // maximumFrequencyNumericUpDown
            // 
            this.maximumFrequencyNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumFrequencyNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maximumFrequencyNumericUpDown.Location = new System.Drawing.Point(139, 416);
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
            this.maximumFrequencyNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.maximumFrequencyNumericUpDown.TabIndex = 6;
            this.maximumFrequencyNumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.maximumFrequencyNumericUpDown.ValueChanged += new System.EventHandler(this.maximumFrequencyNumericUpDown_ValueChanged);
            // 
            // getConfigButton
            // 
            this.getConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.getConfigButton.Location = new System.Drawing.Point(12, 487);
            this.getConfigButton.Name = "getConfigButton";
            this.getConfigButton.Size = new System.Drawing.Size(100, 23);
            this.getConfigButton.TabIndex = 8;
            this.getConfigButton.Text = "Get config";
            this.getConfigButton.UseVisualStyleBackColor = true;
            this.getConfigButton.Click += new System.EventHandler(this.getConfigButton_Click);
            // 
            // setConfigButton
            // 
            this.setConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setConfigButton.Location = new System.Drawing.Point(139, 487);
            this.setConfigButton.Name = "setConfigButton";
            this.setConfigButton.Size = new System.Drawing.Size(102, 23);
            this.setConfigButton.TabIndex = 9;
            this.setConfigButton.Text = "Set config";
            this.setConfigButton.UseVisualStyleBackColor = true;
            this.setConfigButton.Click += new System.EventHandler(this.setConfigButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(247, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.networkInterfaceToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // networkInterfaceToolStripMenuItem
            // 
            this.networkInterfaceToolStripMenuItem.Name = "networkInterfaceToolStripMenuItem";
            this.networkInterfaceToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.networkInterfaceToolStripMenuItem.Text = "Network interface";
            this.networkInterfaceToolStripMenuItem.DropDownOpening += new System.EventHandler(this.networkInterfaceToolStripMenuItem_DropDownOpening);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Endpoint IP";
            // 
            // endpointTextBox
            // 
            this.endpointTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.endpointTextBox.Location = new System.Drawing.Point(139, 284);
            this.endpointTextBox.Name = "endpointTextBox";
            this.endpointTextBox.Size = new System.Drawing.Size(100, 20);
            this.endpointTextBox.TabIndex = 13;
            // 
            // delayTextBox
            // 
            this.delayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delayTextBox.Location = new System.Drawing.Point(139, 363);
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(100, 20);
            this.delayTextBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Processing delay [ms]";
            // 
            // freqTextBox
            // 
            this.freqTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.freqTextBox.Location = new System.Drawing.Point(139, 337);
            this.freqTextBox.Name = "freqTextBox";
            this.freqTextBox.Size = new System.Drawing.Size(100, 20);
            this.freqTextBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Sampling frequency [Hz]";
            // 
            // portTextBox
            // 
            this.portTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.portTextBox.Location = new System.Drawing.Point(139, 310);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Endpoint port";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Signal window";
            // 
            // windowTypeComboBox
            // 
            this.windowTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.windowTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowTypeComboBox.FormattingEnabled = true;
            this.windowTypeComboBox.Items.AddRange(new object[] {
            "Rectangle",
            "Hann",
            "Flat top"});
            this.windowTypeComboBox.Location = new System.Drawing.Point(139, 389);
            this.windowTypeComboBox.Name = "windowTypeComboBox";
            this.windowTypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.windowTypeComboBox.TabIndex = 23;
            // 
            // maxAmpValScrollBar
            // 
            this.maxAmpValScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxAmpValScrollBar.Location = new System.Drawing.Point(12, 461);
            this.maxAmpValScrollBar.Maximum = 90000000;
            this.maxAmpValScrollBar.Minimum = 1000000;
            this.maxAmpValScrollBar.Name = "maxAmpValScrollBar";
            this.maxAmpValScrollBar.Size = new System.Drawing.Size(227, 14);
            this.maxAmpValScrollBar.TabIndex = 24;
            this.maxAmpValScrollBar.Value = 15000000;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Maximum frequency [Hz]";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Amplitude limit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 519);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxAmpValScrollBar);
            this.Controls.Add(this.windowTypeComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.freqTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.delayTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endpointTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setConfigButton);
            this.Controls.Add(this.getConfigButton);
            this.Controls.Add(this.maximumFrequencyNumericUpDown);
            this.Controls.Add(this.amplitudePictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(263, 320);
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
        private System.Windows.Forms.NumericUpDown maximumFrequencyNumericUpDown;
        private System.Windows.Forms.Button getConfigButton;
        private System.Windows.Forms.Button setConfigButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkInterfaceToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox endpointTextBox;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox freqTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox windowTypeComboBox;
        private System.Windows.Forms.HScrollBar maxAmpValScrollBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}

