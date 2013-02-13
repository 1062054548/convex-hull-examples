using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Convex_Hull_Examples.Models
{
    class Line
    {
        private Node node1, node2;
        private Color lineColor;

        /// <summary>
        /// Constructor for node model
        /// </summary>
        /// <param name="node1">The first of two nodes the line connects</param>
        /// <param name="node2">The second of two nodes that the line connects</param>
        /// <param name="color">The color of the line when drawn</param>
        public Line(Node node1, Node node2, Color color)
        {
            if (node1.X < node2.X || node1.X == node2.X && node1.Y < node2.Y)
            {
                this.node1 = node1;
                this.node2 = node2;
            }
            else
            {
                this.node1 = node2;
                this.node2 = node1;
            }
            lineColor = color;
        }

        /// <summary>
        /// Returns the left-most node or upper-most node if line is vertical
        /// </summary>
        /// <returns>The leftmost or upper node</returns>
        public Node GetFirstEndpoint()
        {
            return node1;
        }

        /// <summary>
        /// Returns the right-most node or lowest node if line is vertical
        /// </summary>
        /// <returns>The rightmost or lowest node</returns>
        public Node GetSecondEndpoint()
        {
            return node2;
        }

        /// <summary>
        /// Returns the line's color
        /// </summary>
        /// <returns>The line's color</returns>
        public Color GetColor()
        {
            return lineColor;
        }

        /// <summary>
        /// Sets the color of the line
        /// </summary>
        /// <param name="color">Color to tset the line to</param>
        public void SetColor(Color color)
        {
            lineColor = color;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}:{2}", lineColor.ToString(), 
                GetFirstEndpoint().ToString(), GetSecondEndpoint().ToString()); 
        }
    }
}
