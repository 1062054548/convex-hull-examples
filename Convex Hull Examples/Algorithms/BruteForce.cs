using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Convex_Hull_Examples.Models;
using System.Drawing;

namespace Convex_Hull_Examples.Algorithms
{
    class BruteForce : ConvexHullAlgorithm
    {
        private List<Line> lines;

        /// <summary>
        /// Generates the result of the first N steps of the algorithm for display
        /// </summary>
        /// <param name="step">The amount of steps to work through</param>
        /// <returns>The lines to draw on the graph</returns>
        public List<Line> ComputeToStep(int step)
        {
            if (step >= lines.Count)
            {
                step = lines.Count;
            }

            int index = 0;
            Node beginingNode = lines[0].GetFirstEndpoint();
            List<Line> linesAtStep = new List<Line>();

            for (int i = 0; i < step; i++)
            {
                linesAtStep.Add(lines[i]);
                if (linesAtStep[index].GetColor() == Color.Green)
                {
                    linesAtStep.RemoveAll(a => a.GetColor() == Color.Red);
                    index = linesAtStep.Count - 1;
                }
                else if (linesAtStep[index].GetColor() == Color.Red)
                {
                    if (linesAtStep[index].GetFirstEndpoint() != beginingNode && 
                        linesAtStep[index].GetSecondEndpoint() != beginingNode)
                    {
                        beginingNode = linesAtStep[index].GetFirstEndpoint();
                        linesAtStep.RemoveAll(a => a.GetColor() == Color.Red && 
                                                   a.GetFirstEndpoint() != beginingNode &&
                                                   a.GetSecondEndpoint() != beginingNode);

                        index = linesAtStep.Count - 1;
                    }
                }

                index++;
            }

            return linesAtStep;
        }

        /// <summary>
        /// Returns the number of steps the algorithm computes
        /// </summary>
        /// <param name="nodes">A list of nodes to find the Convex Hull of</param>
        /// <returns>The number of steps required to find the convex hull</returns>
        public int GetNumberOfSteps(List<Node> nodes)
        {
            return Compute(nodes);
        }

        /// <summary>
        /// Computes the Convex Hull using the Brute Force algorithm
        /// </summary>
        /// <param name="nodes">A list of nodes to find the Convex Hull of</param>
        /// <returns>The number of steps it took to finish</returns>
        private int Compute(List<Node> nodes)
        {
            lines = new List<Line>();

            int count = 0;

            nodes.Sort((a, b) => a.X.CompareTo(b.X));
            nodes.Sort((a, b) => a.Y.CompareTo(b.Y));

            for(int i = 0; i < nodes.Count; i++) 
            {
                for(int j = i + 1; j < nodes.Count; j++)
                {
                    Node nodeA = nodes[i];
                    Node nodeB = nodes[j];

                    if (ComputeStep(nodes, nodeA, nodeB))
                    {
                        Line line = new Line(nodeA, nodeB, Color.Green);

                        lines.Add(line);
                        count++;

                        if (IsConvexHull(lines.FindAll(a => a.GetColor() == Color.Green)))
                        {
                            return count;
                        }

                    }
                    else
                    {
                        Line line = new Line(nodeA, nodeB, Color.Red);

                        lines.Add(line);
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Determines if the lines already found to be part of the hull form the full Convex Hull
        /// </summary>
        /// <param name="list">List of lines found</param>
        /// <returns>True if the lines form a Convex Hull, false otherwise</returns>
        private bool IsConvexHull(List<Line> list)
        {
            var nodeCount = new Dictionary<Node, int>();

            foreach (Line line in list)
            {
                var nodeA = line.GetFirstEndpoint();
                var nodeB = line.GetSecondEndpoint();

                if (nodeCount.ContainsKey(nodeA))
                {
                    nodeCount[nodeA]++;
                }
                else
                {
                    nodeCount.Add(nodeA, 1);
                }

                if (nodeCount.ContainsKey(nodeB))
                {
                    nodeCount[nodeB]++;
                }
                else
                {
                    nodeCount.Add(nodeB, 1);
                }
            }

            foreach (int count in nodeCount.Values)
            {
                if (count != 2)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines if the line drawn from nodeA to nodeB split the other nodes such that all other nodes fall on one side
        /// </summary>
        /// <param name="nodes">List of nodes to check</param>
        /// <param name="nodeA">First node of potential hull line</param>
        /// <param name="nodeB">Second node of potential hull line</param>
        /// <returns>True if line from nodeA to nodeB belongs in the Convex Hull</returns>
        private bool ComputeStep(List<Node> nodes, Node nodeA, Node nodeB)
        {
            bool? IsLeftTurnExpected = null;

            foreach (Node nodeC in nodes)
            {
                if (nodeA == nodeC || nodeB == nodeC)
                {
                    continue;
                }

                int test = CrossProduct(nodeA, nodeB, nodeC);

                if (IsLeftTurnExpected == null)
                {
                    IsLeftTurnExpected = (test < 0);
                }

                if (test == 0)
                {
                    continue;
                }
                if (IsLeftTurnExpected == true && test > 0)
                {
                    return false;
                }
                else if (IsLeftTurnExpected == false && test < 0)
                {
                    return false;
                }
            }

            return true;

        }

        /// <summary>
        /// Computes the cross product of three points
        /// </summary>
        /// <param name="p1">First node</param>
        /// <param name="p2">Second node</param>
        /// <param name="p3">Third node</param>
        /// <returns>Positive number if left turn, negative number if right turn, 0 if co-linear</returns>
        private int CrossProduct(Node p1, Node p2, Node p3)
        {
            return (p3.X - p1.X) * (p2.Y - p1.Y) - (p2.X - p1.X) * (p3.Y - p1.Y);
        }
    }
}
