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
                        movie.Genre = (string)rdr["Genre"];
                        movie.MovieImage = (string)rdr["MovieImage"];
                        movie.Year = (int)rdr["Year"];
                        movie.Rated = (string)rdr["Rated"];
                        movie.DateCreated = (DateTime)rdr["DateCreated"];
                        movie.DateModified = (DateTime)rdr["DateModified"];
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
                        movie.Genre = (string)rdr["Genre"];
                        movie.Year = (int)rdr["Year"];
                        movie.Rated = (string)rdr["Rated"];
                        movie.MovieImage = (string)rdr["MovieImage"];
                        movie.DateCreated = (DateTime)rdr["DateCreated"];
                        movie.DateModified = (DateTime)rdr["DateModified"];
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

        public static int Create(MovieCreateRequest req)
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Movie_Insert";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", req.Title);
                cmd.Parameters.AddWithValue("@Director", req.Director);
                cmd.Parameters.AddWithValue("@Actors", req.Actors);
                cmd.Parameters.AddWithValue("@Description", req.Description);
                cmd.Parameters.AddWithValue("@Genre", req.Genre);
                cmd.Parameters.AddWithValue("@Year", req.Year);
                cmd.Parameters.AddWithValue("@Rated", req.Rated);
                cmd.Parameters.AddWithValue("@MovieImage", req.MovieImage);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                int newMovieId = (int)cmd.Parameters["@Id"].Value;
                return newMovieId;
            }
 
        }

        public static void Update(MovieUpdateRequest req)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Movie_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", req.Id);
                cmd.Parameters.AddWithValue("@Title", req.Title);
                cmd.Parameters.AddWithValue("@Director", req.Director);
                cmd.Parameters.AddWithValue("@Actors", req.Actors);
                cmd.Parameters.AddWithValue("@Description", req.Description);
                cmd.Parameters.AddWithValue("@Genre", req.Genre);
                cmd.Parameters.AddWithValue("@Year", req.Year);
                cmd.Parameters.AddWithValue("@Rated", req.Rated);
                cmd.Parameters.AddWithValue("@MovieImage", req.MovieImage);

                cmd.ExecuteNonQuery();

            }

        }

        public static void Delete(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Movie_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
