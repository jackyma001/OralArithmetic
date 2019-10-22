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
			List<Equation> equations = new List<Equation>();
			for (int i = 0; i < 15; i++)
			{
				equations.Add(new PlusEquation());
				equations.Add(new MultiplayEquation());
				equations.Add(new SubEquation());
				equations.Add(new DivdeEquation());
			}

			DocGenerator docGenerator = new DocGenerator(equations.OrderBy(x => x.Operator).ToList());
			docGenerator.Run();
		}
	}
}
