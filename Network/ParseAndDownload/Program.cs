using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParseAndDownload
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
            // Асинхронно читаем файл и построчно выводим на экран

            List<string> linc = new List<string>();
            string open = string.Empty;

            try
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '<')
                    {
                        if (str[i + 1] == 'a')
                        {
                            if (str[i + 2] == ' ')
                            {

                                for (int j = i; str[j] != '"'; j++)
                                {
                                    i++;
                                }
                                i++;
                                for (int j = i; str[j] != '"'; j++)
                                {
                                    open += str[j];
                                    i++;
                                }
                            }
                            if (open[0] == 'h' && open[1] == 't')
                                open = string.Empty;
                            else
                            {
                                linc.Add("https://www.barabash.com/" + open);
                                open = string.Empty;
                            }
                        }
                    }
                }
                return linc;
            }
            catch (Exception ex)
            {
                return linc;
            }
        }
        static async Task<int> Main(string[] args)
        {
            List<string> linc = new List<string>();
            List<string> Alllinc = new List<string>();
            List<string> templinc = new List<string>();

            string start = "https://www.barabash.com/index.html";
            string str = string.Empty;

            var client = new WebClient();

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

                Alllinc.Sort();

                for (int i = Alllinc.Count - 1; i > 1; i--)
                {
                    if (Alllinc[i] == Alllinc[i - 1])
                    {
                        Alllinc.RemoveAt(i);
                    }
                }

                string strDownload = string.Empty;
                string name = string.Empty;

                for (int i = 0; i < Alllinc.Count; i++)
                {
                    strDownload = Alllinc[i];
                    if (strDownload[strDownload.Length - 4] == 'h' && strDownload[strDownload.Length - 3] == 't' && strDownload[strDownload.Length - 2] == 'm' && strDownload[strDownload.Length - 1] == 'l')
                    {
                        for (int k = strDownload.Length - 1; k > 0; k--)
                        {
                            if (strDownload[k] == '/')
                            {
                                for (int q = k + 1; q < strDownload.Length; q++)
                                {
                                    name += strDownload[q];
                                }
                                break;
                            }
                        }
                        try
                        {
                            client.DownloadFile(strDownload, name);
                        }
                        catch(Exception ex)
                        {
                            strDownload = string.Empty;
                            name = string.Empty;
                        }
                        strDownload = string.Empty;
                        name = string.Empty;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.WriteLine("Complite");
            return 0;
        }
    }
}
