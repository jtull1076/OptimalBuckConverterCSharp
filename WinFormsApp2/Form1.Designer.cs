namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.minInputV = new System.Windows.Forms.TextBox();
            this.iterLabel = new System.Windows.Forms.Label();
            this.priorityTrackBar = new System.Windows.Forms.TrackBar();
            this.dfsRadio = new System.Windows.Forms.RadioButton();
            this.mctsRadio = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.solListBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.runTime = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.currentrippleLabel = new System.Windows.Forms.Label();
            this.voltagerippleLabel = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.mctsSolLabel = new System.Windows.Forms.Label();
            this.srLabel = new System.Windows.Forms.Label();
            this.solOutCap = new System.Windows.Forms.Label();
            this.solInductor = new System.Windows.Forms.Label();
            this.solInCap = new System.Windows.Forms.Label();
            this.outCapLabel = new System.Windows.Forms.Label();
            this.inductorLabel = new System.Windows.Forms.Label();
            this.inputCapLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.runningTime = new System.Windows.Forms.TextBox();
            this.OutputCurrent = new System.Windows.Forms.TextBox();
            this.outputV = new System.Windows.Forms.TextBox();
            this.maxInputV = new System.Windows.Forms.TextBox();
            this.solSR = new System.Windows.Forms.Label();
            this.chipListButton = new System.Windows.Forms.Button();
            this.chipListText = new System.Windows.Forms.TextBox();
            this.inductorListText = new System.Windows.Forms.TextBox();
            this.inductorListButton = new System.Windows.Forms.Button();
            this.capacitorListText = new System.Windows.Forms.TextBox();
            this.capacitorListButton = new System.Windows.Forms.Button();
            this.chipListLabel = new System.Windows.Forms.Label();
            this.inductorListLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.priorityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // minInputV
            // 
            this.minInputV.Location = new System.Drawing.Point(209, 153);
            this.minInputV.Name = "minInputV";
            this.minInputV.Size = new System.Drawing.Size(150, 31);
            this.minInputV.TabIndex = 0;
            // 
            // iterLabel
            // 
            this.iterLabel.AutoSize = true;
            this.iterLabel.Location = new System.Drawing.Point(36, 504);
            this.iterLabel.Name = "iterLabel";
            this.iterLabel.Size = new System.Drawing.Size(226, 25);
            this.iterLabel.TabIndex = 45;
            this.iterLabel.Text = "Possible designs searched: ";
            this.iterLabel.Click += new System.EventHandler(this.label12_Click_1);
            // 
            // priorityTrackBar
            // 
            this.priorityTrackBar.Location = new System.Drawing.Point(135, 381);
            this.priorityTrackBar.Maximum = 11;
            this.priorityTrackBar.Minimum = 1;
            this.priorityTrackBar.Name = "priorityTrackBar";
            this.priorityTrackBar.Size = new System.Drawing.Size(250, 69);
            this.priorityTrackBar.TabIndex = 44;
            this.priorityTrackBar.Value = 1;
            // 
            // dfsRadio
            // 
            this.dfsRadio.AutoSize = true;
            this.dfsRadio.Location = new System.Drawing.Point(528, 401);
            this.dfsRadio.Name = "dfsRadio";
            this.dfsRadio.Size = new System.Drawing.Size(176, 29);
            this.dfsRadio.TabIndex = 43;
            this.dfsRadio.TabStop = true;
            this.dfsRadio.Text = "Exhaustive Search";
            this.dfsRadio.UseVisualStyleBackColor = true;
            this.dfsRadio.CheckedChanged += new System.EventHandler(this.dfsRadio_CheckedChanged);
            // 
            // mctsRadio
            // 
            this.mctsRadio.AutoSize = true;
            this.mctsRadio.Location = new System.Drawing.Point(528, 368);
            this.mctsRadio.Name = "mctsRadio";
            this.mctsRadio.Size = new System.Drawing.Size(228, 29);
            this.mctsRadio.TabIndex = 42;
            this.mctsRadio.TabStop = true;
            this.mctsRadio.Text = "Monte Carlo Tree Search";
            this.mctsRadio.UseVisualStyleBackColor = true;
            this.mctsRadio.CheckedChanged += new System.EventHandler(this.mctsRadio_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(381, 383);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 25);
            this.label11.TabIndex = 41;
            this.label11.Text = "Performance";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(94, 385);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 25);
            this.label10.TabIndex = 40;
            this.label10.Text = "Cost";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(229, 25);
            this.label9.TabIndex = 39;
            this.label9.Text = "Priority (on a scale of 1-10):";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(381, 544);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(230, 25);
            this.label16.TabIndex = 32;
            this.label16.Text = "(ranked from best to worst)";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 544);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(151, 25);
            this.label14.TabIndex = 31;
            this.label14.Text = "Solution to View: ";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::WinFormsApp2.Properties.Resources.buckconverter_drawio__1_;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(398, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(485, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // solListBox
            // 
            this.solListBox.FormattingEnabled = true;
            this.solListBox.Location = new System.Drawing.Point(193, 541);
            this.solListBox.Name = "solListBox";
            this.solListBox.Size = new System.Drawing.Size(182, 33);
            this.solListBox.TabIndex = 29;
            this.solListBox.SelectedIndexChanged += new System.EventHandler(this.solListBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(365, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 25);
            this.label13.TabIndex = 28;
            this.label13.Text = "s";
            // 
            // runTime
            // 
            this.runTime.AutoSize = true;
            this.runTime.Location = new System.Drawing.Point(93, 304);
            this.runTime.Name = "runTime";
            this.runTime.Size = new System.Drawing.Size(108, 25);
            this.runTime.TabIndex = 27;
            this.runTime.Text = "Time to Run";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(333, 463);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(435, 21);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(483, 584);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(60, 25);
            this.scoreLabel.TabIndex = 24;
            this.scoreLabel.Text = "Score:";
            // 
            // currentrippleLabel
            // 
            this.currentrippleLabel.AutoSize = true;
            this.currentrippleLabel.Location = new System.Drawing.Point(483, 689);
            this.currentrippleLabel.Name = "currentrippleLabel";
            this.currentrippleLabel.Size = new System.Drawing.Size(129, 25);
            this.currentrippleLabel.TabIndex = 23;
            this.currentrippleLabel.Text = "Current Ripple:";
            // 
            // voltagerippleLabel
            // 
            this.voltagerippleLabel.AutoSize = true;
            this.voltagerippleLabel.Location = new System.Drawing.Point(483, 655);
            this.voltagerippleLabel.Name = "voltagerippleLabel";
            this.voltagerippleLabel.Size = new System.Drawing.Size(131, 25);
            this.voltagerippleLabel.TabIndex = 22;
            this.voltagerippleLabel.Text = "Voltage Ripple:";
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Location = new System.Drawing.Point(483, 620);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(52, 25);
            this.CostLabel.TabIndex = 21;
            this.CostLabel.Text = "Cost:";
            // 
            // mctsSolLabel
            // 
            this.mctsSolLabel.AutoSize = true;
            this.mctsSolLabel.Location = new System.Drawing.Point(451, 504);
            this.mctsSolLabel.Name = "mctsSolLabel";
            this.mctsSolLabel.Size = new System.Drawing.Size(154, 25);
            this.mctsSolLabel.TabIndex = 46;
            this.mctsSolLabel.Text = "Best MCTS Score: ";
            this.mctsSolLabel.Click += new System.EventHandler(this.label12_Click_2);
            // 
            // srLabel
            // 
            this.srLabel.AutoEllipsis = true;
            this.srLabel.AutoSize = true;
            this.srLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.srLabel.Location = new System.Drawing.Point(27, 584);
            this.srLabel.MaximumSize = new System.Drawing.Size(430, 25);
            this.srLabel.Name = "srLabel";
            this.srLabel.Size = new System.Drawing.Size(178, 25);
            this.srLabel.TabIndex = 19;
            this.srLabel.Text = "Switching Regulator: ";
            this.srLabel.Click += new System.EventHandler(this.SRLabel_Click);
            // 
            // solOutCap
            // 
            this.solOutCap.Location = new System.Drawing.Point(12, 141);
            this.solOutCap.Name = "solOutCap";
            this.solOutCap.Size = new System.Drawing.Size(100, 23);
            this.solOutCap.TabIndex = 34;
            // 
            // solInductor
            // 
            this.solInductor.Location = new System.Drawing.Point(12, 141);
            this.solInductor.Name = "solInductor";
            this.solInductor.Size = new System.Drawing.Size(100, 23);
            this.solInductor.TabIndex = 35;
            // 
            // solInCap
            // 
            this.solInCap.Location = new System.Drawing.Point(12, 141);
            this.solInCap.Name = "solInCap";
            this.solInCap.Size = new System.Drawing.Size(100, 23);
            this.solInCap.TabIndex = 36;
            // 
            // outCapLabel
            // 
            this.outCapLabel.AutoEllipsis = true;
            this.outCapLabel.AutoSize = true;
            this.outCapLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outCapLabel.Location = new System.Drawing.Point(27, 689);
            this.outCapLabel.MaximumSize = new System.Drawing.Size(430, 25);
            this.outCapLabel.Name = "outCapLabel";
            this.outCapLabel.Size = new System.Drawing.Size(158, 25);
            this.outCapLabel.TabIndex = 15;
            this.outCapLabel.Text = "Output Capacitor: ";
            this.outCapLabel.Click += new System.EventHandler(this.OutCapLabel_Click);
            // 
            // inductorLabel
            // 
            this.inductorLabel.AutoEllipsis = true;
            this.inductorLabel.AutoSize = true;
            this.inductorLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inductorLabel.Location = new System.Drawing.Point(27, 655);
            this.inductorLabel.MaximumSize = new System.Drawing.Size(430, 25);
            this.inductorLabel.Name = "inductorLabel";
            this.inductorLabel.Size = new System.Drawing.Size(88, 25);
            this.inductorLabel.TabIndex = 14;
            this.inductorLabel.Text = "Inductor: ";
            this.inductorLabel.Click += new System.EventHandler(this.InductorLabel_Click);
            // 
            // inputCapLabel
            // 
            this.inputCapLabel.AutoEllipsis = true;
            this.inputCapLabel.AutoSize = true;
            this.inputCapLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inputCapLabel.Location = new System.Drawing.Point(27, 620);
            this.inputCapLabel.MaximumSize = new System.Drawing.Size(430, 25);
            this.inputCapLabel.Name = "inputCapLabel";
            this.inputCapLabel.Size = new System.Drawing.Size(143, 25);
            this.inputCapLabel.TabIndex = 13;
            this.inputCapLabel.Text = "Input Capacitor: ";
            this.inputCapLabel.Click += new System.EventHandler(this.InputCapLabel_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(198, 456);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(112, 34);
            this.runButton.TabIndex = 12;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(365, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "V";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(365, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "V";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "V";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output Current";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Output Voltage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Input Voltage (max)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input Voltage (min)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // runningTime
            // 
            this.runningTime.Location = new System.Drawing.Point(209, 301);
            this.runningTime.Name = "runningTime";
            this.runningTime.Size = new System.Drawing.Size(150, 31);
            this.runningTime.TabIndex = 5;
            // 
            // OutputCurrent
            // 
            this.OutputCurrent.Location = new System.Drawing.Point(209, 264);
            this.OutputCurrent.Name = "OutputCurrent";
            this.OutputCurrent.Size = new System.Drawing.Size(150, 31);
            this.OutputCurrent.TabIndex = 3;
            // 
            // outputV
            // 
            this.outputV.Location = new System.Drawing.Point(209, 227);
            this.outputV.Name = "outputV";
            this.outputV.Size = new System.Drawing.Size(150, 31);
            this.outputV.TabIndex = 2;
            // 
            // maxInputV
            // 
            this.maxInputV.Location = new System.Drawing.Point(209, 190);
            this.maxInputV.Name = "maxInputV";
            this.maxInputV.Size = new System.Drawing.Size(150, 31);
            this.maxInputV.TabIndex = 1;
            // 
            // solSR
            // 
            this.solSR.Location = new System.Drawing.Point(12, 141);
            this.solSR.Name = "solSR";
            this.solSR.Size = new System.Drawing.Size(100, 23);
            this.solSR.TabIndex = 33;
            // 
            // chipListButton
            // 
            this.chipListButton.Location = new System.Drawing.Point(588, 22);
            this.chipListButton.Name = "chipListButton";
            this.chipListButton.Size = new System.Drawing.Size(112, 34);
            this.chipListButton.TabIndex = 47;
            this.chipListButton.Text = "Browse";
            this.chipListButton.UseVisualStyleBackColor = true;
            this.chipListButton.Click += new System.EventHandler(this.chipListButton_Click);
            // 
            // chipListText
            // 
            this.chipListText.Location = new System.Drawing.Point(215, 24);
            this.chipListText.Name = "chipListText";
            this.chipListText.Size = new System.Drawing.Size(351, 31);
            this.chipListText.TabIndex = 48;
            // 
            // inductorListText
            // 
            this.inductorListText.Location = new System.Drawing.Point(215, 61);
            this.inductorListText.Name = "inductorListText";
            this.inductorListText.Size = new System.Drawing.Size(351, 31);
            this.inductorListText.TabIndex = 50;
            // 
            // inductorListButton
            // 
            this.inductorListButton.Location = new System.Drawing.Point(588, 59);
            this.inductorListButton.Name = "inductorListButton";
            this.inductorListButton.Size = new System.Drawing.Size(112, 34);
            this.inductorListButton.TabIndex = 49;
            this.inductorListButton.Text = "Browse";
            this.inductorListButton.UseVisualStyleBackColor = true;
            this.inductorListButton.Click += new System.EventHandler(this.inductorListButton_Click);
            // 
            // capacitorListText
            // 
            this.capacitorListText.Location = new System.Drawing.Point(215, 98);
            this.capacitorListText.Name = "capacitorListText";
            this.capacitorListText.Size = new System.Drawing.Size(351, 31);
            this.capacitorListText.TabIndex = 52;
            // 
            // capacitorListButton
            // 
            this.capacitorListButton.Location = new System.Drawing.Point(588, 96);
            this.capacitorListButton.Name = "capacitorListButton";
            this.capacitorListButton.Size = new System.Drawing.Size(112, 34);
            this.capacitorListButton.TabIndex = 51;
            this.capacitorListButton.Text = "Browse";
            this.capacitorListButton.UseVisualStyleBackColor = true;
            this.capacitorListButton.Click += new System.EventHandler(this.capacitorListButton_Click);
            // 
            // chipListLabel
            // 
            this.chipListLabel.AutoSize = true;
            this.chipListLabel.Location = new System.Drawing.Point(70, 27);
            this.chipListLabel.Name = "chipListLabel";
            this.chipListLabel.Size = new System.Drawing.Size(139, 25);
            this.chipListLabel.TabIndex = 53;
            this.chipListLabel.Text = "List of Buck IC\'s:";
            // 
            // inductorListLabel
            // 
            this.inductorListLabel.AutoSize = true;
            this.inductorListLabel.Location = new System.Drawing.Point(65, 64);
            this.inductorListLabel.Name = "inductorListLabel";
            this.inductorListLabel.Size = new System.Drawing.Size(144, 25);
            this.inductorListLabel.TabIndex = 54;
            this.inductorListLabel.Text = "List of Inductors:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(57, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 25);
            this.label12.TabIndex = 55;
            this.label12.Text = "List of Capacitors:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(911, 736);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.inductorListLabel);
            this.Controls.Add(this.chipListLabel);
            this.Controls.Add(this.capacitorListText);
            this.Controls.Add(this.capacitorListButton);
            this.Controls.Add(this.inductorListText);
            this.Controls.Add(this.inductorListButton);
            this.Controls.Add(this.chipListText);
            this.Controls.Add(this.chipListButton);
            this.Controls.Add(this.mctsSolLabel);
            this.Controls.Add(this.iterLabel);
            this.Controls.Add(this.priorityTrackBar);
            this.Controls.Add(this.dfsRadio);
            this.Controls.Add(this.mctsRadio);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.solListBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.runTime);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.currentrippleLabel);
            this.Controls.Add(this.voltagerippleLabel);
            this.Controls.Add(this.CostLabel);
            this.Controls.Add(this.solSR);
            this.Controls.Add(this.srLabel);
            this.Controls.Add(this.solOutCap);
            this.Controls.Add(this.solInductor);
            this.Controls.Add(this.solInCap);
            this.Controls.Add(this.outCapLabel);
            this.Controls.Add(this.inductorLabel);
            this.Controls.Add(this.inputCapLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputCurrent);
            this.Controls.Add(this.outputV);
            this.Controls.Add(this.maxInputV);
            this.Controls.Add(this.minInputV);
            this.Controls.Add(this.runningTime);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.priorityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void capacitorListButton_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    capacitorListText.Text = filePath;
                }
            }
        }

        private void inductorListButton_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    inductorListText.Text = filePath;
                }
            }
        }

        private void chipListButton_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    chipListText.Text = filePath;
                }
            }
        }


        #endregion

        private TextBox minInputV;
        private Label iterLabel;
        private TrackBar priorityTrackBar;
        private RadioButton dfsRadio;
        private RadioButton mctsRadio;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label16;
        private Label label14;
        private PictureBox pictureBox1;
        private ComboBox solListBox;
        private Label label13;
        private Label runTime;
        private ProgressBar progressBar1;
        private Label scoreLabel;
        private Label currentrippleLabel;
        private Label voltagerippleLabel;
        private Label CostLabel;
        private Label mctsSolLabel;
        private Label srLabel;
        private Label solOutCap;
        private Label solInductor;
        private Label solInCap;
        private Label outCapLabel;
        private Label inductorLabel;
        private Label inputCapLabel;
        private Button runButton;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox runningTime;
        private TextBox OutputCurrent;
        private TextBox outputV;
        private TextBox maxInputV;
        private Label solSR;
        private Button chipListButton;
        private TextBox chipListText;
        private TextBox inductorListText;
        private Button inductorListButton;
        private TextBox capacitorListText;
        private Button capacitorListButton;
        private Label chipListLabel;
        private Label inductorListLabel;
        private Label label12;
        private OpenFileDialog openFileDialog1;
    }
}