using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbstractExample.Models
{
    public class Show : Media
    {
 

        private List<Show> _shows;
    

        public int Season { get; set; }
        public int Episode { get; set; }
        public string[] Writers { get; set; }

        public Show()
        {
            _shows = new List<Show>();
        }

        public override void Display()
        {
            var sb = new StringBuilder();
            foreach (var show in _shows)
            {
                Console.WriteLine($"ID: {show.Id}, Title: {show.Title}, Season: {show.Season}, Episode: {show.Episode}");
                Console.Write("Writers: ");
                 
                foreach (var writer in show.Writers)
                {
                    Console.Write($"{writer} ");
                }

                Console.WriteLine();

            }
            
        }

        public override void Read()
        {
            string filePath = "Shows.csv"; 

              if (!File.Exists(filePath))
              {
                  Console.WriteLine($"File does not exit: {filePath}");
                  return;
              }

            try
            {
                _shows = new List<Show>();
                var sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var contents = line.Split(',');
                    var show = new Show();
                    show.Id = Convert.ToInt32(contents[0]);
                    show.Title = contents[1];
                    var writers = contents[2].Split('|');
                    show.Writers = writers;

                    _shows.Add(show);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _shows = null;

            }
        }
    }
}
