import React from "react";
import { getAllMovies, deleteMovie } from "./MovieServices";
import { Button } from "reactstrap";
import Glory from "./assets/Glory.mp3";

class Movies extends React.Component {
  state = {
    id: 0,
    movies: []
  };

  //---------------Handlers---------------

  handleDeleteMovie = id => {
    const deleteMoviePromise = deleteMovie(id);
    deleteMoviePromise.then(response => {
      this.setState({ deleteCurrentMovie: response.data.message });
    });
    return this.props.history.push("/movielist");
  };

  handleEditMovie = id => {
    return this.props.history.push("/editmovie/" + id);
  };

  handleAddClicked = () => {
    return this.props.history.push("/addmovie");
  };

  //------------Get all Data Axios Call----------------
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
  6;
  render() {
    return (
      <div id="background">
        <audio src={Glory} autoPlay />
        <div id="heading" className="col-12 text-center">
          <h1 id="title">
            That Movie
            <Button id="addBtn" onClick={this.handleAddClicked} />
          </h1>
        </div>
        <div className="container col-md-12 row">
          {this.state.movies.map(movie => (
            <div
              className="flip-container"
              ontouchstart="this.classList.toggle('hover');"
            >
              <div className="flipper">
                <div className="front">
                  <img
                    style={{ width: 400, height: 500 }}
                    src={movie.movieImage}
                  />
                </div>
                <div className="back">
                  <div className="float-left">
                    <Button
                      id="edtBtn"
                      onClick={() => this.handleEditMovie(movie.id)}
                    />
                  </div>
                  <div className="float-right">
                    <Button
                      id="dltBtn"
                      onClick={() => this.handleDeleteMovie(movie.id)}
                    />
                  </div>
                  <div id="sec1">
                    <h2 id="movTitle" className="text-center">
                      {movie.title}
                    </h2>
                  </div>
                  <div id="sec2">
                    <p className="text-center">{movie.genre}</p>
                    <p className="text-center">{movie.year}</p>
                    <p className="text-center">{movie.rated}</p>
                  </div>
                  <div id="sec3">
                    <p>Directed by: {movie.director}</p>
                    <p>Actors: {movie.actors} </p>
                  </div>
                  <div id="sec4">
                    <p>{movie.description}</p>
                  </div>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    );
  }
}

export default Movies;
