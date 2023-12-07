using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    public class Table
    {
        public int i;
        public string D;


        //private bool checkInsertValue(char str)
        //{
        //    if(!Data.Values.Contains(str))
        //        return true;
        //    else 
        //        return false;
        //}
        //public void insertTable(char str)
        //{

        //        if (checkInsertValue(str))
        //        {
        //            Data.Add(0, str);
        //        }
        //        else
        //        {
        //            var index = Data.Where(p => p.Value == str).FirstOrDefault();

        //        }

        //}
        public Table(int index, string sym)
        {
            i = index;
            D = sym;
        }
    }

    public class Program
    {
        public static List<Table> listTable = new List<Table>();

        static void Main(string[] args)
        {
            Console.Write("Введите строку>>");
            string str = Console.ReadLine();
            str = str.Replace(' ', '_');
            str = str + "\0";
            Console.WriteLine(str);

            Table tb;
            tb = new Table(0, "");
            int index = 1;
            int ss = 0;
            List<Tuple<int, char>> Data = new List<Tuple<int, char>>();
            listTable.Add(tb);
            var ksss = Tuple.Create(0, '\0');
            Data.Add(ksss);

            for (int i = 0; i < str.Length; i++)
            {
                if (listTable.Where(p => p.D == str[i].ToString()).Count() > 0)
                {
                    string strNew = str[i].ToString();

                    do
                    {
                        i++;
                        strNew += str[i].ToString();
                    }
                    while (listTable.Where(p => p.D == strNew.ToString()).Count() > 0);
                    ss = listTable.Where(p => p.D == strNew.Substring(0, strNew.Length - 1).ToString()).Select(p => p.i).FirstOrDefault();
                    tb = new Table(index, strNew.ToString());
                    listTable.Add(tb);
                    var ks = Tuple.Create(ss, str[i]);
                    Data.Add(ks);
                }
                else
                {
                    tb = new Table(index, str[i].ToString());
                    listTable.Add(tb);
                    var ks = Tuple.Create(0, str[i]);
                    Data.Add(ks);
                }
                index++;
            }
            int count = 0;
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Item2 == '\0' && count > 0)
                {
                    Console.WriteLine($"{listTable[i].i}\t\"{listTable[i].D}\"\t({Data[i].Item1},\'\\0\')");

                }
                else
                    Console.WriteLine($"{listTable[i].i}\t\"{listTable[i].D}\"\t({Data[i].Item1},\'{Data[i].Item2}\')");
                count++;
            }
            count = 0;
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Item2 == '\0' && count > 0)
                {
                    Console.Write($"({Data[i].Item1},\'\\0\')");

                }
                else
                    Console.Write($"({Data[i].Item1},\'{Data[i].Item2}\')");
                count++;
            }
            Console.ReadKey();
        }
    }
}
