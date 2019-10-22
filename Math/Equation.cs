namespace Math
{

	public enum Operator
	{
		Plus,
		Sub,
		Mul,
		Divde
	}

	public abstract class Equation
	{
		protected const string Formater = "{0}{1}{2}=";
		/// <summary>
		/// Initializes a new instance of the <see cref="Equation"/> class.
		/// </summary>
		public Equation()
		{
		}

		public abstract string Operator
		{
			get;
		}

		public abstract string Print();

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}
	}

	public class PlusEquation : Equation
	{
		public override string Operator
		{
			get
			{
				return "+";
			}
		}

		public override string Print()
		{
			return string.Format(Equation.Formater, MyRandom.Next(20, 900), this.Operator, MyRandom.Next(20, 99));
		}
	}

	public class MultiplayEquation : Equation
	{
		public override string Operator
		{
			get
			{
				return "×";
			}
		}

		public override string Print()
		{
			return string.Format(Equation.Formater, MyRandom.Next(10, 100), this.Operator, MyRandom.Next(2, 10));
		}
	}

	public class SubEquation : Equation
	{
		public override string Operator
		{
			get
			{
				return "-";
			}
		}

		public override string Print()
		{
			int a = MyRandom.Next(20, 1000);
			int b = MyRandom.Next(4, 100);
			while (a <= b)
			{
				a = MyRandom.Next(20, 1000);
				b = MyRandom.Next(4, 100);
			}
			return string.Format(Equation.Formater, a, this.Operator, b);
		}
	}

	public class DivdeEquation : Equation
	{
		public override string Operator
		{
			get
			{
				return "÷";
			}
		}

		public override string Print()
		{
			int a = MyRandom.Next(22, 1000);
			int b = MyRandom.Next(2, 10);
			while (a % b != 0 || a / b < 10)
			{
				a = MyRandom.Next(22, 1000);
				b = MyRandom.Next(2, 10);
			}
			return string.Format(Equation.Formater, a, this.Operator, b);
		}
	}
}