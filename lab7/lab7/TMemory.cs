using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Linq.Expressions;

namespace lab7
{
    public class TMemory<T> where T : new()
    {
        public T data;
        private bool _state = false;

        public TMemory()
        {
            if (typeof(T) == typeof(string) || typeof(T) == typeof(char))
            {
                throw new ArgumentException($"Тип данных {typeof(T)} не поддерживает математические операции.");
            }
            data = default(T);
            _state = false;
        }

        public TMemory(T initData)
        {
            if (typeof(T) == typeof(string) || typeof(T) == typeof(char))
            {
                throw new ArgumentException($"Тип данных {typeof(T)} не поддерживает математические операции.");
            }
            data = initData;
            _state = false;
        }

        public void WriteMemory(T number)
        {
            data = number;
            _state = true;
        }

        public T Get()
        {
            if (!_state)
            {
                throw new InvalidOperationException("Память не записана.");
            }
            _state = false;
            return data;
        }

        public void Add(T addComplex)
        {
            data = (dynamic)data + (dynamic)addComplex;
            _state = true;
        }

        public void Clear()
        {
            data = default(T);
            _state = false;
        }

        public bool ReadState()
        {
            return _state;
        }

        public T ReadNumber()
        {
            return data;
        }
    }
}
