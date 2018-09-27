import axios from "axios";
//axios.defaults.withCredentials = true;

export function getAllMovies() {
  return axios.get("/api/movies");
}
