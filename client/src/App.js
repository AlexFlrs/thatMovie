import React from "react";
import { getAllMovies, deleteMovie } from "./MovieServices";
import {
  Button,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem
} from "reactstrap";

class Movies extends React.Component {
  state = {
    id: 0,
    movies: []
  };

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
      <div id="background">
        <div id="heading" className="col-12 text-center">
          <h1 id="title">That Movie!!</h1>
          <Button
            className="my-auto ml-2"
            color="success"
            onClick={this.handleAddClicked}
          >
            +
          </Button>
        </div>
        <div className="container col-md-12 row">
          {this.state.movies.map(movie => (
            <div
              className="flip-container"
              ontouchstart="this.classList.toggle('hover');"
            >
              <div className="flipper">
                <div className="Front">
                  <img
                    style={{ width: 400, height: 500 }}
                    src={movie.movieImage}
                  />
                </div>
                <div className="back">
                  <div className="float-right">
                    <UncontrolledDropdown className="">
                      <DropdownToggle caret />
                      <DropdownMenu>
                        <DropdownItem
                          onClick={() => this.handleEditMovie(movie.id)}
                        >
                          Edit
                        </DropdownItem>
                        <hr />
                        <DropdownItem
                          onClick={() => this.handleDeleteMovie(movie.id)}
                        >
                          Delete
                        </DropdownItem>
                      </DropdownMenu>
                    </UncontrolledDropdown>
                  </div>
                  <h2 className="text-center">{movie.title}</h2>
                  <p className="text-center">{movie.genre}</p>
                  <p className="text-center">{movie.year}</p>
                  <p className="text-center">{movie.rated}</p>
                  <h5>Directed by: {movie.director}</h5>
                  <h5>Actors: {movie.actors} </h5>
                  <p>{movie.description}</p>
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
