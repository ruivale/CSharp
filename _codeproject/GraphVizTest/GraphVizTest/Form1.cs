using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphVizTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String GrapgVizString = @"digraph g 
            {ratio = fill;
            node[style = filled]
            label = ""Andre van Dun "";
            InitialInitial->AwaitingAnalysis[color=""0.650 0.700 0.700""] [label =""manual""];
            subgraph cluster0 
            {label = ""Initial "";
            GroomingGrooming->GroomingFinished[label =""manual""];
            GroomingFinished[color=""0.449 0.447 1.000""]Groomingnever[color=""0.000 1.000 1.000""]
            }
            AwaitingAnalysis[color=""0.590 0.273 1.000""]
            AwaitingAnalysis->AwaitingDevelopment[color=""0.650 0.700 0.700""][label =""manual""];
            AwaitingDevelopment[color=""0.590 0.273 1.000""]
            AwaitingDevelopment->InDevelopment[color=""0.650 0.700 0.700""] [label =""manual""];
            AwaitingDevelopment->AwaitingDelivery[color=""0.650 0.700 0.700""] [label =""manual""];
            InDevelopment[color=""0.590 0.273 1.000""]
            InDevelopment->AwaitingDelivery[color=""0.650 0.700 0.700""] [label =""manual""];
            AwaitingDelivery[color=""0.449 0.447 1.000""]}";

            ///Option 1
            //pictureBox1.Image = Examples.Run(GrapgVizString);
            ///Option 2
            pictureBox1.Image = Examples.Graphviz.RenderImage(GrapgVizString, "jpg");
            this.Size = pictureBox1.Image.Size;

        }
    }
}
