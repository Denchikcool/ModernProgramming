using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class TPoly
    {
        public SortedSet<TMember> Members;

        public TPoly()
        {
            Members = new SortedSet<TMember>();
            Members.Add(new TMember(0, 0));
        }

        public TPoly(int c, int n)
        {
            Members = new SortedSet<TMember>();
            Members.Add(new TMember(c, n));
        }

        public TPoly Add(TPoly other)
        {
            TPoly newPoly = new TPoly();

            foreach(TMember m in other.Members)
            {
                newPoly.Members.Add(new TMember(m.FCoefficent, m.FDegree));
            }

            foreach(TMember m in this.Members)
            {
                newPoly.Members.Add(new TMember(m.FCoefficent, m.FDegree));
            }

            return newPoly;
        }

        public TPoly Mul(TPoly other)
        {
            TPoly newPoly = new TPoly();

            foreach(TMember m in other.Members)
            {
                foreach(TMember newM in this.Members)
                {
                    newPoly.Members.Add(new TMember(newM.FCoefficent * m.FCoefficent, newM.FDegree + m.FDegree));
                }
            }

            return newPoly;
        }

        public TPoly Sub(TPoly other)
        {
            TPoly newPoly = new TPoly();

            foreach(TMember m in other.Members)
            {
                newPoly.Members.Add(new TMember(-m.FCoefficent, m.FDegree));
            }

            foreach(TMember m in this.Members)
            {
                newPoly.Members.Add(new TMember(m.FCoefficent, m.FDegree));
            }

            return newPoly; 
        }

        public TPoly Minus()
        {
            TPoly newPoly = new TPoly();

            foreach(TMember m in this.Members)
            {
                newPoly.Members.Add(new TMember(-m.FCoefficent, m.FDegree));
            }

            return newPoly;
        }

        public override bool Equals(object obj)
        {
            if (((TPoly)obj).Members.SequenceEqual(this.Members))
                return true;
            else
                return false;
        }

        public TPoly Diff()
        {
            TPoly newPoly = new TPoly();

            foreach(TMember m in this.Members)
            {
                newPoly.Members.Add(new TMember(m.FCoefficent, m.FDegree).Differentiate());
            }

            return newPoly;
        }

        public double Calculate(double a)
        {
            double result = 0.0;

            foreach(TMember m in this.Members)
            {
                result += m.Calculate(a);
            }

            return result;
        }

        public Tuple<int, int> TakeElement(int i)
        {
            if(i > 0 && i < Members.Count)
            {
                return Tuple.Create(
                    this.Members.Reverse().ElementAt(i).FCoefficent,
                    this.Members.Reverse().ElementAt(i).FDegree
                    );
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Clear()
        {
            Members = new SortedSet<TMember>
            {
                new TMember(0, 0),
            };
        }

        public int ReturnDegree()
        {
            return Members.Last().FDegree;
        }

        public int ReturnCoefficent(int n)
        {
            if(n >= Members.First().FDegree && n <= Members.Last().FDegree)
            {
                return Members.Single(x => x.FDegree == n).FCoefficent;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public string Show()
        {
            string str = "";

            foreach(TMember m in this.Members.Reverse())
            {
                str += (m.FCoefficent > 0) ? "+" : "";
                str += m.TMemberToString();
            }

            return str.TrimStart('+');
        }
    }
}
