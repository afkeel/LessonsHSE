using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class IntegerHelper
    {
        public static int Double(this int x)
        {
            return x * 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 5;
            //Console.WriteLine(a.Double());

            ////int c = 5, d = 10;
            //double c = 5.2, d = 10.1;
            //Console.WriteLine($"{c},{d}");
            //Swap(ref c, ref d);
            //Console.WriteLine($"{c},{d}");

            #region фильтрация
            int[] m = { 1, 2, 5, 8, 9, 10 };
            //var filtered = m.Where((int x) =>
            //{
            //    return x % 2 == 0;
            //});
            var filteredM = m.Where((x, i) => i % 2 == 0);
            filteredM.ToList().ForEach(i => Console.WriteLine(i));
            #endregion
            Console.WriteLine("");
            #region упорядовачивание
            int[] n = { 1, 2, 5, 8, 9, 10 };
            var filteredN = n.OrderBy(x => x % 3);
            filteredN.ToList().ForEach(i => Console.WriteLine(i));
            #endregion
            Console.WriteLine("");
            #region сцеплние
            int[] a1 = { 1, 2, 5, 8, 9, 10 };
            int[] a2 = { 1, 4, 5, 9 };
            var filteredA = a1.Union(a2);
            filteredA.ToList().ForEach(i => Console.WriteLine(i));
            #endregion
            Console.WriteLine("");
            #region проецирование
            int[] m1 = { 1, 2, 5, 8, 9, 10 };
            var filteredMM = m1.Select(x =>
            new
            {
                Item = x,
                DoubleItem = x * 2
            });
            filteredMM.ToList().ForEach(i => Console.WriteLine(i));
            #endregion
            Console.WriteLine("");
            #region объединение
            int[] n1 = { 10, 3, 8, 4 };
            int[] n2 = { 0, 2 };
            var filteredNN = n1.Join(n2, x => x % 3, y => y,
                (x, y) => $"{x}-{y}");
            filteredNN.ToList().ForEach(i => Console.WriteLine(i));
            #endregion
            Console.WriteLine("");
            #region группировка
            int[] k1 = { 10, 3, 8, 4 };
            int[] k2 = { 0, 2 };
            var filteredKK = k1.GroupBy(x => x % 3);
            filteredKK.ToList().ForEach(
                i => Console.WriteLine(
                    $"{i.Key}{i.Count()}"));
            #endregion
            Console.WriteLine("");
            #region поэлементные операции
            int[] i1 = { 10, 3, 8, 4 };
            var filteredI = i1.First(x => x % 3 == 0);
            Console.WriteLine(filteredI);
            #endregion
            Console.WriteLine("");
            #region агрегирование
            int[] g = { 10, 3, 8, 4 };
            var filteredG = g.Max(x => x % 3);
            Console.WriteLine(filteredG);
            #endregion
            Console.WriteLine("");
            #region квантификаторы
            int[] gg = { 10, 3, 8, 4 };
            var filteredGG = gg.All(x => x % 3 == 1);
            Console.WriteLine(filteredGG);
            #endregion
            Console.WriteLine("");
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
    }
}
