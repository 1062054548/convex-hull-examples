using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Convex_Hull_Examples.Models
{
    class MasterModel
    {
        private List<Line> lines;
        private List<Node> nodes;
        private ExampleWindow view;
        private Graph graph;

        /// <summary>
        /// Constructor for MasterModel class
        /// </summary>
        /// <param name="window">Handle to the user interface</param>
        /// <param name="radius">Radius to draw nodes and lines</param>
        public MasterModel(ExampleWindow window, int radius)
        {
            view = window;
            view.StepTrackBar.Minimum = 0;
            view.StepTrackBar.Maximum = 0;

            graph = new Graph(view.ModelOutput.Width, view.ModelOutput.Height, radius);
            lines = new List<Line>();
            nodes = new List<Node>();
        }

        /// <summary>
        /// Retrieves the list of nodes in the model
        /// </summary>
        /// <returns>A list of nodes</returns>
        public List<Node> GetNodeList()
        {
            return nodes;
        }

        /// <summary>
        /// Sets the nodes and lines of a model
        /// </summary>
        /// <param name="nodes">Nodes that the model should hold</param>
        /// <param name="lines">Lines that the model should hold</param>
        public void SetElements(List<Node> nodes, List<Line> lines)
        {
            this.nodes = nodes;
            this.lines = lines;
        }

        /// <summary>
        /// Sets the step value of the view
        /// </summary>
        /// <param name="step">The step value to set the track bar on the view to</param>
        public void SetStepValue(int step)
        {
            if (step > view.StepTrackBar.Maximum)
            {
                view.StepTrackBar.Value = view.StepTrackBar.Maximum;
            }
            else if (step < 0)
            {
                view.StepTrackBar.Value = 0;
            }
            else
            {
                view.StepTrackBar.Value = step;
            }

            view.StepLabel.Text = String.Format("{0}/{1}", view.StepTrackBar.Value, view.StepTrackBar.Maximum);
        }

        /// <summary>
        /// Sets the maximum step value of the view
        /// </summary>
        /// <param name="steps">The total steps the model should be able to display</param>
        public void SetMaxStepValue(int steps)
        {
            if (steps <= 0)
              {
                return;
            }

            if (view.StepTrackBar.Value > steps)
            {
                view.StepTrackBar.Value = steps;
            }

            view.StepTrackBar.Maximum = steps;

            view.StepLabel.Text = String.Format("{0}/{1}", view.StepTrackBar.Value, view.StepTrackBar.Maximum);
        }

        /// <summary>
        /// Updates the node list on the view with the nodes in the model
        /// </summary>
        public void UpdateViewNodeList()
        {
            view.LstNodeList.Items.Clear();

            foreach (Node node in nodes)
            {
                view.LstNodeList.Items.Add(node.ToString());
            }

            view.LstNodeList.Refresh();
        }

        /// <summary>
        /// Draws the graph based on the lines and nodes in the model
        /// </summary>
        public void DrawGraph()
        {
            Image displayImage = graph.DrawGraph(nodes, lines, true);

            view.ModelOutput.Image = displayImage;
        }
    }
}
