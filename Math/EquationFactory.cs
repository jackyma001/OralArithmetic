using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public class EquationFactory
    {
        private List<Equation> _equations = new List<Equation>();
        public EquationFactory(int plusNum, int subNum, int multiNum, int divNum)
        {
            for (int i = 0; i < plusNum; i++)
            {
                this._equations.Add(this.CreateUniqueEquation<PlusEquation>());
            }
            for (int i = 0; i < plusNum; i++)
            {
                this._equations.Add(this.CreateUniqueEquation<SubEquation>());
            }
            for (int i = 0; i < plusNum; i++)
            {
                this._equations.Add(this.CreateUniqueEquation<MultiplayEquation>());
            }
            for (int i = 0; i < plusNum; i++)
            {
                this._equations.Add(this.CreateUniqueEquation<DivdeEquation>());
            }
        }

        public EquationFactory(int num)
        {
            for (int i = 0; i < num; i++)
            {
                this._equations.Add(this.CreateUniqueEquation<DivdeEquationWith3d2>());
            }
        }

        public List<Equation> Equations
        {
            get { return this._equations; }
        }

        private Equation CreateUniqueEquation<T>()
            where T: Equation,new()
        {
            Equation result = new T();
            while (this._equations.Contains(result))
            {
                result = new T();
            }
            return result;
        }
    }
}
