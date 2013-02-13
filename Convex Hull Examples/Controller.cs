using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Convex_Hull_Examples.Algorithms;
using Convex_Hull_Examples.Models;
using System.Drawing;
using System.Timers;

namespace Convex_Hull_Examples
{
    class Controller
    {
        static private Controller instance;
        static private ConvexHullAlgorithm algorithm;
        static private MasterModel model;
        static private ExampleWindow view;
        private int maxX, maxY, nodeRadius;

        /// <summary>
        /// Constructor to create the initial instance of the controller singleton
        /// </summary>
        /// <param name="parent">Handle to a view window</param>
        /// <param name="radius">Radius to draw nodes and lines at</param>
        private Controller(ExampleWindow parent, int radius)
        {
            algorithm = null;
            view = parent;

            maxX = parent.ModelOutput.Width;
            maxY = parent.ModelOutput.Height;

            this.nodeRadius = radius;

            model = new MasterModel(parent, nodeRadius);
        }
        
        /// <summary>
        /// Retrieves the instance of the Controller object
        /// </summary>
        /// <param name="parent">The handle to the view</param>
        /// <param name="radius">Radius to draw everything at on the graph</param>
        /// <returns>A reference to the controller singleton</returns>
        static public Controller GetInstance(ExampleWindow parent, int radius)
        {
            if (instance == null)
            {
                instance = new Controller(parent, radius);
            }

            return instance;
        }

        /// <summary>
        /// Generates X new nodes and calls model to display them
        /// </summary>
        /// <param name="numberOfNodes">Number of nodes to generate</param>
        public void CreateNewNodes(int numberOfNodes)
        {
            Random rand = new Random();

            model.SetStepValue(0);
            model.SetMaxStepValue(1);

            List<Node> nodes = new List<Node>();

            for (int i = 0; i < numberOfNodes; i++)
            {
                int xCoord;
                int yCoord;
                do
                {
                    xCoord = rand.Next(nodeRadius, maxX - nodeRadius);
                    yCoord = rand.Next(nodeRadius, maxY - nodeRadius);
                } while (nodes.Exists(a => a.X == xCoord || a.Y == yCoord));

                nodes.Add(new Node(xCoord, yCoord, Color.Blue));
            }

            model.SetElements(nodes, new List<Line>());

            model.UpdateViewNodeList();

            model.DrawGraph();

            if (algorithm != null)
            {
                ScaleStepTrackBar();
            }
        }

        /// <summary>
        /// Parses a text string for a number of nodes to generate, then generates that amount.
        /// </summary>
        /// <param name="rawInput">String containing the number of nodes to generate</param>
        public void CreateNewNodes(string rawInput)
        {
            int numberOfNodes = 0;

            if (Int32.TryParse(rawInput, out numberOfNodes))
            {
                if (numberOfNodes >= 3 && numberOfNodes <= 175)
                {
                    CreateNewNodes(numberOfNodes);
                }
                else
                {
                    CreateNewNodes(10);
                }
            }
        }

        /// <summary>
        /// Sets which algorithm to use and sets up model if nodes exist
        /// </summary>
        /// <param name="selection">The algorithm to use</param>
        public void SetAlgorithm(AlgorithmEnum selection)
        {
            switch (selection)
            {
                case AlgorithmEnum.BruteForce:
                    algorithm = new BruteForce();
                    break;
                case AlgorithmEnum.GrahamScan:
                    algorithm = new GrahamScan();
                    break;
                default:
                    throw new NotImplementedException("There is no algorithm that matches that selection");
            }

            if (model.GetNodeList().Count > 0)
            {
                ScaleStepTrackBar();
            }
        }

        /// <summary>
        /// Sets the track bar to scale to the number of steps the algorithm goes through
        /// </summary>
        private void ScaleStepTrackBar()
        {
            var nodeList = model.GetNodeList();
            int numberOfSteps = algorithm.GetNumberOfSteps(nodeList);

            model.SetMaxStepValue(numberOfSteps);
            model.SetStepValue(0);
        }

        /// <summary>
        /// Retrieves a step from the algorithm and passes it along to the model to display
        /// </summary>
        /// <param name="step">The step number, from 0 to N, where N is the last step of the algorithm</param>
        public void SetStep(int step)
        {
            if (algorithm != null)
            {
                var nodes = model.GetNodeList();
                var lines = algorithm.ComputeToStep(step);

                model.SetElements(nodes, lines);
                model.SetStepValue(step);
                model.DrawGraph();
            }
        }

    }
}
