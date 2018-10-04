import React from "react";
import { getMovieById, updateMovie } from "./MovieServices";
import { FormGroup, Label, Input, Button } from "reactstrap";

class EditMovie extends React.Component {
  state = {
    id: 0,
    title: "",
    director: "",
    actors: "",
    description: "",
    genre: "",
    year: "",
    rated: "",
    movieImage: ""
  };

  //------------Handlers------------------
  handleTitleEdit = event => {
    this.setState({ title: event.target.value });
  };

  handleDirectorEdit = event => {
    this.setState({ director: event.target.value });
  };

  handleActorsEdit = event => {
    this.setState({ actors: event.target.value });
  };

  handleDescriptionEdit = event => {
    this.setState({ description: event.target.value });
  };

  handleGenreEdit = event => {
    this.setState({ genre: event.target.value });
  };

  handleYearEdit = event => {
    this.setState({ year: event.target.value });
  };

  handleRatedEdit = event => {
    this.setState({ rated: event.target.value });
  };

  handleImageEdit = event => {
    this.setState({ movieImage: event.target.value });
  };

  //------------------Submit Handler/Update Data Axios call----------
  handleEditSubmit = () => {
    const editMoviePromise = updateMovie(
      this.state.id,
      this.state.title,
      this.state.director,
      this.state.actors,
      this.state.description,
      this.state.genre,
      this.state.year,
      this.state.rated,
      this.state.movieImage
    );
    editMoviePromise.then(response => {
      this.setState({ editMovie: response.data.message });
    });
    return this.props.history.push("/movielist");
  };

  handleCancelClicked = () => {
    return this.props.history.push("/movielist");
  };

  //---------------Axios call/Get data by Id----------------
  componentDidMount() {
    const href = window.location.href;
    const stringArray = href.split("/");
    const id = parseInt(stringArray[stringArray.length - 1]);
    const currentMovie = getMovieById(id);

    currentMovie
      .then(response => {
        this.setState({
          id: response.data[0].id,
          title: response.data[0].title,
          director: response.data[0].director,
          actors: response.data[0].actors,
          description: response.data[0].description,
          genre: response.data[0].genre,
          year: response.data[0].year,
          rated: response.data[0].rated,
          movieImage: response.data[0].movieImage
        });
      })
      .catch(err => {
        console.log(err);
      });
  }
  render() {
    return (
      <div id="addBackground">
        <div className="container">
          <div className="text-center text-white">
            <h1>Edit Movie</h1>
          </div>
          <div id="addForm" className="col-md-4">
            <FormGroup>
              <Label>Title</Label>
              <Input
                type="text"
                value={this.state.title}
                onChange={this.handleTitleEdit}
              />
            </FormGroup>
            <FormGroup>
              <Label>Director</Label>
              <Input
                type="text"
                value={this.state.director}
                onChange={this.handleDirectorEdit}
              />
            </FormGroup>
            <FormGroup>
              <Label>Actors</Label>
              <Input
                type="text"
                value={this.state.actors}
                onChange={this.handleActorsEdit}
              />
            </FormGroup>
            <FormGroup>
              <Label>Description</Label>
              <Input
                type="textarea"
                value={this.state.description}
                onChange={this.handleDescriptionEdit}
              />
            </FormGroup>
            <FormGroup>
              <Label>Genre</Label>
              <Input
                type="text"
                value={this.state.genre}
                onChange={this.handleGenreEdit}
              />
            </FormGroup>
            <FormGroup className="row mx-auto">
              <div className="col-md-4">
                <Label>Year</Label>
                <Input
                  type="text"
                  value={this.state.year}
                  onChange={this.handleYearEdit}
                />
              </div>
              <div className="ml-auto col-md-4">
                <Label>Rated</Label>
                <Input
                  type="text"
                  value={this.state.rated}
                  onChange={this.handleRatedEdit}
                />
              </div>
            </FormGroup>
            <FormGroup>
              <Label>Image URL</Label>
              <Input
                type="text"
                value={this.state.movieImage}
                onChange={this.handleImageEdit}
              />
            </FormGroup>
            <div id="btns" className="text-center">
              <Button
                className="my-auto ml-2"
                color="primary"
                onClick={this.handleEditSubmit}
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
export default EditMovie;
