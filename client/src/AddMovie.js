import React from "react";
import { createMovie } from "./MovieServices";
import { FormGroup, Label, Input, Button, Row } from "reactstrap";

class AddMovie extends React.Component {
  state = {
    title: "",
    director: "",
    actors: "",
    description: "",
    genre: "",
    year: "",
    rated: "",
    movieImage: ""
  };

  //----------Handlers-----------
  handleTitleAdd = event => {
    this.setState({ title: event.target.value });
  };

  handleDirectorAdd = event => {
    this.setState({ director: event.target.value });
  };

  handleActorsAdd = event => {
    this.setState({ actors: event.target.value });
  };

  handleDescriptionAdd = event => {
    this.setState({ description: event.target.value });
  };

  handleGenreAdd = event => {
    this.setState({ genre: event.target.value });
  };

  handleYearAdd = event => {
    this.setState({ year: event.target.value });
  };

  handleRatedAdd = event => {
    this.setState({ rated: event.target.value });
  };

  handleImageAdd = event => {
    this.setState({ movieImage: event.target.value });
  };

  //---------------Submit Handler/Axios call------------

  handleSubmitAdd = () => {
    const newMoviePromise = createMovie(
      this.state.title,
      this.state.director,
      this.state.actors,
      this.state.description,
      this.state.genre,
      this.state.year,
      this.state.rated,
      this.state.movieImage
    );
    newMoviePromise.then(response => {
      this.setState({ addMovie: response.data.message });
    });
    return this.props.history.push("/movielist");
  };

  handleCancelClicked = () => {
    return this.props.history.push("/movielist");
  };

  render() {
    return (
      <div id="addBackground">
        <div className="container">
          <div className="text-center text-white">
            <h1>Add New Movie</h1>
          </div>
          <div id="addForm" className="col-md-4">
            <FormGroup>
              <Label>Title</Label>
              <Input
                type="text"
                value={this.state.title}
                onChange={this.handleTitleAdd}
              />
            </FormGroup>
            <FormGroup>
              <Label>Director</Label>
              <Input
                type="text"
                value={this.state.director}
                onChange={this.handleDirectorAdd}
              />
            </FormGroup>
            <FormGroup>
              <Label>Actors</Label>
              <Input
                type="text"
                value={this.state.actors}
                onChange={this.handleActorsAdd}
              />
            </FormGroup>
            <FormGroup>
              <Label>Description</Label>
              <Input
                type="textarea"
                value={this.state.description}
                onChange={this.handleDescriptionAdd}
              />
            </FormGroup>
            <FormGroup>
              <Label>Genre</Label>
              <Input
                type="text"
                value={this.state.genre}
                onChange={this.handleGenreAdd}
              />
            </FormGroup>
            <FormGroup className="row mx-auto">
              <div className="col-md-4">
                <Label>Year</Label>
                <Input
                  type="text"
                  value={this.state.year}
                  onChange={this.handleYearAdd}
                />
              </div>
              <div className="ml-auto col-md-4">
                <Label>Rated</Label>
                <Input
                  type="text"
                  value={this.state.rated}
                  onChange={this.handleRatedAdd}
                />
              </div>
            </FormGroup>
            <FormGroup>
              <Label>Image URL</Label>
              <Input
                type="text"
                value={this.state.movieImage}
                onChange={this.handleImageAdd}
              />
            </FormGroup>
            <div id="btns" className="text-center">
              <Button
                className="my-auto ml-2"
                color="primary"
                onClick={this.handleSubmitAdd}
              >
                Submit
              </Button>
              <Button
                className="my-auto ml-2"
                color=""
                onClick={this.handleCancelClicked}
              >
                Cancel
              </Button>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
export default AddMovie;
