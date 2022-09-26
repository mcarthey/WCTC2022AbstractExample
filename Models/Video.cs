using System;

namespace AbstractExample.Models
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Video : Media
    {
        private List<Video> _videos;

        //TODO need to add properties

        public string Format { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }

        public Video()
        {
            _videos= new List<Video>();
        }

       public override void Read()
        {
            string filePath = $"{AppContext.BaseDirectory}/Data/Videos.csv";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exit: {File}", filePath);
                return;
            }

            try
            {
                _videos = new List<Video>();
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var video = new Video();

                    _videos.Add(video);
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
            foreach (var videos in _videos)
            {
                Console.WriteLine($"ID: {videos.Id}, Title: {videos.Title}, Format: {videos.Format}, Length: {videos.Length}, Regions: {videos.Regions}");

            }

        }

    }

}


