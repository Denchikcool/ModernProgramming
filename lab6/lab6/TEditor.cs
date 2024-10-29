using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public enum PartToEdit
    {
        Real, Imag
    };
    public enum NumberPartToEdit
    {
        Left, Right
    };

    public class TEditor
    {
        string pNum;
        PartToEdit mode;
        NumberPartToEdit numberMode;
        string zero = "0,+(i*0,)";
        string separatorParts = "(i*";
        string separatorNumber = ",";

        public TEditor()
        {
            pNum = zero;
            mode = PartToEdit.Real;
            numberMode = NumberPartToEdit.Left;
        }

        public bool IsZero()
        {
            string tmp = pNum;
            if (tmp[0] == '-')
                tmp = tmp.Substring(1);
            tmp = tmp.Replace('-', '+');
            if (tmp == zero)
                return true;
            else
                return false;
        }

        public string ToggleMinus()
        {
            if (mode == PartToEdit.Real)
            {
                if (pNum[0] == '-')
                    pNum = pNum.Substring(1);
                else
                    pNum = '-' + pNum;
            }
            else
            {
                int separatorIndex = pNum.IndexOf(separatorParts);
                if (pNum[separatorIndex-1] == '-'){
                    pNum = pNum.Substring(0, pNum.IndexOf(separatorParts) - 1) + "+" +
                       pNum.Substring(pNum.IndexOf(separatorParts));
                }
                else if(pNum[separatorIndex-1] == '+')
                {
                    pNum = pNum.Substring(0, pNum.IndexOf(separatorParts) - 1) + "-" +
                       pNum.Substring(pNum.IndexOf(separatorParts));
                }      
            }
            return pNum;
        }

        public PartToEdit ToggleMode()
        {
            if (mode == PartToEdit.Real)
                mode = PartToEdit.Imag;
            else
                mode = PartToEdit.Real;
            return mode;
        }

        public NumberPartToEdit ToggleNumberMode()
        {
            if (numberMode == NumberPartToEdit.Left)
                numberMode = NumberPartToEdit.Right;
            else
                numberMode = NumberPartToEdit.Left;
            return numberMode;
        }

        public string AddNumber(int a)
        {
            if (a < 0 || a > 9)
                return pNum;
            int ind = pNum.IndexOf(separatorParts);
            if (mode == PartToEdit.Real)
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    if (pNum[0] == '0')
                        pNum = a + pNum.Substring(1);
                    else if (pNum[0] == '-' && pNum[1] == '0')
                        pNum = '-' + a + pNum.Substring(2);
                    else
                    {
                        int frstNumbSep = pNum.IndexOf(separatorNumber);
                        pNum = pNum.Insert(frstNumbSep, a.ToString());
                    }
                }
                else
                    pNum = pNum.Insert(ind - 1, a.ToString());
            }
            else
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    ind += 2;
                    if (pNum[ind] == '0')
                        pNum = pNum.Substring(0, ind - 1) + a + pNum.Substring(ind + 1);
                    else
                    {
                        int lastNumbSep = pNum.LastIndexOf(',');
                        pNum = pNum.Insert(lastNumbSep, a.ToString());
                    }
                }
                else
                {
                    int separatorIndex = pNum.LastIndexOf(")");
                    pNum = pNum.Insert(separatorIndex, a.ToString());
                }
                    
            }
            return pNum;
        }

        public string AddZero()
        {
            return AddNumber(0);
        }

        public string DelNumber()
        {
            int ind = pNum.IndexOf(separatorParts);
            if (mode == PartToEdit.Real)
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    if (pNum[0] == '0')
                        return pNum;
                    else if (pNum[0] == '-' && pNum[1] == '0')
                        return pNum;
                    else
                    {
                        int frstNumbSep = pNum.IndexOf(separatorNumber);
                        pNum = pNum.Remove(frstNumbSep - 1, 1);
                        if (pNum[0] == ',')
                            pNum = '0' + pNum;
                    }
                }
                else
                {
                    int r = 0;
                    if (!int.TryParse(pNum[ind - 2].ToString(), out r))
                        return pNum;
                    pNum = pNum.Remove(ind - 2, 1);
                }
            }
            else
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    ind += 3;
                    if (pNum[ind] == '0')
                        return "0";
                    else
                    {
                        int lastNumbSep = pNum.LastIndexOf(',');
                        if (pNum[lastNumbSep - 2] == '*')
                            pNum = pNum.Substring(0, lastNumbSep - 1) + '0' + pNum.Substring(lastNumbSep);
                        else
                            pNum = pNum.Remove(lastNumbSep - 1, 1);
                    }
                }
                else
                {
                    if (pNum[pNum.Length - 2] == ',')
                        return pNum;
                    else
                        pNum = pNum.Remove(pNum.Length - 2, 1);
                }
            }
            return pNum;
        }

        public string Clear()
        {
            pNum = zero;
            mode = PartToEdit.Real;
            numberMode = NumberPartToEdit.Left;
            return pNum;
        }

        public void ShowEditInfo()
        {
            Console.WriteLine("\nВведите число:\n" +
                "0 - Изменить знак на противоположный\n" +
                "1 - Добавить цифру\n" +
                "2 - Добавить ноль\n" +
                "3 - Удалить цифру\n" +
                "4 - Очистить комплексное число\n" +
                "5 - Записать комплексное число\n" +
                "6 - Изменить режим работы между действительной и мнимой частью\n" +
                "7 - Изменить режим работы между целой и дробной частью\n" +
                "8 - Показать комплексное число\n");
        }
        public string Edit(int command)
        {
            switch (command)
            {
                case 0:
                    ToggleMinus();
                    Console.WriteLine($"Комплексное число с измененным знаком: {this.ReadNumber()}");
                    break;
                case 1:
                    {
                        Console.Write("Число для добавления: ");
                        int num;
                        string input = Console.ReadLine();
                        num = int.Parse(input);
                        AddNumber(num);
                        Console.WriteLine($"Комплексное число с добавленным цифрой: {this.ReadNumber()}");
                        break;
                    }
                case 2:
                    AddZero();
                    Console.WriteLine($"Комплексное число с добавленным нулём: {this.ReadNumber()}");
                    break;
                case 3:
                    DelNumber();
                    Console.WriteLine($"Комплексное число с удаленной цифрой: {this.ReadNumber()}");
                    break;
                case 4:
                    Clear();
                    Console.WriteLine($"Очищенное комплексное число: {this.ReadNumber()}");
                    break;
                case 5:
                    {
                        Console.WriteLine("Введите комплексное число: ");
                        string inp;
                        inp = Console.ReadLine();
                        WriteNumber(inp);
                        Console.WriteLine($"Ваше комплексное число: {this.ReadNumber()}");
                        break;
                    }
                case 6:
                    Console.WriteLine("Режим работы между действительной и мнимой частью изменен.");
                    this.ToggleMode();
                    break;
                case 7:
                    Console.WriteLine("Режим работы между целой и дробной частью изменен.");
                    this.ToggleNumberMode();
                    break;
                case 8:
                    Console.WriteLine($"Показываю комплексное число: {this.ReadNumber()}");
                    break;

                default:
                    break;
            }
            return pNum;
        }

        public string WriteNumber(string otherNumber)
        {
            pNum = otherNumber;
            return pNum;
        }

        public string ReadNumber()
        {
            return pNum;
        }
    }
}
