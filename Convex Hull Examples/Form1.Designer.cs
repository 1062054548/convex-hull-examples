namespace Convex_Hull_Examples
{
    partial class ExampleWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ModelOutput = new System.Windows.Forms.PictureBox();
            this.BtnNextStep = new System.Windows.Forms.Button();
            this.BtnPrevStep = new System.Windows.Forms.Button();
            this.StepTrackBar = new System.Windows.Forms.TrackBar();
            this.LstNodeList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadGrahamScan = new System.Windows.Forms.RadioButton();
            this.RadBruteForce = new System.Windows.Forms.RadioButton();
            this.Btn50Nodes = new System.Windows.Forms.Button();
            this.Btn250Nodes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnAddXNodes = new System.Windows.Forms.Button();
            this.TxbNumberofNodes = new System.Windows.Forms.TextBox();
            this.StepLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ModelOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModelOutput
            // 
            this.ModelOutput.Location = new System.Drawing.Point(12, 12);
            this.ModelOutput.Name = "ModelOutput";
            this.ModelOutput.Size = new System.Drawing.Size(200, 200);
            this.ModelOutput.TabIndex = 0;
            this.ModelOutput.TabStop = false;
            // 
            // BtnNextStep
            // 
            this.BtnNextStep.Location = new System.Drawing.Point(159, 218);
            this.BtnNextStep.Name = "BtnNextStep";
            this.BtnNextStep.Size = new System.Drawing.Size(52, 35);
            this.BtnNextStep.TabIndex = 1;
            this.BtnNextStep.Text = "Next Step";
            this.BtnNextStep.UseVisualStyleBackColor = true;
            this.BtnNextStep.Click += new System.EventHandler(this.BtnNextStep_Click);
            // 
            // BtnPrevStep
            // 
            this.BtnPrevStep.Location = new System.Drawing.Point(12, 218);
            this.BtnPrevStep.Name = "BtnPrevStep";
            this.BtnPrevStep.Size = new System.Drawing.Size(57, 35);
            this.BtnPrevStep.TabIndex = 2;
            this.BtnPrevStep.Text = "Prev. Step";
            this.BtnPrevStep.UseVisualStyleBackColor = true;
            this.BtnPrevStep.Click += new System.EventHandler(this.BtnPrevStep_Click);
            // 
            // StepTrackBar
            // 
            this.StepTrackBar.Location = new System.Drawing.Point(12, 259);
            this.StepTrackBar.Name = "StepTrackBar";
            this.StepTrackBar.Size = new System.Drawing.Size(199, 45);
            this.StepTrackBar.TabIndex = 3;
            this.StepTrackBar.ValueChanged += new System.EventHandler(this.StepTrackBar_ValueChanged);
            // 
            // LstNodeList
            // 
            this.LstNodeList.FormattingEnabled = true;
            this.LstNodeList.Location = new System.Drawing.Point(218, 28);
            this.LstNodeList.Name = "LstNodeList";
            this.LstNodeList.Size = new System.Drawing.Size(102, 251);
            this.LstNodeList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Node List";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadGrahamScan);
            this.groupBox1.Controls.Add(this.RadBruteForce);
            this.groupBox1.Location = new System.Drawing.Point(327, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 66);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithms";
            // 
            // RadGrahamScan
            // 
            this.RadGrahamScan.AutoSize = true;
            this.RadGrahamScan.Location = new System.Drawing.Point(7, 43);
            this.RadGrahamScan.Name = "RadGrahamScan";
            this.RadGrahamScan.Size = new System.Drawing.Size(90, 17);
            this.RadGrahamScan.TabIndex = 3;
            this.RadGrahamScan.TabStop = true;
            this.RadGrahamScan.Text = "Graham Scan";
            this.RadGrahamScan.UseVisualStyleBackColor = true;
            this.RadGrahamScan.CheckedChanged += new System.EventHandler(this.AlgorithmChanged);
            // 
            // RadBruteForce
            // 
            this.RadBruteForce.AutoSize = true;
            this.RadBruteForce.Location = new System.Drawing.Point(7, 20);
            this.RadBruteForce.Name = "RadBruteForce";
            this.RadBruteForce.Size = new System.Drawing.Size(80, 17);
            this.RadBruteForce.TabIndex = 0;
            this.RadBruteForce.TabStop = true;
            this.RadBruteForce.Text = "Brute Force";
            this.RadBruteForce.UseVisualStyleBackColor = true;
            this.RadBruteForce.CheckedChanged += new System.EventHandler(this.AlgorithmChanged);
            // 
            // Btn50Nodes
            // 
            this.Btn50Nodes.Location = new System.Drawing.Point(6, 19);
            this.Btn50Nodes.Name = "Btn50Nodes";
            this.Btn50Nodes.Size = new System.Drawing.Size(107, 23);
            this.Btn50Nodes.TabIndex = 7;
            this.Btn50Nodes.Text = "New 10 Nodes";
            this.Btn50Nodes.UseVisualStyleBackColor = true;
            this.Btn50Nodes.Click += new System.EventHandler(this.Btn50Nodes_Click);
            // 
            // Btn250Nodes
            // 
            this.Btn250Nodes.Location = new System.Drawing.Point(6, 49);
            this.Btn250Nodes.Name = "Btn250Nodes";
            this.Btn250Nodes.Size = new System.Drawing.Size(107, 23);
            this.Btn250Nodes.TabIndex = 8;
            this.Btn250Nodes.Text = "New 50 Nodes";
            this.Btn250Nodes.UseVisualStyleBackColor = true;
            this.Btn250Nodes.Click += new System.EventHandler(this.Btn250Nodes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnAddXNodes);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.TxbNumberofNodes);
            this.groupBox2.Controls.Add(this.Btn250Nodes);
            this.groupBox2.Controls.Add(this.Btn50Nodes);
            this.groupBox2.Location = new System.Drawing.Point(327, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 179);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Nodes";
            // 
            // BtnAddXNodes
            // 
            this.BtnAddXNodes.Location = new System.Drawing.Point(50, 130);
            this.BtnAddXNodes.Name = "BtnAddXNodes";
            this.BtnAddXNodes.Size = new System.Drawing.Size(63, 43);
            this.BtnAddXNodes.TabIndex = 9;
            this.BtnAddXNodes.Text = "New Nodes";
            this.BtnAddXNodes.UseVisualStyleBackColor = true;
            this.BtnAddXNodes.Click += new System.EventHandler(this.BtnAddXNodes_Click);
            // 
            // TxbNumberofNodes
            // 
            this.TxbNumberofNodes.Location = new System.Drawing.Point(7, 142);
            this.TxbNumberofNodes.MaxLength = 3;
            this.TxbNumberofNodes.Name = "TxbNumberofNodes";
            this.TxbNumberofNodes.Size = new System.Drawing.Size(37, 20);
            this.TxbNumberofNodes.TabIndex = 10;
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(75, 229);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(34, 13);
            this.StepLabel.TabIndex = 10;
            this.StepLabel.Text = "Steps";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(7, 79);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 57);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Enter a number between 3 and 175 and press the button below";
            // 
            // ExampleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 298);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstNodeList);
            this.Controls.Add(this.StepTrackBar);
            this.Controls.Add(this.BtnPrevStep);
            this.Controls.Add(this.BtnNextStep);
            this.Controls.Add(this.ModelOutput);
            this.MaximumSize = new System.Drawing.Size(474, 336);
            this.MinimumSize = new System.Drawing.Size(474, 336);
            this.Name = "ExampleWindow";
            this.Text = "Convex Hull Examples";
            this.Load += new System.EventHandler(this.ExampleWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ModelOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNextStep;
        private System.Windows.Forms.Button BtnPrevStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn50Nodes;
        private System.Windows.Forms.Button Btn250Nodes;
        public System.Windows.Forms.PictureBox ModelOutput;
        public System.Windows.Forms.TrackBar StepTrackBar;
        public System.Windows.Forms.ListBox LstNodeList;
        public System.Windows.Forms.RadioButton RadGrahamScan;
        public System.Windows.Forms.RadioButton RadBruteForce;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxbNumberofNodes;
        private System.Windows.Forms.Button BtnAddXNodes;
        public System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}

