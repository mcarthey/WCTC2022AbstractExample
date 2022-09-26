using System;

namespace AbstractExample.Models
{
    using System.Collections.Generic;
    using System.Diagnostics.Eventing.Reader;
    using System.IO;
    using System.Text;

    using Microsoft.Extensions.Logging;
    using NLog;

    public class Movie : Media
    {
  

        private List<Movie> _movies;


        public string[] Genres { get; set; }

        // default constructor
        public Movie()
        {
            _movies = new List<Movie>();
            //Read();
        }

        public override void Read()
        {
            // Read in the contents of the MoviesAbstract.csv and assign to the Movie properties
            // loop over the file (eg. StreamReader) and read into the following properties
            string filePath = $"{AppContext.BaseDirectory}/Data/moviesAbstract.csv";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist: {File}", filePath);
                return;
            }

            try
            {
                _movies = new List<Movie>();
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var movie = new Movie();
                    movie.Id = 0; // would actually be the file contents value
                    movie.Title = "";
                    movie.Genres = new string[1];

                    _movies.Add(movie);
                    // end loop

                }


                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _movies = null;

            }
        }


        public override void Display()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var movie in _movies)
            {
                Console.WriteLine($"Id: {movie.Id}, Title: {movie.Title}, Genre: {movie.Genres}");
            }
        }
    }
}
