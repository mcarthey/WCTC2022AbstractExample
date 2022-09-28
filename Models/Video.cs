using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbstractExample.Models
{
    public class Video : Media
    {
        private List<Video> _videos;

        //TODO need to add properties

        public string Format { get; set; }
        public int Length { get; set; }
        public int Id { get; set; }
        public int[] Regions { get; set; }
        
        public Video()
        {
            _videos = new List<Video>();
        }

        public override void Display()
        {
            var sb = new StringBuilder();
            foreach (var video in _videos)
            {
                Console.WriteLine($"ID: {video.Id}, Title: {video.Title}, Format: {video.Format}, Length: {video.Length}");
                Console.Write("Regions: ");
                foreach (var region in Regions)
                {
                    Console.Write($"{Regions} ");
                }

                Console.WriteLine();
            }

        }

        public override void Read()
        {
            string filePath = "Videos.csv";

             if (!File.Exists(filePath))
             {
                 Console.WriteLine($"File does not exit: {filePath}");
                 return;
             }

            try
            {
                _videos = new List<Video>();
                var sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var contents = line.Split(',');
                    var video = new Video();
                    video.Id = Convert.ToInt32(contents[0]);
                    video.Title = contents[1];
                    int[] Regions = contents[2].Split('|'); //What are regions?? ***!!!!!***
                    video.Regions = regions;

                    _videos.Add(video);
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
