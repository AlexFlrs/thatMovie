import axios from "axios";
//axios.defaults.withCredentials = true;

export function getAllMovies() {
  return axios.get("/api/movies");
}

export function getMovieById(id) {
  return axios.get("/api/movies/" + id);
}

export function createMovie(
  title,
  director,
  actors,
  description,
  genre,
  year,
  rated,
  movieImage
) {
  return axios.post("/api/movies/", {
    title,
    director,
    actors,
    description,
    genre,
    year,
    rated,
    movieImage
  });
}

export function updateMovie(
  id,
  title,
  director,
  actors,
  description,
  genre,
  year,
  rated,
  movieImage
) {
  return axios.put("/api/movies/" + id, {
    id,
    title,
    director,
    actors,
    description,
    genre,
    year,
    rated,
    movieImage
  });
}

export function deleteMovie(id) {
  return axios.delete("/api/movies/" + id);
}
