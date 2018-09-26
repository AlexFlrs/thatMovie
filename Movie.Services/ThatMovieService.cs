using Movie.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

    }
}
