using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Convex_Hull_Examples
{
    public partial class ExampleWindow : Form
    {
        Controller control;

        public ExampleWindow()
        {
            InitializeComponent();
        }

        private void ExampleWindow_Load(object sender, EventArgs e)
        {
            control = Controller.GetInstance(this, 2);
        }

        private void Btn50Nodes_Click(object sender, EventArgs e)
        {
            control.CreateNewNodes(10);
        }

        private void Btn250Nodes_Click(object sender, EventArgs e)
        {
            control.CreateNewNodes(50);
        }

        private void BtnNextStep_Click(object sender, EventArgs e)
        {
            if (StepTrackBar.Value < StepTrackBar.Maximum)
            {
                StepTrackBar.Value++;
            }
        }

        private void BtnPrevStep_Click(object sender, EventArgs e)
        {
            if (StepTrackBar.Value > StepTrackBar.Minimum)
            {
                StepTrackBar.Value--;
            }
        }

        private void AlgorithmChanged(object sender, EventArgs e)
        {
            if (RadBruteForce.Checked)
            {
                control.SetAlgorithm(Algorithms.AlgorithmEnum.BruteForce);
            }
            else if (RadGrahamScan.Checked)
            {
                control.SetAlgorithm(Algorithms.AlgorithmEnum.GrahamScan);
            }
        }

        private void StepTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (sender != this.StepTrackBar)
            {
                return;
            }
            else
            {
                control.SetStep(StepTrackBar.Value);
            }
        }

        private void BtnAddXNodes_Click(object sender, EventArgs e)
        {
            control.CreateNewNodes(TxbNumberofNodes.Text);
        }
    }
}
