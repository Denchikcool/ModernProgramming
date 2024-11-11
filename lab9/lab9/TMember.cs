using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class TMember : IComparable<TMember>
    {
        private int _fcoefficent;
        private int _fdegree;

        public int FCoefficent
        {
            get { return _fcoefficent; }
            set
            {
                if (value == 0)
                {
                    _fdegree = 0;
                }
                _fcoefficent = value;
            }
        }

        public int FDegree
        {
            get { return _fdegree; }
            set
            {
                if(_fcoefficent == 0)
                {
                    _fdegree = 0;
                }
                else _fdegree = value;
            }
        }

        public TMember(int coeff = 0, int degree = 0)
        {
            FCoefficent = coeff;
            FDegree = degree;
        }

        public override bool Equals(object obj)
        {
            if((((TMember)obj).FCoefficent == this.FCoefficent) && (((TMember)obj).FDegree == this.FDegree))
                return true;
            else 
                return false;
        }

        public TMember Differentiate()
        {
            return new TMember()
            {
                FCoefficent = (this.FCoefficent * this.FDegree),
                FDegree = (this.FDegree - 1)
            };
        }

        public double Calculate(double a)
        {
            return this.FCoefficent * Math.Pow(a, this.FDegree);
        }

        public string TMemberToString()
        {
            return (this.FCoefficent == 0) ? "" : $"{this.FCoefficent}x^{this.FDegree}";
        }

        public int CompareTo(TMember other)
        {
            if(this.FDegree.CompareTo(other.FDegree) != 0)
                return this.FDegree.CompareTo(other.FDegree);
            else
            {
                other.FCoefficent += this.FCoefficent;
                return 0;
            }
        }
    }
}
