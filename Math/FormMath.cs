using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            WordPrintHelper printer = new WordPrintHelper();
            
            int copies = 1;
            bool IsMutipuleCopies = int.TryParse(txtCopies.Text,out copies);
            if(!IsMutipuleCopies)
            {
                return;
            }

            List<string> files = new List<string>();
            for (int i = 0; i < copies; i++)
            {
                EquationFactory factory = new EquationFactory(15, 15, 15, 15);
                DocGenerator docGenerator = new DocGenerator(factory.Equations);
			    string file = docGenerator.Run(0);
                printer.Printword(file, "");
                files.Add(file);
            }
   
		}

        private void button1_Click(object sender, EventArgs e)
        {
            WordPrintHelper printer = new WordPrintHelper();
            EquationFactory factory = new EquationFactory(int.Parse(txtShushi.Text));
            DocGenerator docGenerator = new DocGenerator(factory.Equations);
            Process.Start(docGenerator.Run(4));
            //printer.Printword(docGenerator.Run(4),"");
        }
    }
}
