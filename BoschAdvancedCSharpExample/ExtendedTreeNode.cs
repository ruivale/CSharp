using System;
using System.Windows.Forms;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// Summary description for ExtendedTreeNode.
	/// </summary>
	public class ExtendedTreeNode : TreeNode
	{
		public MainForm m_mainForm = null;
		
		public ExtendedTreeNode()
		{	
		}

		~ExtendedTreeNode()
		{
			Cleanup();
		}

		public virtual void RetrieveName()
		{
		}

		public virtual void Cleanup()
		{   
            /***
			if (m_mainForm != null)
			{
				m_mainForm.m_sdkLogfile.LogMessage(
					"ExtendedTreeNode", 
					"Cleanup",
					"SAMPLE",
					3,
					"Cleaning up node: " + this.Text);
			}
            /**/

			// Clean up each child node.
			foreach (TreeNode node in Nodes)
			{
				if (node is ExtendedTreeNode)
				{
					ExtendedTreeNode eNode = node as ExtendedTreeNode;
					eNode.Cleanup();
				}
			}

            try
            {
                Nodes.Clear();
            }
            catch (System.Exception e)
            {
                ;
            }
		}
	}
}
