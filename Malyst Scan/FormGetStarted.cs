using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
	public partial class FormGetStarted : Form
	{
		public FormGetStarted()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void linkNewsuite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			((FormMain)this.MdiParent).mnuItemFileNewSuite.PerformClick();
		}

		private void linkInterpret_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			((FormMain)this.MdiParent).mnuRecognizeFolder.PerformClick();
		}
	}
}
