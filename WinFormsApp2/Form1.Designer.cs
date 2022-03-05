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
            this.maxInputV = new System.Windows.Forms.TextBox();
            this.outputV = new System.Windows.Forms.TextBox();
            this.OutputCurrent = new System.Windows.Forms.TextBox();
            this.runningTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.inputCapLabel = new System.Windows.Forms.Label();
            this.inductorLabel = new System.Windows.Forms.Label();
            this.outCapLabel = new System.Windows.Forms.Label();
            this.solInCap = new System.Windows.Forms.Label();
            this.solInductor = new System.Windows.Forms.Label();
            this.solOutCap = new System.Windows.Forms.Label();
            this.srLabel = new System.Windows.Forms.Label();
            this.solSR = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.voltagerippleLabel = new System.Windows.Forms.Label();
            this.currentrippleLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.runTime = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.solListBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.mctsRadio = new System.Windows.Forms.RadioButton();
            this.dfsRadio = new System.Windows.Forms.RadioButton();
            this.priorityTrackBar = new System.Windows.Forms.TrackBar();
            this.iterLabel = new System.Windows.Forms.Label();
            this.mctsSolLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priorityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // minInputV
            // 
            this.minInputV.Location = new System.Drawing.Point(197, 12);
            this.minInputV.Name = "minInputV";
            this.minInputV.Size = new System.Drawing.Size(150, 31);
            this.minInputV.TabIndex = 0;
            // 
            // maxInputV
            // 
            this.maxInputV.Location = new System.Drawing.Point(197, 49);
            this.maxInputV.Name = "maxInputV";
            this.maxInputV.Size = new System.Drawing.Size(150, 31);
            this.maxInputV.TabIndex = 1;
            // 
            // outputV
            // 
            this.outputV.Location = new System.Drawing.Point(197, 86);
            this.outputV.Name = "outputV";
            this.outputV.Size = new System.Drawing.Size(150, 31);
            this.outputV.TabIndex = 2;
            // 
            // OutputCurrent
            // 
            this.OutputCurrent.Location = new System.Drawing.Point(197, 123);
            this.OutputCurrent.Name = "OutputCurrent";
            this.OutputCurrent.Size = new System.Drawing.Size(150, 31);
            this.OutputCurrent.TabIndex = 3;
            // 
            // runningTime
            // 
            this.runningTime.Location = new System.Drawing.Point(197, 160);
            this.runningTime.Name = "runningTime";
            this.runningTime.Size = new System.Drawing.Size(150, 31);
            this.runningTime.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input Voltage (min)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Input Voltage (max)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Output Voltage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output Current";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "V";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "V";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "V";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "A";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(186, 315);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(112, 34);
            this.runButton.TabIndex = 12;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputCapLabel
            // 
            this.inputCapLabel.AutoEllipsis = true;
            this.inputCapLabel.AutoSize = true;
            this.inputCapLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inputCapLabel.Location = new System.Drawing.Point(15, 479);
            this.inputCapLabel.MaximumSize = new System.Drawing.Size(430, 25);
            this.inputCapLabel.Name = "inputCapLabel";
            this.inputCapLabel.Size = new System.Drawing.Size(143, 25);
            this.inputCapLabel.TabIndex = 13;
            this.inputCapLabel.Text = "Input Capacitor: ";
            this.inputCapLabel.Click += new System.EventHandler(this.InputCapLabel_Click);
            // 
            // inductorLabel
            // 
            this.inductorLabel.AutoEllipsis = true;
            this.inductorLabel.AutoSize = true;
            this.inductorLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inductorLabel.Location = new System.Drawing.Point(15, 514);
            this.inductorLabel.MaximumSize = new System.Drawing.Size(430, 25);
            this.inductorLabel.Name = "inductorLabel";
            this.inductorLabel.Size = new System.Drawing.Size(88, 25);
            this.inductorLabel.TabIndex = 14;
            this.inductorLabel.Text = "Inductor: ";
            this.inductorLabel.Click += new System.EventHandler(this.InductorLabel_Click);
            // 
            // outCapLabel
            // 
            this.outCapLabel.AutoEllipsis = true;
            this.outCapLabel.AutoSize = true;
            this.outCapLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outCapLabel.Location = new System.Drawing.Point(15, 548);
            this.outCapLabel.MaximumSize = new System.Drawing.Size(430, 25);
            this.outCapLabel.Name = "outCapLabel";
            this.outCapLabel.Size = new System.Drawing.Size(158, 25);
            this.outCapLabel.TabIndex = 15;
            this.outCapLabel.Text = "Output Capacitor: ";
            this.outCapLabel.Click += new System.EventHandler(this.OutCapLabel_Click);
            // 
            // solInCap
            // 
            this.solInCap.Location = new System.Drawing.Point(0, 0);
            this.solInCap.Name = "solInCap";
            this.solInCap.Size = new System.Drawing.Size(100, 23);
            this.solInCap.TabIndex = 36;
            // 
            // solInductor
            // 
            this.solInductor.Location = new System.Drawing.Point(0, 0);
            this.solInductor.Name = "solInductor";
            this.solInductor.Size = new System.Drawing.Size(100, 23);
            this.solInductor.TabIndex = 35;
            // 
            // solOutCap
            // 
            this.solOutCap.Location = new System.Drawing.Point(0, 0);
            this.solOutCap.Name = "solOutCap";
            this.solOutCap.Size = new System.Drawing.Size(100, 23);
            this.solOutCap.TabIndex = 34;
            // 
            // srLabel
            // 
            this.srLabel.AutoEllipsis = true;
            this.srLabel.AutoSize = true;
            this.srLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.srLabel.Location = new System.Drawing.Point(15, 443);
            this.srLabel.MaximumSize = new System.Drawing.Size(430, 25);
            this.srLabel.Name = "srLabel";
            this.srLabel.Size = new System.Drawing.Size(178, 25);
            this.srLabel.TabIndex = 19;
            this.srLabel.Text = "Switching Regulator: ";
            this.srLabel.Click += new System.EventHandler(this.SRLabel_Click);
            // 
            // solSR
            // 
            this.solSR.Location = new System.Drawing.Point(0, 0);
            this.solSR.Name = "solSR";
            this.solSR.Size = new System.Drawing.Size(100, 23);
            this.solSR.TabIndex = 33;
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Location = new System.Drawing.Point(471, 479);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(52, 25);
            this.CostLabel.TabIndex = 21;
            this.CostLabel.Text = "Cost:";
            // 
            // voltagerippleLabel
            // 
            this.voltagerippleLabel.AutoSize = true;
            this.voltagerippleLabel.Location = new System.Drawing.Point(471, 514);
            this.voltagerippleLabel.Name = "voltagerippleLabel";
            this.voltagerippleLabel.Size = new System.Drawing.Size(131, 25);
            this.voltagerippleLabel.TabIndex = 22;
            this.voltagerippleLabel.Text = "Voltage Ripple:";
            // 
            // currentrippleLabel
            // 
            this.currentrippleLabel.AutoSize = true;
            this.currentrippleLabel.Location = new System.Drawing.Point(471, 548);
            this.currentrippleLabel.Name = "currentrippleLabel";
            this.currentrippleLabel.Size = new System.Drawing.Size(129, 25);
            this.currentrippleLabel.TabIndex = 23;
            this.currentrippleLabel.Text = "Current Ripple:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(471, 443);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(60, 25);
            this.scoreLabel.TabIndex = 24;
            this.scoreLabel.Text = "Score:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(321, 322);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(435, 21);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Visible = false;
            // 
            // runTime
            // 
            this.runTime.AutoSize = true;
            this.runTime.Location = new System.Drawing.Point(81, 163);
            this.runTime.Name = "runTime";
            this.runTime.Size = new System.Drawing.Size(108, 25);
            this.runTime.TabIndex = 27;
            this.runTime.Text = "Time to Run";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(353, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 25);
            this.label13.TabIndex = 28;
            this.label13.Text = "s";
            // 
            // solListBox
            // 
            this.solListBox.FormattingEnabled = true;
            this.solListBox.Location = new System.Drawing.Point(181, 400);
            this.solListBox.Name = "solListBox";
            this.solListBox.Size = new System.Drawing.Size(182, 33);
            this.solListBox.TabIndex = 29;
            this.solListBox.SelectedIndexChanged += new System.EventHandler(this.solListBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::WinFormsApp2.Properties.Resources.buckconverter_drawio__1_;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(386, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(445, 179);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 403);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(151, 25);
            this.label14.TabIndex = 31;
            this.label14.Text = "Solution to View: ";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(369, 403);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(230, 25);
            this.label16.TabIndex = 32;
            this.label16.Text = "(ranked from best to worst)";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(229, 25);
            this.label9.TabIndex = 39;
            this.label9.Text = "Priority (on a scale of 1-10):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(82, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 25);
            this.label10.TabIndex = 40;
            this.label10.Text = "Cost";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(369, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 25);
            this.label11.TabIndex = 41;
            this.label11.Text = "Performance";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // mctsRadio
            // 
            this.mctsRadio.AutoSize = true;
            this.mctsRadio.Location = new System.Drawing.Point(516, 227);
            this.mctsRadio.Name = "mctsRadio";
            this.mctsRadio.Size = new System.Drawing.Size(228, 29);
            this.mctsRadio.TabIndex = 42;
            this.mctsRadio.TabStop = true;
            this.mctsRadio.Text = "Monte Carlo Tree Search";
            this.mctsRadio.UseVisualStyleBackColor = true;
            this.mctsRadio.CheckedChanged += new System.EventHandler(this.mctsRadio_CheckedChanged);
            // 
            // dfsRadio
            // 
            this.dfsRadio.AutoSize = true;
            this.dfsRadio.Location = new System.Drawing.Point(516, 260);
            this.dfsRadio.Name = "dfsRadio";
            this.dfsRadio.Size = new System.Drawing.Size(176, 29);
            this.dfsRadio.TabIndex = 43;
            this.dfsRadio.TabStop = true;
            this.dfsRadio.Text = "Exhaustive Search";
            this.dfsRadio.UseVisualStyleBackColor = true;
            this.dfsRadio.CheckedChanged += new System.EventHandler(this.dfsRadio_CheckedChanged);
            // 
            // priorityTrackBar
            // 
            this.priorityTrackBar.Location = new System.Drawing.Point(123, 240);
            this.priorityTrackBar.Maximum = 11;
            this.priorityTrackBar.Minimum = 1;
            this.priorityTrackBar.Name = "priorityTrackBar";
            this.priorityTrackBar.Size = new System.Drawing.Size(250, 69);
            this.priorityTrackBar.TabIndex = 44;
            this.priorityTrackBar.Value = 1;
            // 
            // iterLabel
            // 
            this.iterLabel.AutoSize = true;
            this.iterLabel.Location = new System.Drawing.Point(24, 363);
            this.iterLabel.Name = "iterLabel";
            this.iterLabel.Size = new System.Drawing.Size(226, 25);
            this.iterLabel.TabIndex = 45;
            this.iterLabel.Text = "Possible designs searched: ";
            this.iterLabel.Click += new System.EventHandler(this.label12_Click_1);
            // 
            // mctsSolLabel
            // 
            this.mctsSolLabel.AutoSize = true;
            this.mctsSolLabel.Location = new System.Drawing.Point(439, 363);
            this.mctsSolLabel.Name = "mctsSolLabel";
            this.mctsSolLabel.Size = new System.Drawing.Size(154, 25);
            this.mctsSolLabel.TabIndex = 46;
            this.mctsSolLabel.Text = "Best MCTS Score: ";
            this.mctsSolLabel.Click += new System.EventHandler(this.label12_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(852, 589);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priorityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private TextBox minInputV;
        private TextBox maxInputV;
        private TextBox outputV;
        private TextBox OutputCurrent;
        private TextBox runningTime;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button runButton;
        private Label inputCapLabel;
        private Label inductorLabel;
        private Label outCapLabel;
        private Label solInCap;
        private Label solInductor;
        private Label solOutCap;
        private Label srLabel;
        private Label solSR;
        private Label CostLabel;
        private Label voltagerippleLabel;
        private Label currentrippleLabel;
        private Label scoreLabel;
        private ProgressBar progressBar1;
        private Label runTime;
        private Label label13;
        private ComboBox solListBox;
        private PictureBox pictureBox1;
        private Label label14;
        private Label label16;
        private Label label9;
        private Label label10;
        private Label label11;
        private RadioButton mctsRadio;
        private RadioButton dfsRadio;
        private TrackBar priorityTrackBar;
        private Label iterLabel;
        private Label mctsSolLabel;
    }
}