﻿using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var response =  await httpClient.GetAsync("https://www.pja.edu.pl");
            if (response.IsSuccessStatusCode)
            {
                var html = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-zA-Z0-9]+@[a-zA-Z0-9.]+");

                MatchCollection matches = regex.Matches(html);
                foreach(var i in matches)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("Koniec!");
        }
    }
}
