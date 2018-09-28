import React from "react";
import { getAllMovies } from "./MovieServices";
import { Button, Navbar } from "reactstrap";

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
      <div id="background">
        <div id="heading" className="col-12 text-center">
          <h1 id="title">That Movie!!</h1>
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
                  <div>
                    <Button color="primary" id="edit" />
                    <Button
                      src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHJAhygoEzKwmOJW8BLYRl8Qo896gdt1-cxvcEP-lJnr6uY6Xv"
                      id="delete"
                    />
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
