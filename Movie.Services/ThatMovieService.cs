using Movie.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Movie.Models.Requests;
using System.Net;
using AngleSharp.Parser.Html;

namespace Movie.Services
{
    public class ThatMovieService
    {
        public static List<MovieDomain> GetAll()
        {
            List<MovieDomain> result = null;
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Movie_SelectAll";
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        MovieDomain movie = new MovieDomain();
                        movie.Id = (int)rdr["Id"];
                        movie.Title = (string)rdr["Title"];
                        movie.Actors = (string)rdr["Actors"];
                        movie.Director = (string)rdr["Director"];
                        movie.Description = (string)rdr["Description"];
                        movie.MovieImage = (string)rdr["MovieImage"];
                        movie.DateCreated = (DateTime)rdr["DateCreated"];
                        movie.DateModified = (DateTime)rdr["Datemodified"];
                        if (result == null)
                        {
                            result = new List<MovieDomain>();
                        }
                        result.Add(movie);
                    };
                    return result;
                }
                
            }
        }

        public static List<MovieDomain> GetById(int id)
        {
            List<MovieDomain> result = null;
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Movie_SelectById";
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        MovieDomain movie = new MovieDomain();
                        movie.Id = (int)rdr["Id"];
                        movie.Title = (string)rdr["Title"];
                        movie.Actors = (string)rdr["Actors"];
                        movie.Director = (string)rdr["Director"];
                        movie.Description = (string)rdr["Description"];
                        movie.MovieImage = (string)rdr["MovieImage"];
                        movie.DateCreated = (DateTime)rdr["DateCreated"];
                        movie.DateModified = (DateTime)rdr["Datemodified"];
                        if (result == null)
                        {
                            result = new List<MovieDomain>();
                        }
                        result.Add(movie);
                    };
                    return result;
                }

            }
        }

        static void Main(string[] args)
        {
            var results = new List<MovieScraper>();
            // 1. Download the HTML for the page
            var webClient = new WebClient();
            var html = webClient.DownloadString("https://www.imdb.com/chart/top?ref_=nv_mv_250");

            // 2. Use CSS selectors to find the table
            var parser = new HtmlParser();
            var document = parser.Parse(html);
            var table = document.QuerySelector(".lister-list");

            // 3. Loop over every row and create an object for each row
            var rows = table.QuerySelectorAll("tr");

            // 4. Print out the results
            foreach (var movieScraper in results)
            {
                Console.WriteLine($"Poster={movieScraper.Poster}, Title={movieScraper.Title}");
            }
        }

    }
}
