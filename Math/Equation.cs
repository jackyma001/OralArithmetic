using System;

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
		protected Random _r = new Random();
		public Equation()
		{
		}

		public abstract string Operator
		{
			get;
		}

		public abstract string Print();


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
			return string.Format("{0}{1}{2}=", MyRandom.Next(20, 900), this.Operator, MyRandom.Next(20, 99));
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
			this._r = new Random();
			return string.Format("{0}{1}{2}=", MyRandom.Next(10, 100), this.Operator, MyRandom.Next(2, 10));
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
			this._r = new Random();
			int a = MyRandom.Next(20, 1000);
			int b = MyRandom.Next(4, 100);
			while (a <= b)
			{
				a = MyRandom.Next(20, 1000);
				b = MyRandom.Next(4, 100);
			}
			return string.Format("{0}{1}{2}=", a, this.Operator, b);
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
			return string.Format("{0}{1}{2}=", a, this.Operator, b);
		}
	}
}