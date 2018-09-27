import React from "react";
import { getAllMovies } from "./MovieServices";

class Movies extends React.Component {
  state = {
    movies: []
  };

  nameChange = event => {
    this.setState({ name: event.target.value });
  };

  componentDidMount() {
    const allMoviesPromise = getAllMovies();

    allMoviesPromise
      .then(response => {
        this.setState({
          movies: response.data
        });
      })
      .catch(err => {
        console.log(err);
      });
  }
  render() {
    return (
      <div>
        <div>
          <header className="App-header">
            <h1 className="App-title">That Movie!!</h1>
          </header>
        </div>

        {this.state.movies.map(movie => (
          <div>
            <img style={{ width: 200, height: 200 }} src={movie.movieImage} />
            <h3>{movie.title}</h3>
          </div>
        ))}
      </div>
    );
  }
}

export default Movies;
