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

        public int Item1
        {
            get;set;
        }

        public int Item2
        {
            get;set;
        }
		public string Print()
        {
            return string.Format(Equation.Formater, this.Item1, this.Operator, this.Item2);
        }
            

		public override bool Equals(object obj)
		{
            return this.Print() == ((Equation)obj).Print();
		}
	}

	public class PlusEquation : Equation
	{
        public PlusEquation()
        {
            this.Item1 = MyRandom.Next(20, 900);
            this.Item2 = MyRandom.Next(20, 99);
        }

		public override string Operator
		{
			get
			{
				return "＋";
			}
		}
	}

	public class MultiplayEquation : Equation
	{
        public MultiplayEquation()
        {
            this.Item1 = MyRandom.Next(10,100);
            this.Item2 = MyRandom.Next(2, 10);
        }
		public override string Operator
		{
			get
			{
				return "×";
			}
		}
	}

    public class MultiplayEquationWith3m2 : Equation
    {
        public MultiplayEquationWith3m2()
        {
            this.Item1 = MyRandom.Next(101, 999);
            this.Item2 = MyRandom.Next(11, 99);
        }
        public override string Operator
        {
            get
            {
                return "×";
            }
        }
    }

    public class SubEquation : Equation
	{
        public SubEquation()
        {
            this.Item1 = MyRandom.Next(20, 1000);
            this.Item2 = MyRandom.Next(4, 100);
            while (this.Item1 <= this.Item2)
            {
                this.Item1 = MyRandom.Next(20, 1000);
                this.Item2 = MyRandom.Next(4, 100);
            }
        }

        public override string Operator
		{
			get
			{
				return "－";
			}
		}
	}

	public class DivdeEquation : Equation
	{
        public DivdeEquation()
        {
            int a = MyRandom.Next(22, 1000);
            int b = MyRandom.Next(2, 10);
            while (a % b != 0 || a / b < 10)
            {
                a = MyRandom.Next(22, 1000);
                b = MyRandom.Next(2, 10);
            }
            this.Item1 = a;
            this.Item2 = b;
        }

        public override string Operator
		{
			get
			{
				return "÷";
			}
		}
	}
}