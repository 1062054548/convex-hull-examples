using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Convex_Hull_Examples.Models;
using System.Drawing;

namespace Convex_Hull_Examples.Algorithms
{
    class GrahamScan : ConvexHullAlgorithm
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

            List<Line> linesAtStep = new List<Line>();

            List<int> greenIndex = new List<int>();

           foreach (Line line in lines)
            {
                if (line.GetColor() == Color.Green)
                {
                    greenIndex.Add(lines.IndexOf(line));
                }
            }

            if (step == 0)
            {
                return linesAtStep;
            }

            linesAtStep = lines.GetRange(0, step);

            int removeRedsBefore = greenIndex.FindLast(a => a < step);

            linesAtStep.RemoveAll(a => a.GetColor() == Color.Red && linesAtStep.IndexOf(a) < removeRedsBefore);

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
        /// Computes the Convex Hull using the Graham Scan algorithm
        /// </summary>
        /// <param name="nodes">A list of nodes to find the Convex Hull of</param>
        /// <returns>The number of steps it took to finish</returns>
        private int Compute(List<Node> nodes)
        {
            int count = 0;

            lines = new List<Line>();

            Node baseNode = FindBaseNode(nodes);

            List<Node> sortedNodes = SortByAngle(nodes, baseNode);
            List<Node> nodesInHull = new List<Node>();

            nodesInHull.Add(baseNode);
            nodesInHull.Add(sortedNodes[0]);

            lines.Add(new Line(baseNode, sortedNodes[0], Color.Green));

            sortedNodes.RemoveAt(0);

            foreach (Node node in sortedNodes)
            {
                int length = nodesInHull.Count;

                while (CrossProduct(nodesInHull[length - 2], nodesInHull[length - 1], node) < 0)
                {
                    lines[lines.FindLastIndex(a => a.GetColor() == Color.Green)].SetColor(Color.Red);
                    lines.Add(new Line(nodesInHull[length - 1], node, Color.Red));

                    nodesInHull.RemoveAt(length - 1);

                    length = nodesInHull.Count;
                }

                lines.Add(new Line(nodesInHull[length - 1], node, Color.Green));

                nodesInHull.Add(node);
            }

            lines.Add(new Line(sortedNodes[sortedNodes.Count - 1], baseNode, Color.Green));

            count = lines.Count;

            return count;
        }

        /// <summary>
        /// Finds the starting node for Graham Scan algorithm
        /// </summary>
        /// <param name="nodes">List of nodes on graph</param>
        /// <returns>The lowest, leftmost node</returns>
        private Node FindBaseNode(List<Node> nodes)
        {
            Node baseNode = nodes[0];

            foreach (Node node in nodes)
            {
                if (node.Y > baseNode.Y)
                {
                    baseNode = node;
                }
            }

            return baseNode;
        }

        /// <summary>
        /// Calculates and sorts a list of nodes by angel
        /// </summary>
        /// <param name="nodes">The nodes to sort</param>
        /// <param name="baseNode">The node to sort with respect to</param>
        /// <returns>A list of nodes sorted by angle from the base node counter-clockwise</returns>
        private List<Node> SortByAngle(List<Node> nodes, Node baseNode)
        {
            var nodeAngles = new Dictionary<Node, Double>();

            foreach (Node node in nodes)
            {
                if (node == baseNode)
                {
                    continue;
                }

                double angle = AngleBetweenPoints(baseNode, node);

                nodeAngles.Add(node, angle);
            }

            List<KeyValuePair<Node, Double>> nodeAngleList = nodeAngles.ToList();

            nodeAngleList.Sort(
                (firstPair, secondPair) =>
                {
                    return firstPair.Value.CompareTo(secondPair.Value);
                });

            List<Node> sortedNodes = new List<Node>();

            foreach (KeyValuePair<Node, Double> node in nodeAngleList)
            {
                sortedNodes.Add(node.Key);
            }

            return sortedNodes;
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

        /// <summary>
        /// Calculates the angle between two nodes
        /// </summary>
        /// <param name="nodeA">Base node, assumed to be lowest of both nodes</param>
        /// <param name="nodeB">Measured node, should be equal to or higher in height than base node</param>
        /// <returns>The angle, in degrees, between the two nodes; angle is on [0, 180] degrees</returns>
        private double AngleBetweenPoints(Node nodeA, Node nodeB)
        {
            int yPrime = nodeA.Y - nodeB.Y;
            int xPrime = nodeA.X - nodeB.X;

            double z = Math.Sqrt(xPrime * xPrime + yPrime * yPrime);

            double angle = (180 / Math.PI) * Math.Asin(yPrime / z);

            if (xPrime == 0)
            {
                return 90;
            }
            else if (xPrime > 0)
            {
                return 180 - angle;
            }
            else
            {
                return angle;
            }
        }
    }
}
