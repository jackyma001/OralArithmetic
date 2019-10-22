using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using NPOI.XWPF.UserModel;

namespace Math
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			XWPFDocument doc = new XWPFDocument();
			List<Equation> equations = new List<Equation>();
			Random r = new Random();

			for (int i = 0; i < 15; i++)
			{
				equations.Add(new PlusEquation());

			}
			for (int i = 0; i < 15; i++)
			{

				equations.Add(new MultiplayEquation());

			}
			for (int i = 0; i < 15; i++)
			{

				equations.Add(new SubEquation());

			}
			for (int i = 0; i < 15; i++)
			{

				equations.Add(new DivdeEquation());
			}

			string line = string.Empty;
			for (int i = 0; i < equations.Count; i++)
			{
				if (i != 0 && i % 3 == 0)
				{
					XWPFParagraph p1 = doc.CreateParagraph();
					XWPFRun r1 = p1.CreateRun();
					r1.SetText(line);
					r1.SetTextPosition(10);
					line = string.Empty;
				}
				line = line + equations[i].Print() + "                                                         ";
			}

			FileStream out1 = new FileStream("c:\\test.docx", FileMode.Create);
			doc.Write(out1);
			out1.Close();
			Process.Start(@"C:\test.docx");
		}
	}
}
