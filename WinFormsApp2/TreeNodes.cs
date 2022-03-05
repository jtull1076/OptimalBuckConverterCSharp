using Mono.Csv;
using static System.Math;

namespace WinFormsApp2
{
    /// <summary>
    /// Represents the required characteristics given by the user.
    /// </summary>
    public static class Requirements
    {
        /// <summary>
        /// Gets/sets minimum input voltage.
        /// </summary>
        public static float minInputVoltage { get; set; }

        /// <summary>
        /// Gets/sets maximum input voltage.
        /// </summary>
        public static float maxInputVoltage { get; set; }

        /// <summary>
        /// Gets/sets output voltage.
        /// </summary>
        public static float outputVoltage { get; set; }

        /// <summary>
        /// Gets/sets minimum required output current.
        /// </summary>
        public static float outputCurrent { get; set; }

        /// <summary>
        /// Gets/sets performance priority.
        /// </summary>
        public static int performanceWeight { get; set; }

        /// <summary>
        /// Gets/sets cost priority.
        /// </summary>
        public static int costWeight { get; set; }

        /// <summary>
        /// Gets peak current from user requirements.
        /// </summary>
        /// <param name="inductance"></param>
        /// <param name="swFrequency"></param>
        /// <returns><see cref="float"/> peak current value</returns>
        internal static float getPeakCurrent(float inductance, float swFrequency)
        {
            return outputCurrent + outputVoltage * (1 - outputVoltage / maxInputVoltage) / (2 * inductance * swFrequency);  // Equation for peak current
        }
    }

    /// <summary>
    /// Represents a node in the tree structure.
    /// </summary>
    public class Node
    {
        /* List of properties for the Node class: 
         * --------------------------------------
         * score: score/average score of the node
         * parent: parent node
         * children: list of children node
         * root: indicates whether node is root
         * leaf: indicates whether node has any unexplored children
         * nodeComponents: 'state' class which stores associated components
         * visitCount: number of times the node has been visited during the 'Selection' phase
         */
        public float score;
        public Node? parent;
        public List<Node> children;
        public bool root;
        public bool leaf;
        public State nodeComponents;
        public int visitCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class with default values.
        /// </summary>
        public Node()
        {
            score = 0;
            parent = null;
            children = new List<Node>();
            root = false;
            leaf = true;
            nodeComponents = new State();
            visitCount = 0;
        }

        /// <summary>
        /// Initializes a new instance of the Node class utilizing <see cref="State"/> and parent <see cref="Node"/> parameters.
        /// </summary>
        /// <remarks>
        /// Creates a new Node with the given parent and state; calculates the score of the state if the Node
        /// has all required components to do so; all other properties are default.
        /// </remarks>
        /// <param name="components"></param>
        /// <param name="newParent"></param>
        public Node(State components, Node newParent)
        {
            nodeComponents = components;
            if (nodeComponents.IsCompleteState())
            {
                score = nodeComponents.CalculateScore(this);
            }
            else
            {
                score = 0;
            }
            parent = newParent;
            children = new List<Node>();
            root = false;
            leaf = true;
            visitCount = 0;
        }

        /// <summary>
        /// Sets the Node as the root.
        /// </summary>
        public void SetNodeAsRoot()
        {
            root = true;
        }

