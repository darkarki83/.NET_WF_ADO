﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseStr
{
    class Program
    {
        private static async Task<string> GetHomePageAsync(string str)
        {
            // Асинхронно читаем файл и построчно выводим на экран
            using (var httpClient = new HttpClient())
            using (var httpResponse = await httpClient.GetAsync(str))
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        private static async Task<List<string>> ParseAsync(string str)
        {
            List<string> linc = new List<string>();
            string open = string.Empty;

            Regex regex = new Regex(@"(\w*)(\s*).html");
            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Value[match.Value.Length - 5] == '.')
                    {
                        linc.Add("https://www.barabash.com/" + (match.Value));
                    }
                }
            }
            linc.Sort();
            return RemoneAtDouble(linc);
        }
        private static List<string> RemoneAtDouble(List<string> linc)
        {
            for (int i = linc.Count - 1; i > 0; i--)
            {
                if (linc[i] == linc[i - 1])
                {
                    linc.RemoveAt(i);
                }
            }
            return linc;
        }
        static async Task<int> Main(string[] args)
        {
            List<string> linc = new List<string>();
            List<string> Alllinc = new List<string>();
            List<string> templinc = new List<string>();

            string start = "https://www.barabash.com/index.html";
            string str = string.Empty;

            try
            {
                str = await GetHomePageAsync(start);
                linc = await ParseAsync(str);
                for (int i = 0; i < linc.Count; i++)
                {
                    str = await GetHomePageAsync(linc[i]);
                    templinc = await ParseAsync(str);
                    for (int j = 0; j < templinc.Count; j++)
                    {
                        Alllinc.Add(templinc[j]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Alllinc.Sort();
            RemoneAtDouble(Alllinc);

            foreach (var item in Alllinc)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey(true);

            return 0;
        }
    }
}
