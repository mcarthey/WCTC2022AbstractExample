using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using NLog;

namespace AbstractExample.Models
{
    using System.IO;
    using System.Text;

    public class Show : Media
    {
 

        private List<Show> _shows;
    

        public int Season { get; set; }
        public int Episode { get; set; }
        public string[] Writers { get; set; }

        public Show()
        {
            _shows = new List<Show>();
            //Read();
        }

        public override void Read()
        {
            string filePath = $"{AppContext.BaseDirectory}Data/Shows.csv"; 

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exit: {File}", filePath);
                return;
            }

            try
            {
                _shows = new List<Show>();
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {


                    string line = sr.ReadLine();
                    var show = new Show();

                    _shows.Add(show);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }


        public override void Display()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var shows in _shows)
            {
                Console.WriteLine($"ID: {shows.Id}, Title: {shows.Title}, Season: {shows.Season}, Episode: {shows.Episode}, Genre: {shows.Writers}");
               
            }
             
        }


    }
}
