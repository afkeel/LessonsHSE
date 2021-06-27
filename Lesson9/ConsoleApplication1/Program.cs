using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t = new Task(() => Console.WriteLine("Hello"));
            //t.Start();
            //Task.Run(() => Console.WriteLine("Hello"));
            //Parallel.Invoke(
            //    new Action[] {()=>Console.WriteLine("!!!!!!"),
            //    ()=>Console.WriteLine("&&&&&&")}
            //    );
            ////Parallel.For(1, 10, (i) => Console.WriteLine(i));
            //Parallel.ForEach(new int[] { 1,2,3,4,5,6,7,8,9}, (i) => Console.WriteLine(i));
            //Test();
            //DoWorkS();
            DoWork();
        }
        static async void Test()
        {
            var res = await DoWork();
            Console.WriteLine(res);
        }
        static string DoWorkS()
        {
            Thread.Sleep(5000);
            return "Done";
        }
        static Task<string> DoWork()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                return "Done";
            });
            
        }
    }
}
