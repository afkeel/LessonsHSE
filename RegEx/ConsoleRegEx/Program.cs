using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleRegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex re = new Regex(@"[А-Я].*?(?<punkt>[!.?])");
            string str = "Мама мыла раму. Тестовое предложение! фыва Что?";
            foreach (Match m in re.Matches(str))
                Console.WriteLine($"{m.Value}({m.Index},{m.Length}) группа: {m.Groups["punkt"]}");

            string re1 = @"(?<=\s|^)\d*[02468](?=\s|$)";
            string str1 = "11 124 455 2 478 22.2";
            Console.WriteLine(
                Regex.Replace(str1, re1, m => (int.Parse(m.Value) + 1).ToString()));

            string text = "Мама мыла раму: \"Тестовое предложение!\" фыва Что?";
            string reText = @":\s*""(?<speach>.*?)""";
            var m1 = Regex.Match(text, reText);
            if (m1.Success)
            {
                Console.WriteLine(m1.Groups["speach"]);
            }
        }
    }
}
