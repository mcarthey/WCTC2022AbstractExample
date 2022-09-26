using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbstractExample.Models
{
    public class Show : Media
    {
        private List<Show> _shows;
        public int Episode { get; set; }

        public int Season { get; set; }
        public string[] Writers { get; set; }

        public Show()
        {
            _shows = new List<Show>();
            //Read();
        }

        public override void Display()
        {
            var sb = new StringBuilder();
            foreach (var shows in _shows)
            {
                Console.WriteLine($"ID: {shows.Id}, Title: {shows.Title}, Season: {shows.Season}, Episode: {shows.Episode}, Genre: {shows.Writers}");
            }
        }

        public override void Read()
        {
            var filePath = "Shows.csv";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exit: {File}", filePath);
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
    }
}
