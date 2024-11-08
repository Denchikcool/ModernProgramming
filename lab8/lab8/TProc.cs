using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class TProc<T> where T : new ()
    {
        public EOperation Operation;
        public EFunction Function;
        public T Lop_Res, Rop;

        public TProc()
        {
            Operation = EOperation.None;
            Function = EFunction.None;
            Lop_Res = default(T);
            Rop = default(T);
        }

        public TProc(T lop_res, T rop)
        {
            if (typeof(T) == typeof(string) || typeof(T) == typeof(char))
            {
                throw new ArgumentException($"Тип данных {typeof(T)} не поддерживает математические операции.");
            }
            Operation = EOperation.None;
            Function = EFunction.None;
            
            Lop_Res = lop_res;
            Rop = rop;
        }

        public void OperationClear()
        {
            Operation = EOperation.None;
        }

        public void OperationRun()
        {
            switch (Operation)
            {
                case EOperation.Add:
                    Lop_Res = (dynamic)Lop_Res + (dynamic)Rop;
                    break;
                case EOperation.Sub:
                    Lop_Res = (dynamic)Lop_Res - (dynamic)Rop;
                    break;
                case EOperation.Mul:
                    Lop_Res = (dynamic)Lop_Res * (dynamic)Rop;
                    break;
                case EOperation.Div:
                    if (Rop.Equals(default(T))) throw new DivideByZeroException("Деление на ноль не допускается!");
                    Lop_Res = (dynamic)Lop_Res / (dynamic)Rop;
                    break;
            }
        }

        public void OperationSet(int newOperation)
        {
            if(newOperation >= 0 && newOperation <= 4)
                Operation = (EOperation)newOperation;
            else throw new ArgumentException("Нет такой команды!");
        }

        public EOperation OperationGet()
        {
            return this.Operation;
        }

        public void FunctionClear()
        {
            Function = EFunction.None;
        }

        public void FunctionRun()
        {
            switch(Function)
            {
                case EFunction.Rev:
                    if (Rop.Equals(default(T)))
                        throw new DivideByZeroException("Нельзя делить на ноль!");

                    if (Rop.GetType().GetMethod("Rev")?.Invoke(Rop, null) == null)
                    {
                        Rop = 1 / (dynamic)Rop;
                    }
                    else Rop = (T)Rop.GetType().GetMethod("Rev")?.Invoke(Rop, null);
                    break;
                case EFunction.Sqr:
                    if (Rop.GetType().GetMethod("Sqr")?.Invoke(Rop, null) == null)
                    {
                        Rop = (dynamic)Rop * (dynamic)Rop;
                    }
                    else Rop = (T)Rop.GetType().GetMethod("Sqr")?.Invoke(Rop, null);
                    break;
            }
        }

        public void FunctionSet(int newFunction)
        {
            if(newFunction >= 0 && newFunction <= 2)
                Function = (EFunction)newFunction;

            else throw new ArgumentException("Нет такой функции!");
        }

        public EFunction GetFunction()
        {
            return this.Function;
        }

        public void Lop_Res_Set(T newLopres)
        {
            Lop_Res = newLopres;
        }

        public void Rop_Set(T newRopres)
        {
            Rop = newRopres;
        }

        public void ReSet()
        {
            Lop_Res = default(T);
            Rop = default(T);
        }

        public string RetLop_Res()
        {
            if (Lop_Res == null)
                return null; 

            object str = Lop_Res.GetType().GetMethod("Show")?.Invoke(Lop_Res, null) ?? Lop_Res;
            return str.ToString();
        }

        public T RetTLop_Res()
        {
            object str = Lop_Res.GetType().GetMethod("Copy")?.Invoke(null, new object[] { Lop_Res }) ?? Lop_Res;
            return (T)str;
        }

        public string RetRop()
        {
            if (Rop == null)
                return null;
            object str = Rop.GetType().GetMethod("Show")?.Invoke(Rop, null) ?? Rop;
            return str.ToString();
        }

        public T RetTRop()
        {
            object str = Rop.GetType().GetMethod("Copy")?.Invoke(null, new object[] { Rop }) ?? Rop;
            return (T)str;
        }

        public override bool Equals(object obj)
        {
            if (((this.Lop_Res.Equals(((TProc<T>)obj).Lop_Res))) && (this.Rop.Equals(((TProc<T>)obj).Rop)))
            {
                return true;
            }
            else return false;
        }
    }
}
