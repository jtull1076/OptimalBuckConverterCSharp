using System.ComponentModel;
using System.Diagnostics;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private readonly System.ComponentModel.BackgroundWorker backgroundWorker1 = new();

        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            priorityTrackBar.Value = 6;
            chipListText.Text = @"C:\";
            inductorListText.Text = @"C:\";
            capacitorListText.Text = @"C:\";
        }

        /// <summary>
        /// Initialize an instance of the BackgroundWorker class, backgroundWorker1
        /// </summary>
        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);   // handles the bulk task
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);  // handles task completion
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);     // handles the progress bar update
        }

        /// <summary>
        /// Updates the progress bar during MCTS with percentage value <paramref name="e"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Handles the results of the background task (i.e. the result of the tree search)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            // Returns the error message if there is one
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }


            // Stores the result of the  tree search
            Solution solution = (Solution)e.Result;
            List<Node> solList = solution.solList;
            int iterationCount = solution.iterCount;


            // If there are no solutions in the result, then there were no solutions; inform user and reset inputs. 
            if (solList.Count == 0)
            {
                MessageBox.Show("No solution found: try new search criteria");

                CostLabel.Text = "Cost: ";
                scoreLabel.Text = "Score: ";
                voltagerippleLabel.Text = "Voltage Ripple: ";
                currentrippleLabel.Text = "Current Ripple: ";
                inputCapLabel.Text = "Input Capacitor: ";
                outCapLabel.Text = "Output Capacitor: ";
                inductorLabel.Text = "Inductor: ";
                srLabel.Text = "Switching Regulator: ";

            }
            else
            {
                // print solution space count
                iterLabel.Text = "Possible designs searched: " + iterationCount.ToString("N0");

                List<Node> sortedsolList = solList.OrderByDescending(s => s.score).ToList();    // sorts the list of solutions by descending
                Node bestNode = sortedsolList[0];   // get the best node
                List<Node> ssLcopy = new(sortedsolList);    // create a copy of solution list
                

                if (backgroundWorker1.WorkerReportsProgress == true)
                {
                    GlobalMCTS.solution = bestNode;
                    GlobalMCTS.iterCount = solution.iterCount;
                    mctsSolLabel.Text = "Best MCTS Score: " + bestNode.score.ToString();
                }

                // remove bad solutions from list
                foreach (Node sol in ssLcopy)
                {
                    if (sol.score < 0.5 * bestNode.score)
                    {
                        sortedsolList.Remove(sol);
                    }
                }

                // create names for each solution (1 is best, N is least-good)
                string[] solNames = new string[sortedsolList.Count];
                for (int i = 0; i < solNames.Length; i++)
                {
                    solNames[i] = "Solution #" + (i + 1).ToString();
                }

                // associates the names with the solutions and add to dropdown list
                var dropdownSolList = new List<KeyValuePair<string, Node>>();
                for (int i = 0; i < sortedsolList.Count; i++)
                {
                    dropdownSolList.Add(new KeyValuePair<string, Node>(solNames[i], sortedsolList[i]));
                }

                // setup for dropdown list
                solListBox.DataSource = dropdownSolList;
                solListBox.DisplayMember = "Key";
                solListBox.ValueMember = "Value";

                // show best solution
                outCapLabel.Text = "Output Capacitor: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.partNumber;
                inputCapLabel.Text = "Input Capacitor: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.partNumber;
                inductorLabel.Text = "Inductor: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.partNumber;
                srLabel.Text = "Switching Regulator: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.partNumber;

                // formatting for solution properties:...
                string vrUnitString;
                string crUnitString;
                float vrMultiplier;
                float crMultiplier;
                // ... voltage ripple
                if (sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple > 1)
                {
                    vrUnitString = "V";
                    vrMultiplier = 1;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple > 0.001F)
                {
                    vrUnitString = "mV";
                    vrMultiplier = 1000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple > 0.000001F)
                {
                    vrUnitString = "μV";
                    vrMultiplier = 1000000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple > 0.000000001F)
                {
                    vrUnitString = "nV";
                    vrMultiplier = 1000000000;
                }
                else
                {
                    vrUnitString = "V";
                    vrMultiplier = 1;
                }
                // ... current ripple
                if (sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple > 1)
                {
                    crUnitString = "A";
                    crMultiplier = 1;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple > 0.001F)
                {
                    crUnitString = "mA";
                    crMultiplier = 1000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple > 0.000001F)
                {
                    crUnitString = "μA";
                    crMultiplier = 1000000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple > 0.000000001F)
                {
                    crUnitString = "nA";
                    crMultiplier = 1000000000;
                }
                else
                {
                    crUnitString = "A";
                    crMultiplier = 1;
                }
                // print solution properties
                CostLabel.Text = "Cost: $" + sortedsolList[solListBox.SelectedIndex].nodeComponents.cost;
                scoreLabel.Text = "Score: " + sortedsolList[solListBox.SelectedIndex].score;
                voltagerippleLabel.Text = "Voltage Ripple: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple * vrMultiplier + " " + vrUnitString;
                currentrippleLabel.Text = "Current Ripple: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple * crMultiplier + " " + crUnitString;
            }

            // hide progress bar
            progressBar1.Visible = false;
        }

        /// <summary>
        /// Handles the bulk of the work for the tree searches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object? sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            Solution solution = new();
            

            // run MCTS or DFS based on user input
            if (mctsRadio.Checked)
            {
                solution = MCTS(worker, e);
            }
            else if (dfsRadio.Checked)
            {
                solution = DFS(worker, e);
            }

            e.Result = solution;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Start button event which runs tree search, assuming all fields are valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Ignore button press if background task is running
            if (backgroundWorker1.IsBusy == true)
            {
                return;
            }

            // Below handles invalid inputs
            string String1 = minInputV.Text;
            string String2 = maxInputV.Text;
            string String3 = outputV.Text;
            string String4 = OutputCurrent.Text;
            string String5 = runningTime.Text;
            string String6 = chipListText.Text;
            string String7 = inductorListText.Text;
            string String8 = capacitorListText.Text;
            // ... only whitespace
            if (String1.Trim() == "" || String2.Trim() == "" || String3.Trim() == "" || String4.Trim() == "")
            {
                MessageBox.Show("Not enough values given.");
                return;
            }
            if (chipListText.Text == "" || !File.Exists(chipListText.Text))
            {
                MessageBox.Show("No IC list given.");
                chipListText.Text = "";
                return;
            }
            if (inductorListText.Text == "" || !File.Exists(inductorListText.Text))
            {
                MessageBox.Show("No inductor list given.");
                inductorListText.Text = "";
                return;
            }
            if (capacitorListText.Text == "" || !File.Exists(capacitorListText.Text))
            {
                MessageBox.Show("No capacitor list given.");
                capacitorListText.Text = "";
                return;
            }
            // ... non-numbers in input
            for (int i = 0; i < String1.Length; i++)
            {
                if (!char.IsNumber(String1[i]) && String1[i] != '.')
                {
                    MessageBox.Show("Please enter a valid number.");
                    minInputV.Text = "";
                    return;
                }
            }
            for (int i = 0; i < String2.Length; i++)
            {
                if (!char.IsNumber(String2[i]) && String2[i] != '.')
                {
                    MessageBox.Show("Please enter a valid number.");
                    maxInputV.Text = "";
                    return;
                }
            }
            for (int i = 0; i < String3.Length; i++)
            {
                if (!char.IsNumber(String3[i]) && String3[i] != '.')
                {
                    MessageBox.Show("Please enter a valid number.");
                    outputV.Text = "";
                    return;
                }
            }
            for (int i = 0; i < String4.Length; i++)
            {
                if (!char.IsNumber(String4[i]) && String4[i] != '.')
                {
                    MessageBox.Show("Please enter a valid number.");
                    OutputCurrent.Text = "";
                    return;
                }
            }
            if (!mctsRadio.Checked && !dfsRadio.Checked)
            {
                MessageBox.Show("Please select a search method.");
                return;
            }
            for (int i = 0; i < String5.Length; i++)
            {
                if (mctsRadio.Checked)
                {
                    if (!char.IsNumber(String5[i]) && String5[i] != '.')
                    {
                        MessageBox.Show("Please enter a valid number.");
                        runningTime.Text = "";
                        return;
                    }
                }
                else
                {
                    if (!String5.Equals("N/A"))
                    {
                        if (!char.IsNumber(String5[i]) && String5[i] != '.')
                        {
                            MessageBox.Show("Please enter a valid number.");
                            runningTime.Text = "";
                            return;
                        }
                    }
                }
                
            }
            

            

            // store user requirements in Requirements class
            Requirements.minInputVoltage = float.Parse(minInputV.Text);
            Requirements.maxInputVoltage = float.Parse(maxInputV.Text);
            Requirements.outputVoltage = float.Parse(outputV.Text);
            Requirements.outputCurrent = float.Parse(OutputCurrent.Text);
            Requirements.performanceWeight = Math.Abs(1-priorityTrackBar.Value);
            Requirements.costWeight = Math.Abs(11-priorityTrackBar.Value);
            Requirements.chipFile = chipListText.Text;
            Requirements.inductorFile = inductorListText.Text;
            Requirements.capacitorFile = capacitorListText.Text;

            // initialize component lists
            new AvailableComponents();

            // setup based on MCTS or DFS
            if (mctsRadio.Checked)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;   // start to finish progress bar
                progressBar1.Visible = true;
                progressBar1.Maximum = 100;
                backgroundWorker1.WorkerReportsProgress = true; // allows backgroundworker reports
            }
            else if (dfsRadio.Checked)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;  // cycling progress bar
                progressBar1.MarqueeAnimationSpeed = 40;
                progressBar1.Visible = true;
                backgroundWorker1.WorkerReportsProgress = false;// disallows background reports
            }
            // run task in background
            backgroundWorker1.RunWorkerAsync();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Creates pop-up for regulator properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SRLabel_Click(object sender, EventArgs e)
        {
            // If no solution given: do nothing and return
            // Else: pop-up information
            if (srLabel.Text.Equals("Switching Regulator: "))
            {
                return;
            }
            else
            {
                var dropdownSolList = new List<KeyValuePair<string, Node>>();
                dropdownSolList = (List<KeyValuePair<string, Node>>)solListBox.DataSource;
                List<Node> sortedsolList = (from kvp in dropdownSolList select kvp.Value).ToList();

                string freqUnitString;
                float freqReductionFactor;

                if (sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.swFrequency > 1000000000)
                {
                    freqUnitString = "GHz";
                    freqReductionFactor = 1000000000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.swFrequency > 1000000)
                {
                    freqUnitString = "MHz";
                    freqReductionFactor = 1000000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.swFrequency > 1000)
                {
                    freqUnitString = "kHz";
                    freqReductionFactor = 1000;
                }
                else
                {
                    freqUnitString = "Hz";
                    freqReductionFactor = 1;
                }

                MessageBox.Show("Manufacturer: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.manufacturer + "\n" +
                                "DigiKey Part Number: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.partNumber + "\n" +
                                "Cost: $" + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.cost + "\n" +
                                "Minimum Input Voltage: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.minInputVoltage + " V\n" +
                                "Maximum Input Voltage: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.maxInputVoltage + " V\n" +
                                "Output Voltage: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.outputVoltage + " V\n" +
                                "Output Current: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.outputCurrent + " A\n" +
                                "Switching Frequency: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.swFrequency / freqReductionFactor + freqUnitString + "\n");


            }

        }

        /// <summary>
        /// Creates pop-up for output capacitor properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutCapLabel_Click(object sender, EventArgs e)
        {
            // If no solution given: do nothing and return
            // Else: pop-up information
            if (outCapLabel.Text.Equals("Output Capacitor: "))
            {
                return;
            }
            else
            {
                var dropdownSolList = new List<KeyValuePair<string, Node>>();
                dropdownSolList = (List<KeyValuePair<string, Node>>)solListBox.DataSource;
                List<Node> sortedsolList = (from kvp in dropdownSolList select kvp.Value).ToList();

                string capUnitString;
                float capMultiplier;

                if (sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.capacitance > 1)
                {
                    capUnitString = "F";
                    capMultiplier = 1;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.capacitance > 0.001F)
                {
                    capUnitString = "mF";
                    capMultiplier = 1000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.capacitance > 0.000001F)
                {
                    capUnitString = "μF";
                    capMultiplier = 1000000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.capacitance > 0.000000001F)
                {
                    capUnitString = "nF";
                    capMultiplier = 1000000000;
                }
                else
                {
                    capUnitString = "F";
                    capMultiplier = 1;
                }

                MessageBox.Show("Manufacturer: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.manufacturer + "\n" +
                                "DigiKey Part Number: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.partNumber + "\n" +
                                "Cost: $" + sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.cost + "\n" +
                                "Capacitance: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.capacitance * capMultiplier + " " + capUnitString + "\n" +
                                "Voltage Rating: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.voltageRating + " V\n");
            }
        }

        /// <summary>
        /// Creates pop-up for inductor properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InductorLabel_Click(object sender, EventArgs e)
        {
            // If no solution given: do nothing and return
            // Else: pop-up information
            if (inductorLabel.Text.Equals("Inductor: "))
            {
                return;
            }
            else
            {
                var dropdownSolList = new List<KeyValuePair<string, Node>>();
                dropdownSolList = (List<KeyValuePair<string, Node>>)solListBox.DataSource;
                List<Node> sortedsolList = (from kvp in dropdownSolList select kvp.Value).ToList();

                string indUnitString;
                float indMultiplier;

                if (sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.inductance > 1)
                {
                    indUnitString = "H";
                    indMultiplier = 1;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.inductance > 0.001F)
                {
                    indUnitString = "mH";
                    indMultiplier = 1000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.inductance > 0.000001F)
                {
                    indUnitString = "μH";
                    indMultiplier = 1000000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.inductance > 0.000000001F)
                {
                    indUnitString = "nH";
                    indMultiplier = 1000000000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.inductance > 0.0000000000001F)
                {
                    indUnitString = "pH";
                    indMultiplier = 1000000000;
                }
                else
                {
                    indUnitString = "H";
                    indMultiplier = 1;
                }

                MessageBox.Show("Manufacturer: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.manufacturer + "\n" +
                                "DigiKey Part Number: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.partNumber + "\n" +
                                "Cost: $" + sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.cost + "\n" +
                                "Inductance: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.inductance * indMultiplier + " " + indUnitString + "\n" +
                                "Current Rating: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.currentRating + " A\n");
            }
        }

        /// <summary>
        /// Creates pop-up for input capacitor properteis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputCapLabel_Click(object sender, EventArgs e)
        {
            // If no solution given: do nothing and return
            // Else: pop-up information
            if (inputCapLabel.Text.Equals("Input Capacitor: "))
            {
                return;
            }
            else
            {
                var dropdownSolList = new List<KeyValuePair<string, Node>>();
                dropdownSolList = (List<KeyValuePair<string, Node>>)solListBox.DataSource;
                List<Node> sortedsolList = (from kvp in dropdownSolList select kvp.Value).ToList();

                string capUnitString;
                float capMultiplier;

                if (sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.capacitance > 1)
                {
                    capUnitString = "F";
                    capMultiplier = 1;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.capacitance > 0.001F)
                {
                    capUnitString = "mF";
                    capMultiplier = 1000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.capacitance > 0.000001F)
                {
                    capUnitString = "μF";
                    capMultiplier = 1000000;
                }
                else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.capacitance > 0.000000001F)
                {
                    capUnitString = "nF";
                    capMultiplier = 1000000000;
                }
                else
                {
                    capUnitString = "F";
                    capMultiplier = 1;
                }

                MessageBox.Show("Manufacturer: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.manufacturer + "\n" +
                                "DigiKey Part Number: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.partNumber + "\n" +
                                "Cost: $" + sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.cost + "\n" +
                                "Capacitance: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.capacitance * capMultiplier + " " + capUnitString + "\n" +
                                "Voltage Rating: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.voltageRating + " V\n");
            }
        }

        /// <summary>
        /// Updates print-out based off selected solution in dropdown list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropdownSolList = new List<KeyValuePair<string, Node>>();
            dropdownSolList = (List<KeyValuePair<string, Node>>)solListBox.DataSource;
            List<Node> sortedsolList = (from kvp in dropdownSolList select kvp.Value).ToList();

            outCapLabel.Text = "Output Capacitor: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.outCap.partNumber;
            inputCapLabel.Text = "Input Capacitor: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inCap.partNumber;
            inductorLabel.Text = "Inductor: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.inductor.partNumber;
            srLabel.Text = "Switching Regulator: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.chip.partNumber;

            string vrUnitString;
            string crUnitString;
            float vrMultiplier;
            float crMultiplier;

            if (sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple > 1)
            {
                vrUnitString = "V";
                vrMultiplier = 1;
            }
            else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple > 0.001F)
            {
                vrUnitString = "mV";
                vrMultiplier = 1000;
            }
            else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple > 0.000001F)
            {
                vrUnitString = "μV";
                vrMultiplier = 1000000;
            }
            else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple > 0.000000001F)
            {
                vrUnitString = "nV";
                vrMultiplier = 1000000000;
            }
            else
            {
                vrUnitString = "V";
                vrMultiplier = 1;
            }

            if (sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple > 1)
            {
                crUnitString = "A";
                crMultiplier = 1;
            }
            else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple > 0.001F)
            {
                crUnitString = "mA";
                crMultiplier = 1000;
            }
            else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple > 0.000001F)
            {
                crUnitString = "μA";
                crMultiplier = 1000000;
            }
            else if (sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple > 0.000000001F)
            {
                crUnitString = "nA";
                crMultiplier = 1000000000;
            }
            else
            {
                crUnitString = "A";
                crMultiplier = 1;
            }

            CostLabel.Text = "Cost: $" + sortedsolList[solListBox.SelectedIndex].nodeComponents.cost;
            scoreLabel.Text = "Score: " + sortedsolList[solListBox.SelectedIndex].score;
            voltagerippleLabel.Text = "Voltage Ripple: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.voltageRipple * vrMultiplier + " " + vrUnitString;
            currentrippleLabel.Text = "Current Ripple: " + sortedsolList[solListBox.SelectedIndex].nodeComponents.currentRipple * crMultiplier + " " + crUnitString;
        }

        /// <summary>
        /// Implements Monte Carlo Tree Search (MCTS) method to find the best available components based on user requirements.
        /// </summary>
        /// <returns><see cref="List{T}"/> of the best <see cref="Node"/> from MCTS</returns>
        public Solution MCTS(BackgroundWorker worker, DoWorkEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();            // start stopwatch
            Node root = new();                              // create root node
            root.SetNodeAsRoot();
            List<Node> goodNodes = new();                   // create list of good nodes
            Node bestNode = root;                           // set root as best node
            float runTime = float.Parse(runningTime.Text);  // store running time input as float

            int iterCount = 0;  // create counter for valid solutions searched

            while (sw.ElapsedMilliseconds < 1000 * runTime)
            {

                Node promisingNode = Selection(root);   // select a good node
                if (promisingNode.IsTerminal())         // do nothing if a solution node was selected
                {
                    continue;
                }
                Node nodeToExplore = new();             
                promisingNode.Expand(ref nodeToExplore);    // create the node that simulation will start from
                nodeToExplore.visitCount++;                 // increment visit count for new node
                Simulation(nodeToExplore, ref bestNode, ref goodNodes); // simulate a random branch

                iterCount++; // increment iter count for valid solution evaluation

                // update progress bar
                worker.ReportProgress((int)(Math.Floor((double)sw.ElapsedMilliseconds / 1000) * 100 / runTime));

            }

            //MessageBox.Show("Number of Designs Evaluated: " + iterCount);

            return new Solution(goodNodes, iterCount);
        }

        /// <summary>
        /// Simulation of a random branch of the search tree.
        /// </summary>
        /// <param name="startingNode"></param>
        /// <param name="bestNode"></param>
        /// <param name="goodNodes"></param>
        private static void Simulation(Node startingNode, ref Node bestNode, ref List<Node> goodNodes)
        {
            Node node = startingNode;
            // continue moving through random children until you reach a valid solution
            while (!node.IsTerminal())
            {
                node.AddRandomChild();
                node = node.GetRandomChild();
            }

            // update if score is good
            if (node.score > bestNode.score)
            {
                bestNode = node;
                goodNodes.Add(node);
            }

            Node newNode = node;

            // Back Propagation
            while (!newNode.root && !(newNode.parent == null))
            {
                newNode = newNode.parent;   // move up in tree
                newNode.CalculateScore();   // recalculate score
                if (newNode.visitCount == 0)    // delete randomly created children
                {
                    newNode.children.Clear();
                }
            }
        }

        /// <summary>
        /// Selection of a promising node path via <see cref="UCB"/>.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>Most promising <see cref="Node"/>.</returns>
        private static Node Selection(Node root)
        {
            Node node = root;
            node.visitCount++;  // increment visit count for node
            while (node.leaf == false)  // while node has no unexplored children, get best child
            {
                node = node.GetBestChild();
                node.visitCount++;  // increment visit count
            }
            return node;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        static public Solution DFS(BackgroundWorker? worker, DoWorkEventArgs e)
        {

            Stack<Node> stack = new();
            Node root = new();  // Create root node
            root.SetNodeAsRoot();
            stack.Push(root); // Push root onto stack
            Node bestNode = root;   // Set root as best node
            List<Node> goodNodes = new();   // Create list of good nodes

            int iter = 0;   // Create iteration counter to count valid solutions explored
            int solsWorseThanMCTS = 0;

            Node N = new();

            while (!(stack.Count == 0))
            {
                N = stack.Pop();    // pop candidate off stack

                if (N.nodeComponents.IsCompleteState()) // if node is a valid solution, increment counter and check if good
                {
                    iter++;     // add to iter count

                    // check if score is better than current best
                    if (N.score > bestNode.score)
                    {
                        bestNode = N;
                        goodNodes.Add(N);
                    }
                    // compare to global MCTS solution and add to counter if worse
                    if (GlobalMCTS.solution != null)
                    {
                        if (N.score <= GlobalMCTS.solution.score)
                        {
                            solsWorseThanMCTS++;
                        }
                    }
                    
                }

                // Add node's children to the stack
                AddChildrenToStack(ref stack, N);

            }

            if (GlobalMCTS.solution != null)
            {
                MessageBox.Show("Number of designs evaluated in exhaustive search: " + iter.ToString("N0") + "\n" + 
                                "MCTS solution was better than or equal to " + solsWorseThanMCTS.ToString("N0") + " solutions, which places it in the " + ((float)(100F * solsWorseThanMCTS / iter)).ToString("N6") + "th percentile " +
                                "while only searching " + ((float)(100F * GlobalMCTS.iterCount / iter)).ToString("N2") + "% of the space.");

            }
            

            return new Solution(goodNodes, iter);
        }

        /// <summary>
        /// Adds children to stack for DFS
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="parentNode"></param>
        static void AddChildrenToStack(ref Stack<Node> stack, Node parentNode)
        {
            List<State> availableNewComponents = parentNode.nodeComponents.GetAllPossibleStates();  // Gets possible states

            // create new children and add to stack
            foreach (State state in availableNewComponents)
            {
                stack.Push(new Node(state, parentNode));
            }
        }

        /// <summary>
        /// Updates UI based on MCTS radio button change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mctsRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (mctsRadio.Checked)
            {
                dfsRadio.Checked = false;
            }
        }

        /// <summary>
        /// Updates UI based on DFS radio button change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dfsRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (dfsRadio.Checked)
            {
                runningTime.Text = "N/A";
                mctsRadio.Checked = false;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click_2(object sender, EventArgs e)
        {

        }
    }
}
