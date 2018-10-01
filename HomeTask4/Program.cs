using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
    class Puzzle
    {
        private int[] arr1;
        public Puzzle()
        {
            arr1 = new int[16];
            Mass m_a = new Mass();
            m_a.arr_f(arr1);
            m_a.Shuffle(arr1);
            int inv = inv_puzzle(arr1);
            show_puzzle(arr1);
            if (inv % 2 == 0)
            {
                Console.WriteLine("There is a solution");
            }
            else
                Console.WriteLine("There is no solution");
        }
        private void show_puzzle(int[] arr1)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (arr1[4 * i + j] != 0)
                        Console.Write("{0}\t", arr1[4 * i + j]);
                    else
                        Console.Write("\t");
                }
                Console.WriteLine();
            }
        }
        private int inv_puzzle(int[] arr1)
        {
            int inv = 0;
            for (int i = 0; i < 16; ++i)
                if (arr1[i] != 0)
                    for (int j = 0; j < i; ++j)
                        if (arr1[j] > arr1[i])
                            ++inv;
            for (int i = 0; i < 16; ++i)
                if (arr1[i] == 0)
                    inv += 1 + i / 4;
            return inv;
        }
    }
    class Mass
    {
        private static Random rng;
        private enum MyWeek { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }
        public void what_day()
        {
            int day = GetInt("Введите день месяца =>");
            int month = GetInt("Введите месяц (1-январь) =>");
            int year = GetInt("Введите год =>");
            //Преобразуем дату в юлианский календарь
            if (month == 1 || month == 2)
            {
                --year;
            }
            month -= 2;
            if (month < 0)
            {
                month += 12;
            }
            int c = year / 100;
            year %= 100;
            int dayOfWeek = (day + (13 * month - 1) / 5 + year + year / 4 + c / 4 - 2 * c + 777) % 7;
            Console.WriteLine((MyWeek)(dayOfWeek));
        }
        public void arr_f(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i;
        }
        public void Shuffle(int[] arr)
        {
            rng = new Random();
            int n = arr.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = arr[k];
                arr[k] = arr[n];
                arr[n] = value;
            }
        }
        public void show_mass(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public int check1()
        {
            for (; ; )
            {
                Console.Write(" : __\b\b");
                string str = Console.ReadLine();
                int a1 = 0;
                if ((!Int32.TryParse(str, out a1)) | (a1 < 0))
                {
                    Console.WriteLine("Try again...");
                }
                else
                    return a1;
            }
        }
        public double agc(int a, int i, int d, int k)
        {
            double ags = Math.Sin(2 * Math.PI * (d + i) / a) * (k);
            return ags;
        }
        public DateTime Get_date(string abc)
        {
            int day, month, year;
            Mass m_a = new Mass();
            Console.Write("Enter day " + abc);
            day = m_a.check1();
            Console.Write("Enter month " + abc);
            month = m_a.check1();
            Console.Write("Enter year " + abc);
            year = m_a.check1();
            DateTime d1 = new DateTime(year, month, day);
            return d1;
        }
        public double check_num(double num)
        {
            double num1 = Math.Round(num, 0);
            if (num1 < num)
                num1++;
            return num1;
        }
        public void randomShuffle()
        {
            int[] arr = new int[52];
            arr_f(arr);
            Shuffle(arr);
            show_mass(arr);
        }
        public int GetInt(string quastion)
        {
            int res;
            do
            {
                Console.Write(quastion);
            } while (!Int32.TryParse(Console.ReadLine(), out res));
            return res;
        }
        public uint GetUint(string quastion)
        {
            uint res;
            do
            {
                Console.Write(quastion);
            } while (!UInt32.TryParse(Console.ReadLine(), out res));
            return res;
        }
    }
    class Bioritm
    {
        public Bioritm()
        {
            Mass m_a = new Mass();
            DateTime d1 = m_a.Get_date("of birth");
            DateTime d2 = m_a.Get_date(""); ;
            TimeSpan times = (d2 - d1);
            bioritm_show(times);
            string[,] str = new string[22, 62];
            bioritm_shows(str, times);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 62; j++)
                    Console.Write(str[i, j]);
                Console.WriteLine();
            }
        }
        private void bioritm_show(TimeSpan times)
        {
            Mass m_a = new Mass();
            double s1 = m_a.agc(23, 0, times.Days, 1);
            double s2 = m_a.agc(28, 0, times.Days, 1); ;
            double s3 = m_a.agc(33, 0, times.Days, 1); ;
            Console.Clear();
            Console.WriteLine("Физическое состояние \t\t: {0:f2}", s1);
            Console.WriteLine("Эмоциональное состояние \t: {0:f2}", s2);
            Console.WriteLine("Интеллектуальное состояние \t: {0:f2}", s3);
        }
        private void bioritm_shows(string[,] str, TimeSpan times)
        {
            Mass m_a = new Mass();
            for (int i = 0; i < 30; i++)
            {
                double s1 = m_a.check_num(m_a.agc(23, i, times.Days, -9));
                double s2 = m_a.check_num(m_a.agc(28, i, times.Days, -9));
                double s3 = m_a.check_num(m_a.agc(33, i, times.Days, -9));
                for (int j = 0; j < 20; j++)
                {
                    str[j, i * 2 + 1] = " ";
                    str[j, i * 2] = " ";
                }
                str[((int)s1 + 9), i * 2] = ".";
                if ((int)s1 == (int)s2)
                    str[((int)s2 + 9), i * 2 + 1] = "*";
                else
                    str[(int)s2 + 9, i * 2] = "*";
                if (((int)s1 == (int)s3) | ((int)s2 == (int)s3))
                    str[(int)s3 + 9, i * 2 + 1] = ",";
                else
                    str[(int)s3 + 9, i * 2] = ",";
            }
        }
    }
    class INN
    {
        public INN()
        {
            Mass m_a = new Mass();
            uint inn = m_a.GetUint("Enter Ukraine INN Code =>");
            int[] arr = GetArray(inn);
            int[] code = new int[] { -1, 5, 7, 9, 4, 6, 10, 5, 7 };
            int sum = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                sum += arr[i] * code[i];
            }
            sum %= 11;
            if (inn % 10 == sum)
            {
                show_info(arr);
            }
            else
            {
                Console.WriteLine("Wrong INN");
            }
        }
        private static int[] GetArray(uint inn)
        {
            int[] res = new int[9];
            inn /= 10;
            for (int i = 0; i < 9; ++i)
            {
                res[i] = (int)(inn % 10);
                inn /= 10;
            }
            Array.Reverse(res);
            return res;
        }
        private void show_info(int[] arr)
        {
            Console.WriteLine("Cheked");
            int k = 0, jk = 10000;
            for (int i = 0; i < 5; i++)
            {
                k += arr[i] * jk;
                jk /= 10;
            }
            DateTime d1 = new DateTime(1899, 12, 31);
            d1 = d1.AddDays(k);
            Console.WriteLine(d1.ToString("dd.MM.yyyy"));
            if (arr[8] % 2 == 0)
                Console.WriteLine("Female");
            else
                Console.WriteLine("Male");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to use puzzle ");
            Console.WriteLine("Enter 2 to use bioritm ");
            Console.WriteLine("Enter 3 to use randomShuffle ");
            Console.WriteLine("Enter 4 to use INN ");
            Console.WriteLine("Enter 5 to know the day of date ");
            Mass m_a = new Mass();
            Puzzle map;
            Bioritm bio;
            INN inn;
            int key = m_a.check1();
            if (key == 1)
                map = new Puzzle();
            if (key == 2)
                bio = new Bioritm();
            if (key == 3)
                m_a.randomShuffle();
            if (key == 4)
                inn = new INN();
            if (key == 5)
                m_a.what_day();
            Console.ReadKey();
        }
    }
}