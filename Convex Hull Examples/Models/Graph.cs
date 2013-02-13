using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Convex_Hull_Examples.Models
{
    class Graph
    {
        private Image self;
        public Image GraphImage
        {
            get { return self; }
        }

        private int radius;

        /// <summary>
        /// Constructor for graph model
        /// </summary>
        /// <param name="sizeX">Width of graph</param>
        /// <param name="sizeY">Height of graph</param>
        /// <param name="radius">Radius to draw nodes and lines</param>
        public Graph(int sizeX, int sizeY, int radius)
        {
            self = new Bitmap(sizeX, sizeY);
            this.radius = radius;
        }

        /// <summary>
        /// Draws a single line on the graph
        /// </summary>
        /// <param name="line">The line to draw</param>
        private void DrawLine(Line line)
        {
            Node endpoint1 = line.GetFirstEndpoint();
            Node endpoint2 = line.GetSecondEndpoint();

            Point point1 = new Point(endpoint1.X, endpoint1.Y);
            Point point2 = new Point(endpoint2.X, endpoint2.Y);

            using (Graphics g = Graphics.FromImage(self))
            {
                g.DrawLine(new Pen(line.GetColor(), radius), point1, point2);
            }
        }

        /// <summary>
        /// Draws a single node on the graph
        /// </summary>
        /// <param name="node">The node to draw</param>
        private void DrawNode(Node node)
        {
            float halfRadius = radius / 2.0f;
            using (Graphics g = Graphics.FromImage(self))
            {
                g.FillRectangle(new SolidBrush(node.NodeColor), node.X - halfRadius, node.Y - halfRadius, 2 * radius, 2 * radius);
            }
        }

        /// <summary>
        /// Draws a complete graph
        /// </summary>
        /// <param name="nodes">A list of nodes to draw</param>
        /// <param name="lines">A list of lines to draw</param>
        /// <param name="ClearGraphFirst">Determines if the current graph is wiped clear first or not</param>
        /// <returns>An image of the drawn graph</returns>
        public Image DrawGraph(List<Node> nodes, List<Line> lines, bool ClearGraphFirst)
        {
            if (ClearGraphFirst)
            {
                ClearImage();
            }

            foreach (Line line in lines)
            {
                DrawLine(line);
            }

            foreach (Node node in nodes)
            {
                DrawNode(node);
            }

            return self;
        }

        /// <summary>
        /// Replaces current image with a white canvas
        /// </summary>
        private void ClearImage()
        {
            using (Graphics g = Graphics.FromImage(self))
            {
                g.Clear(Color.White);
            }
        }
    }
}
