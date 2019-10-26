using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Math
{
	public partial class FormMath : Form
	{
		public FormMath()
		{
			InitializeComponent();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
            EquationFactory factory = new EquationFactory(15, 15, 15, 15);
            DocGenerator docGenerator = new DocGenerator(factory.Equations);
			docGenerator.Run(0);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            EquationFactory factory = new EquationFactory(int.Parse(txtShushi.Text));
            DocGenerator docGenerator = new DocGenerator(factory.Equations);
            docGenerator.Run(3);
        }
    }
}
