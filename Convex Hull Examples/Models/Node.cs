using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Convex_Hull_Examples.Models
{
    class Node
    {
        private int x, y;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        private Color nodeColor;
        public Color NodeColor
        {
            get { return nodeColor; }
        }

        /// <summary>
        /// Constructor for node model
        /// </summary>
        /// <param name="xCoord">The x-position of the node</param>
        /// <param name="yCoord">The y-position of the node</param>
        /// <param name="color">The color of the node when drawn</param>
        public Node(int xCoord, int yCoord, Color color)
        {
            x = xCoord;
            y = yCoord;
            nodeColor = color;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", X.ToString("000"), Y.ToString("000"));
        }

    }
}