        /// <summary>
        /// Indicates whether the Node has created all children available to it.
        /// </summary>
        /// <returns><see langword="true"/> if node already has all available children; <see langword="false"/> otherwise.</returns>
        public bool IsFullyExpanded()
        {
            List<State> availableNewComponents = nodeComponents.GetAllPossibleStates();
            List<State> childrenStates = new();
            foreach (var ch in children)
            {
                childrenStates.Add(ch.nodeComponents);
            }

            if (availableNewComponents.Count == childrenStates.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Expands the current node by one node.
        /// </summary>
        /// <remarks>
        /// Adds a new unexplored child <see cref="Node"/> to the list of children, returns by reference the added <see cref="Node"/> as <paramref name="nodeToExplore"/>.
        /// </remarks>
        /// <param name="nodeToExplore"></param>
        public void Expand(ref Node nodeToExplore)
        {
            List<State> availableNewComponents = nodeComponents.GetAllPossibleStates();
            List<State> childrenStates = new();

            foreach (var ch in children)
            {
                childrenStates.Add(ch.nodeComponents);
            }

            foreach (var components in availableNewComponents)
            {
                bool childAlreadyCreated = false;

                foreach (var ch in childrenStates)
                {
                    if (ch.chip.Equals(components.chip) && ch.inductor.Equals(components.inductor) && ch.outCap.Equals(components.outCap) && ch.inCap.Equals(components.inCap))
                    {
                        childAlreadyCreated = true;
                        break;
                    }
                }
                if (!childAlreadyCreated)
                {
                    nodeToExplore = new Node(components, this);
                    children.Add(nodeToExplore);
                    break;
                }
            }

            // if the new node is the last available node, the current one is no longer a leaf
            if (this.IsFullyExpanded())
            {
                leaf = false;
            }

        }

        /// <summary>
        /// Calculates the score of the current <see cref="Node"/>'s state.
        /// </summary>
        public void CalculateScore()
        {
            score = nodeComponents.CalculateScore(this);
        }

        /// <summary>
        /// Adds a random child <see cref="Node"/> to the list of children.
        /// </summary>
        public void AddRandomChild()
        {
            List<State> availableNewComponents = nodeComponents.GetAllPossibleStates();

            children.Add(new Node(availableNewComponents[RNG.RandomNumber(0, availableNewComponents.Count)], this));
        }

        /// <summary>
        /// Indicates whether a <see cref="Node"/> is terminal a.k.a. has no available children <see cref="State"/>.
        /// </summary>
        /// <returns><see langword="true"/> if the <see cref="Node"/> is terminal,<see langword="false"/> otherwise.</returns>
        public bool IsTerminal()
        {
            List<State> availableNewComponents = nodeComponents.GetAllPossibleStates();

            if (availableNewComponents.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a random child <see cref="Node"/>.
        /// </summary>
        /// <returns>Random child <see cref="Node"/></returns>
        public Node GetRandomChild()
        {
            return children[RNG.RandomNumber(0, children.Count)];
        }

        /// <summary>
        /// Gets the best child <see cref="Node"/> from the list of children.
        /// </summary>
        /// <returns><see cref="Node"/> with highest UCB value.</returns>
        public Node GetBestChild()
        {
            return UCB.FindBestChildWithUCB(this);
        }
    }

    /// <summary>
    /// Implements UCT/UCB for MCTS.
    /// </summary>
    internal class UCB
    {
        /// <summary>
        /// Gets the UCB value for <paramref name="node"/>.
        /// </summary>
        /// <param name="node"></param>
        /// <returns><see cref="float"/> UCB value</returns>
        public static float GetUCB(Node node)
        {
            return (float)(node.score + Sqrt(2 * Log(node.parent.visitCount) / node.visitCount));
        }

        /// <summary>
        /// Gets the child of <paramref name="node"/> with the highest UCB value.
        /// </summary>
        /// <param name="node"></param>
        /// <returns><see cref="Node"/> child with highest UCB</returns>
        public static Node FindBestChildWithUCB(Node node)
        {
            Node bestNode = node.children[RNG.RandomNumber(0, node.children.Count)];

            foreach (Node child in node.children)
            {
                if (GetUCB(child) > GetUCB(bestNode))
                {
                    bestNode = child;
                }
            }

            return bestNode;
        }
    }

    public class Solution
    {
        public List<Node> solList;
        public int iterCount;

        public Solution()
        {
            solList = new List<Node>();
            iterCount = 0;
        }

        public Solution(List<Node> listofNodes, int IterCount)
        {
            solList = listofNodes;
            iterCount = IterCount;
        }
    }

    /// <summary>
    /// Implements the <see cref="State"/> of the design for each <see cref="Node"/>.
    /// </summary>
    public class State
    {
        public Capacitors outCap;
        public Capacitors inCap;
        public Inductors inductor;
        public Chips chip;
        public float cost;
        public float voltageRipple;
        public float currentRipple;

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class with default components.
        /// </summary>
        /// <remarks>
        /// Represents the 'state' a.k.a. the list of components associated with a <see cref="Node"/>.
        /// </remarks>
        public State()
        {
            outCap = new Capacitors();
            inCap = new Capacitors();
            inductor = new Inductors();
            chip = new Chips();

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class with given components <paramref name="Ch"/>, <paramref name="Ind"/>, <paramref name="InCap"/>, and <paramref name="OutCap"/>.
        /// </summary>
        /// <param name="Ch"></param>
        /// <param name="Ind"></param>
        /// <param name="OutCap"></param>
        /// <param name="InCap"></param>
        public State(Chips Ch, Inductors Ind, Capacitors OutCap, Capacitors InCap)
        {
            chip = Ch;
            inductor = Ind;
            inCap = InCap;
            outCap = OutCap;
        }

        /// <summary>
        /// Indicates whether the given <see cref="State"/> is complete (i.e. no components are default).
        /// </summary>
        /// <returns><see langword="true"/> if state is complete, <see langword="false"/> otherwise.</returns>
        public bool IsCompleteState()
        {
            if (!(chip.Equals(default(Chips))))
            {
                if (!inductor.Equals(default(Inductors)))
                {
                    if (!inCap.Equals(default(Capacitors)))
                    {
                        if (!outCap.Equals(default(Capacitors)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Represents a list of the <see cref="State">States</see> available from a given <see cref="State"/>.
        /// </summary>
        /// <returns><see cref="List{T}"/> of available <see cref="State">States</see></returns>
        public List<State> GetAllPossibleStates()
        {
            List<Chips>? chips = AvailableComponents.listChips;
            List<Inductors>? inductors = AvailableComponents.listInductors;
            List<Capacitors>? capacitors = AvailableComponents.listCapacitors;
            List<State> result = new();

            if (chip.Equals(default(Chips)))
            {
                foreach (Chips ch in chips)
                {
                    if (ch.outputVoltage == Requirements.outputVoltage && ch.maxInputVoltage >= Requirements.maxInputVoltage && ch.minInputVoltage <= Requirements.minInputVoltage && ch.outputCurrent >= Requirements.outputCurrent)
                    {
                        State newState = new();
                        newState.chip = ch;
                        result.Add(newState);
                    }
                }
            }
            else if (inductor.Equals(default(Inductors)))
            {
                if (inductors != null)
                {
                    foreach (Inductors ind in inductors)
                    {
                        if (ind.currentRating >= Requirements.getPeakCurrent(ind.inductance, chip.swFrequency))
                        {
                            State newState = new(chip, ind, new Capacitors(), new Capacitors());
                            result.Add(newState);
                        }
                    }
                }
            }
            else if (outCap.Equals(default(Capacitors)))
            {
                if (capacitors != null)
                {
                    foreach (Capacitors cap in capacitors)
                    {
                        if (cap.voltageRating >= Requirements.outputVoltage)
                        {
                            State newState = new(chip, inductor, cap, new Capacitors());
                            result.Add(newState);
                        }
                    }
                }

            }
            else if (inCap.Equals(default(Capacitors)))
            {
                if (capacitors != null)
                {
                    foreach (Capacitors cap in capacitors)
                    {
                        if (cap.voltageRating >= Requirements.maxInputVoltage)
                        {
                            State newState = new(chip, inductor, outCap, cap);
                            newState.inCap = cap;
                            result.Add(newState);
                        }
                    }
                }
            }

            return result;

        }

        /// <summary>
        /// Calculates the score of a given <see cref="Node"/>.
        /// </summary>
        /// <param name="node"></param>
        /// <returns><see langword="float"/> score of the <see cref="Node">Nodes</see> <see cref="State"/></returns>
        public float CalculateScore(Node node)
        {
            if (node.nodeComponents.IsCompleteState())
            {
                int perfWeight = Requirements.performanceWeight;
                int costWeight = Requirements.costWeight;
                float perfPenalty;
                float costPenalty;

                if (perfWeight > costWeight)
                {
                    costPenalty = (float)costWeight / perfWeight;
                    perfPenalty = 1 - costPenalty;
                }
                else if (perfWeight < costWeight)
                {
                    perfPenalty = (float)perfWeight / costWeight;
                    costPenalty = 1 - perfPenalty;
                }
                else
                {
                    perfPenalty = 0.5F;
                    costPenalty = 0.5F;
                }

                // Normalization
                float minCost = 0;
                float maxCost = 50;
                float minRippleCurrent = 0;
                float maxRippleCurrent = 50;
                float minRippleVoltage = 0;
                float maxRippleVoltage = 100;

                float ripplevoltageScore = (float)100 / (1 + (float)Math.Exp(-5 * (getRippleVoltage() - Requirements.outputVoltage * 0.25)));
                ripplevoltageScore = (ripplevoltageScore - minRippleVoltage) / (maxRippleVoltage - minRippleVoltage);
                float ripplecurrentScore = (float)100 / (1 + (float)Math.Exp(-2 * (getRippleCurrent() - Requirements.outputCurrent * 2)));
                ripplecurrentScore = (ripplecurrentScore - minRippleCurrent) / (maxRippleCurrent - minRippleCurrent);


                if (ripplevoltageScore > 0.95)
                {
                    return 0;
                }
                if (ripplecurrentScore > 0.98)
                {
                    return 0;
                }

                float costScore = (getCost() - minCost) / (maxCost - minCost);


                float perfScore = perfPenalty * (ripplecurrentScore + ripplevoltageScore) / 2;
                costScore = costPenalty * costScore;

                float score = 2 - perfScore - costScore;


                return score;
            }
            else if (node.children != null)
            {
                int i = 0;
                float total = 0;
                foreach (Node child in node.children)
                {
                    i++;
                    total += child.score;
                }
                return total / i;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the cost (i.e. component price) of the <see cref="State"/>.
        /// </summary>
        /// <returns><see langword="float"/> cost.</returns>
        private float getCost()
        {
            cost = chip.cost + inductor.cost + inCap.cost + outCap.cost;
            return cost;
        }

        /// <summary>
        /// Gets the ripple voltage of the <see cref="State"/>.
        /// </summary>
        /// <returns><see langword="float"/> ripple voltage.</returns>
        private float getRippleVoltage()
        {
            voltageRipple = getRippleCurrent() / (6 * outCap.capacitance * chip.swFrequency);
            return voltageRipple;
        }

        /// <summary>
        /// Gets the ripple current of the <see cref="State"/>.
        /// </summary>
        /// <returns><see langword="float"/> ripple current.</returns>
        private float getRippleCurrent()
        {
            currentRipple = (chip.outputVoltage * (1 - chip.outputVoltage / chip.maxInputVoltage)) / (chip.swFrequency * inductor.inductance);
            return currentRipple;
        }
    }

    /// <summary>
    /// Extracts the available components from .csv
    /// </summary>
    /// <see href="https://github.com/floatinghotpot/LiteCsvParser"> GitHub: LiteCsvParser </see>
    public class AvailableComponents
    {

        public static List<Chips>? listChips;
        public static List<Inductors>? listInductors;
        public static List<Capacitors>? listCapacitors;

        /// <summary>
        /// Initializes an instance of the <see cref="AvailableComponents"/> class with lists obtained from given tables. 
        /// </summary>
        public AvailableComponents()
        {
            listChips = getChipList();
            listInductors = getInductorList();
            listCapacitors = getCapacitorList();
        }

        /// <summary>
        /// Gets a list of available <see cref="Chips"/> from supplied table. 
        /// </summary>
        /// <returns><see cref="List{T}"/> of available <see cref="Chips"/>.</returns>
        static List<Chips> getChipList()
        {
            List<Chips> result = new();

            // write file to string array
            //string[][] csvLines = File.ReadAllLines(fileName).Select(l => l.Split(',').ToArray()).ToArray();

            List<string> columns = new();
            //List<string> header = new List<string>();
            int outVoltageCol = 0;
            int minInCol = 0;
            int maxInCol = 0;
            int swFreqCol = 0;
            int mfrCol = 0;
            int partNumCol = 0;
            int idCol = 0;
            int outCurCol = 0;
            int costCol = 0;

            using (var reader = new CsvFileReader("ChipListNew.csv"))
            {
                while (reader.ReadRow(columns))
                {
                    Chips ch = new();

                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (columns[i].Equals("Mfr"))
                        {
                            //header[i] = "Mfr";
                            mfrCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Price"))
                        {
                            //header[i] = "Price";
                            costCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Voltage - Output (Min/Fixed)"))
                        {
                            //header[i] = "Voltage - Output (Min/Fixed)";
                            outVoltageCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Current - Output"))
                        {
                            //header[i] = "Current - Output";
                            outCurCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Voltage - Input (Min)"))
                        {
                            //header[i] = "Voltage - Input (Min)";
                            minInCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Voltage - Input (Max)"))
                        {
                            //header[i] = "Voltage - Input (Max)";
                            maxInCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Frequency - Switching"))
                        {
                            //header[i] = "Frequency - Switching";
                            swFreqCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Mfr Part #"))
                        {
                            //header[i] = "Mfr Part #";
                            idCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("DK Part #"))
                        {
                            //header.Add("DK Part #");
                            partNumCol = i;
                            continue;
                        }

                        if (i == idCol)
                        {
                            ch.id = columns[i];
                        }
                        else if (i == partNumCol)
                        {
                            ch.partNumber = columns[i];
                        }
                        else if (i == mfrCol)
                        {
                            ch.manufacturer = columns[i];
                        }
                        else if (i == costCol)
                        {
                            ch.cost = float.Parse(columns[i]);
                        }
                        else if (i == outVoltageCol)
                        {
                            string outVoltageString = "";

                            foreach (var chr in columns[i])
                            {
                                if (chr != 'V')
                                {
                                    outVoltageString += chr;
                                }
                                else
                                {
                                    break;
                                }

                            }

                            ch.outputVoltage = float.Parse(outVoltageString);
                        }
                        else if (i == outCurCol)
                        {
                            string currentString = "";
                            float multiplier = 1;

                            foreach (var chr in columns[i])
                            {

                                if (char.IsNumber(chr) || chr == '.')
                                {
                                    currentString += chr;
                                }
                                else
                                {
                                    if (chr.Equals('A'))
                                    {
                                        multiplier = 1;
                                    }
                                    else if (chr.Equals('m'))
                                    {
                                        multiplier = (float)1 / 1000;
                                    }
                                    break;
                                }
                            }

                            if (currentString.Equals(""))
                            {
                                break;
                            }

                            ch.outputCurrent = float.Parse(currentString);
                            ch.outputCurrent = (float)(ch.outputCurrent * multiplier);
                        }
                        else if (i == minInCol)
                        {
                            string minInString = "";

                            foreach (var chr in columns[i])
                            {
                                if (chr != 'V')
                                {
                                    minInString += chr;
                                }
                                else
                                {
                                    break;
                                }

                            }

                            ch.minInputVoltage = float.Parse(minInString);
                        }
                        else if (i == maxInCol)
                        {
                            string maxInString = "";

                            foreach (var chr in columns[i])
                            {
                                if (chr != 'V')
                                {
                                    maxInString += chr;
                                }
                                else
                                {
                                    break;
                                }

                            }

                            ch.maxInputVoltage = float.Parse(maxInString);
                        }
                        else if (i == swFreqCol)
                        {
                            string freqString = "";
                            float multiplier = 1;

                            foreach (var chr in columns[i])
                            {

                                if (char.IsNumber(chr) || chr == '.')
                                {
                                    freqString += chr;
                                }
                                else
                                {
                                    if (chr.Equals('H'))
                                    {
                                        multiplier = 1;
                                        break;
                                    }
                                    if (chr.Equals('M'))
                                    {
                                        multiplier = 1000000;
                                        break;
                                    }
                                    else if (chr.Equals('k'))
                                    {
                                        multiplier = 1000;
                                        break;
                                    }
                                    else if (chr.Equals('G'))
                                    {
                                        multiplier = 1000000000;
                                        break;
                                    }
                                    else if (!chr.Equals(' '))
                                    {
                                        freqString = "";
                                        break;
                                    }
                                }
                            }

                            if (freqString.Equals(""))
                            {
                                break;
                            }

                            ch.swFrequency = float.Parse(freqString);
                            ch.swFrequency *= multiplier;
                        }
                    }

                    if (!ch.Equals(default(Chips)) && (ch.swFrequency != 0) && (ch.outputCurrent != 0))
                    {
                        bool alreadyInResult = false;
                        foreach (Chips chp in result)
                        {
                            if (chp.id.Equals(ch.id))
                            {
                                alreadyInResult = true;
                                break;
                            }
                        }
                        if (!alreadyInResult)
                        {
                            result.Add(ch);
                        }
                    }

                }

            }
            return result;
        }

        /// <summary>
        /// Gets a list of available <see cref="Inductors"/> from supplied table. 
        /// </summary>
        /// <returns><see cref="List{T}"/> of available <see cref="Inductors"/>.</returns>
        static List<Inductors> getInductorList()
        {
            string fileName = "InductorListNewNew.csv";
            List<Inductors> result = new();

            List<string> columns = new();
            //List<string> header = new List<string>();
            int indCol = 0;
            int dcrCol = 0;
            int mfrCol = 0;
            int partNumCol = 0;
            int idCol = 0;
            int curCol = 0;
            int costCol = 0;

            using (var reader = new CsvFileReader(fileName))
            {
                while (reader.ReadRow(columns))
                {
                    Inductors ind = new();

                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (columns[i].Equals("Mfr"))
                        {
                            //header[i] = "Mfr";
                            mfrCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Price"))
                        {
                            //header[i] = "Price";
                            costCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Inductance"))
                        {
                            indCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("DC Resistance (DCR)"))
                        {
                            dcrCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Current Rating (Amps)"))
                        {
                            curCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Mfr Part #"))
                        {
                            //header[i] = "Mfr Part #";
                            idCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("DK Part #"))
                        {
                            //header.Add("DK Part #");
                            partNumCol = i;
                            continue;
                        }

                        if (i == idCol)
                        {
                            ind.id = columns[i];
                        }
                        else if (i == partNumCol)
                        {
                            ind.partNumber = columns[i];
                        }
                        else if (i == mfrCol)
                        {
                            ind.manufacturer = columns[i];
                        }
                        else if (i == costCol)
                        {
                            ind.cost = float.Parse(columns[i]);
                        }
                        else if (i == indCol)
                        {
                            string indString = "";
                            float multiplier = 1;

                            foreach (var chr in columns[i])
                            {

                                if (char.IsNumber(chr) || chr == '.')
                                {
                                    indString += chr;
                                }
                                else
                                {
                                    if (chr.Equals('H'))
                                    {
                                        multiplier = 1;
                                        break;
                                    }
                                    else if (chr.Equals('µ'))
                                    {
                                        multiplier = 0.000001F;
                                        break;
                                    }
                                    else if (chr.Equals('n'))
                                    {
                                        multiplier = 0.000000001F;
                                        break;
                                    }
                                    else if (!chr.Equals(' '))
                                    {
                                        indString = "";
                                        break;
                                    }

                                }
                            }

                            if (indString.Equals(""))
                            {
                                break;
                            }

                            ind.inductance = float.Parse(indString);
                            ind.inductance *= multiplier;
                        }
                        else if (i == curCol)
                        {
                            string currentString = "";
                            float multiplier = 1;

                            foreach (var chr in columns[i])
                            {

                                if (char.IsNumber(chr) || chr == '.')
                                {
                                    currentString += chr;
                                }
                                else
                                {
                                    if (chr.Equals('A'))
                                    {
                                        multiplier = 1;
                                        break;
                                    }
                                    else if (chr.Equals('m'))
                                    {
                                        multiplier = (float)1 / 1000;
                                        break;
                                    }
                                    else if (!chr.Equals(' '))
                                    {
                                        currentString = "";
                                        break;
                                    }

                                }
                            }

                            if (currentString.Equals(""))
                            {
                                break;
                            }

                            ind.currentRating = float.Parse(currentString);
                            ind.currentRating *= multiplier;
                        }
                        else if (i == dcrCol)
                        {
                            string dcrString = "";
                            float multiplier = 1;

                            foreach (var chr in columns[i])
                            {

                                if (char.IsNumber(chr) || chr == '.')
                                {
                                    dcrString += chr;
                                }
                                else
                                {
                                    if (chr.Equals('O'))
                                    {
                                        multiplier = 1;
                                        break;
                                    }
                                    else if (chr.Equals('m'))
                                    {
                                        multiplier = (float)1 / 1000;
                                        break;
                                    }
                                    else if (!chr.Equals(' '))
                                    {
                                        dcrString = "";
                                        break;
                                    }

                                }
                            }

                            if (dcrString.Equals(""))
                            {
                                break;
                            }

                            ind.dcResistance = float.Parse(dcrString);
                            ind.dcResistance *= multiplier;
                        }
                    }

                    if (!ind.Equals(default(Inductors)) && (ind.currentRating != 0) && (ind.dcResistance != 0))
                    {
                        bool alreadyInResult = false;
                        foreach (Inductors inds in result)
                        {
                            if (inds.id.Equals(ind.id))
                            {
                                alreadyInResult = true;
                                break;
                            }
                        }
                        if (!alreadyInResult)
                        {
                            result.Add(ind);
                        }
                    }

                }

            }
            return result;
        }

        /// <summary>
        /// Gets a list of available <see cref="Capacitors"/> from supplied table. 
        /// </summary>
        /// <returns><see cref="List{T}"/> of available <see cref="Capacitors"/>.</returns>
        static List<Capacitors> getCapacitorList()
        {
            string fileName = "CapacitorListNew.csv";
            List<Capacitors> result = new();

            List<string> columns = new();
            //List<string> header = new List<string>();
            int capCol = 0;
            int mfrCol = 0;
            int partNumCol = 0;
            int idCol = 0;
            int volCol = 0;
            int costCol = 0;

            using (var reader = new CsvFileReader(fileName))
            {
                while (reader.ReadRow(columns))
                {
                    Capacitors cap = new();

                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (columns[i].Equals("Mfr"))
                        {
                            //header[i] = "Mfr";
                            mfrCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Price"))
                        {
                            //header[i] = "Price";
                            costCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Capacitance"))
                        {
                            capCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Voltage - Rated"))
                        {
                            volCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("Mfr Part #"))
                        {
                            //header[i] = "Mfr Part #";
                            idCol = i;
                            continue;
                        }
                        else if (columns[i].Equals("DK Part #"))
                        {
                            //header.Add("DK Part #");
                            partNumCol = i;
                            continue;
                        }

                        if (i == idCol)
                        {
                            cap.id = columns[i];
                        }
                        else if (i == partNumCol)
                        {
                            cap.partNumber = columns[i];
                        }
                        else if (i == mfrCol)
                        {
                            cap.manufacturer = columns[i];
                        }
                        else if (i == costCol)
                        {
                            cap.cost = float.Parse(columns[i]);
                        }
                        else if (i == capCol)
                        {
                            string capString = "";
                            float multiplier = 1;

                            foreach (var chr in columns[i])
                            {

                                if (char.IsNumber(chr) || chr == '.')
                                {
                                    capString += chr;
                                }
                                else
                                {
                                    if (chr.Equals('F'))
                                    {
                                        multiplier = 1;
                                        break;
                                    }
                                    else if (chr == 'µ')
                                    {
                                        multiplier = 0.000001F;
                                        break;
                                    }
                                    else if (chr.Equals('n'))
                                    {
                                        multiplier = 0.000000001F;
                                        break;
                                    }
                                    else if (chr.Equals('p'))
                                    {
                                        multiplier = 0.000000000001F;
                                        break;
                                    }
                                    else if (!chr.Equals(' '))
                                    {
                                        capString = "";
                                        break;
                                    }
                                }
                            }

                            if (capString.Equals(""))
                            {
                                break;
                            }

                            cap.capacitance = float.Parse(capString);
                            cap.capacitance *= multiplier;
                        }
                        else if (i == volCol)
                        {
                            string voltageString = "";
                            float multiplier = 1;

                            foreach (var chr in columns[i])
                            {
                                if (chr != 'V' && chr != ' ')
                                {
                                    voltageString += chr;
                                }
                                else
                                {
                                    break;
                                }

                            }

                            if (voltageString.Equals(""))
                            {
                                break;
                            }

                            cap.voltageRating = float.Parse(voltageString);
                            cap.voltageRating *= multiplier;
                        }
                    }

                    if (!cap.Equals(default(Capacitors)) && (cap.voltageRating != 0) && (cap.capacitance != 0))
                    {
                        bool alreadyInResult = false;
                        foreach (Capacitors cp in result)
                        {
                            if (cp.id.Equals(cap.id) || (cp.voltageRating.Equals(cap.voltageRating) && cp.capacitance.Equals(cap.capacitance)))
                            {
                                alreadyInResult = true;
                                break;
                            }
                        }
                        if (!alreadyInResult)
                        {
                            result.Add(cap);
                        }
                    }

                }

            }
            return result;
        }
    }

    /// <summary>
    /// Implements a random number generator.
    /// </summary>
    public class RNG
    {
        //Function to get a random number 
        private static readonly Random random = new();
        private static readonly object syncLock = new();

        /// <summary>
        /// Gets a random number using the <see cref="Random"/> class.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns><see langword="int"/> random number.</returns>
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }

    public static class GlobalMCTS
    {
        public static Node? solution { get; set; }
        public static int iterCount { get; set; }

    }

    /// <summary>
    /// Structure for switching regulator components.
    /// </summary>
    public struct Chips
    {
        public string id;
        public float cost;
        public float minInputVoltage;
        public float maxInputVoltage;
        public float outputVoltage;
        public float outputCurrent;
        public float swFrequency;
        public string manufacturer;
        public string partNumber;
    }

    /// <summary>
    /// Structure for inductor components.
    /// </summary>
    public struct Inductors
    {
        public string id;
        public float cost;
        public float inductance;
        public float dcResistance;
        public float currentRating;
        public string manufacturer;
        public string partNumber;
    }

    /// <summary>
    /// Structure for capacitor components.
    /// </summary>
    public struct Capacitors
    {
        public string id;
        public float cost;
        public float capacitance;
        public float voltageRating;
        public string manufacturer;
        public string partNumber;
    }
}
