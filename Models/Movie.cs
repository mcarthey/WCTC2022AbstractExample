using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbstractExample.Models
{
    public class Movie : Media
    {
        private List<Movie> _movies;

        public string[] Genres { get; set; }

        // default constructor
        public Movie()
        {
            _movies = new List<Movie>();
           
        }

        public override void Display()
        {
            var sb = new StringBuilder();
            foreach (var movie in _movies)
            {
                Console.WriteLine($"Id: {movie.Id}, Title: {movie.Title}");
                Console.Write("Genres: ");

                foreach (var genre in movie.Genres)
                {
                    Console.Write($"{genre} ");
                }
                Console.WriteLine();
            }

        }

        public override void Read()
        {
            // Read in the contents of the MoviesAbstract.csv and assign to the Movie properties
            // loop over the file (eg. StreamReader) and read into the following properties
            string filePath = "movies.csv";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File does not exist: {filePath}");
                return;
            }

            try
            {
                _movies = new List<Movie>();
                var sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var contents = line.Split(',');
                    var movie = new Movie();
                    movie.Id = Convert.ToInt32(contents[0]); // would actually be the file contents value
                    movie.Title = contents[1];
                    var genres = contents[2].Split('|');
                    movie.Genres = genres;

                    _movies.Add(movie);
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _movies = null;

            }
        }

    }
}
