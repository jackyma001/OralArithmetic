using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NPOI.XWPF.UserModel;

namespace Math
{
	public class DocGenerator
	{
		private XWPFDocument _doc = new XWPFDocument();
		private List<Equation> _equations = new List<Equation>();
		public DocGenerator(IList<Equation> equations)
		{
			this._equations = equations.ToList();
		}

		public void Run()
		{
			XWPFParagraph head = this._doc.CreateParagraph();

			string line = string.Empty;
			for (int i = 0; i < this._equations.Count + 1; i++)
			{
				if (i != 0 && i % 3 == 0 && i != 60)
				{
					XWPFParagraph p1 = this._doc.CreateParagraph();
					XWPFRun r1 = p1.CreateRun();
					r1.SetText(line);
					r1.SetTextPosition(10);
					r1.SetFontFamily("Arial", FontCharRange.HAnsi);
                    r1.FontSize = 18;
                
					line = string.Empty;
				}
				if (i != 60)
				{
					line = line + this._equations[i].Print() + "                  ";
				}
				else
				{
					XWPFParagraph p1 = this._doc.CreateParagraph();
					XWPFRun r1 = p1.CreateRun();
					r1.SetText(line);
					r1.SetTextPosition(10);
					r1.SetFontFamily("Arial", FontCharRange.HAnsi);
                    r1.FontSize = 18;
				}
			}
			string fileName = DateTime.Now.ToShortDateString().Replace("/", "_")+(new Random()).Next().ToString();
			string fullPath = string.Format("c:\\test\\{0}.docx", fileName);
			FileStream out1 = new FileStream(fullPath, FileMode.Create);
			this._doc.Write(out1);
			out1.Close();
			Process.Start(fullPath);
		}
	}
}
