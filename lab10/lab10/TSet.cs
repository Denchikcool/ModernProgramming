using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class TSet<T> where T : new()
    {
        public HashSet<T> LocalSet;

        public TSet()
        {
            LocalSet = new HashSet<T>();
        }

        public void Clear()
        {
            LocalSet.Clear();
        }

        public void Add(T element)
        {
            LocalSet.Add(element);
        }

        public void Remove(T element)
        {
            LocalSet.Remove(element);
        }

        public bool IsClear()
        { 
            return LocalSet.Count == 0;
        }

        public bool Contains(T element)
        {
            return LocalSet.Contains(element);
        }

        public int Count()
        {
            return this.LocalSet.Count();
        }

        public T ElementAt(int index)
        {
            try
            {
                object needed = this.LocalSet.ElementAt(index);
                return (T)needed;
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public String Show()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{ ");
            foreach (T element in this.LocalSet)
            {
                sb.Append($"{element.GetType().GetMethod("Show")?.Invoke(element, null) ?? element} ");
            }
            sb.Append("}");
            return sb.ToString();
        }

        public TSet<T> Union(TSet<T> other)
        {
            TSet<T> newSet = new TSet<T>();

            foreach (T element in this.LocalSet)
            {
                newSet.Add(element);
            }

            foreach (T element in other.LocalSet)
            {
                newSet.Add(element);
            }

            return newSet;
        }

        public TSet<T> Except(TSet<T> other)
        {
            TSet<T> newSet = new TSet<T>();

            foreach (T element in this.LocalSet)
            {
                newSet.Add(element);
            }

            foreach (T element in other.LocalSet)
            {
                newSet.Remove(element);
            }

            return newSet;
        }

        public TSet<T> Intersect(TSet<T> other)
        {
            TSet<T> newSet = new TSet<T>();

            foreach (T element in this.LocalSet)
            {
                if (other.Contains(element))
                {
                    newSet.Add(element);
                }
            }

            return newSet;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TSet<T> otherSet))
            {
                return false;
            }

            if (this.LocalSet.Count != otherSet.LocalSet.Count)
            {
                return false;
            }

            foreach (T item in this.LocalSet)
            {
                if (!otherSet.LocalSet.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public TSet<T> Copy()
        {
            return (TSet<T>)this.MemberwiseClone();
        }
    }
}
