# OptimalBuckConverter

## Overview
This is a Windows Forms application that uses Monte Carlo tree search to find the optimal components for a basic buck converter design. It includes an Exhaustive Search (depth-first search, since the tree isn't very deep) option to show the performance of the MCTS result, as well as a priority slider for Cost vs. Performance. 

**The parts can be downloaded as a .csv file from Digi-Key; the form handles parsing the different headers, but they must be from Digi-Key and unchanged. 

## How-To
1. Retrieve a data table (.csv file type) from Digi-key for buck converter IC's (preferably fixed, or it will ignore programmability), inductors, and capacitors. Place them in the folder mention above. 
2. Run the app and enter the desired properties in their respective boxes (numbers only). Then, select a search method, and press run. 
3. For MCTS, the search will run until the designated time has passed. For exhaustive search, the search will run until it has evaluated every viable solution. 
4. There's a dropdown list of good solutions which will present the parts that correspond to it. Click on a part to view more information on it. 
5. If MCTS has been performed, the exhaustive search will give a pop-up with more info on how good the MCTS solution was (if the inputs didn't change). 

## To-Do
- [ ] Make a file browser for table uploads
- [ ] Add functionality for other circuit types
- [ ] General code clean-up

