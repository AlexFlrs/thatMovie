import React, { Component } from "react";
import App from "./App";
import AddMovie from "./AddMovie";
import EditMovie from "./MovieEdit";
import { Route } from "react-router-dom";

class Routes extends Component {
  render() {
    return (
      <div>
        <Route path="/movielist" render={props => <App {...props} />} />
        <Route path="/addmovie" render={props => <AddMovie {...props} />} />
        <Route path="/editmovie" render={props => <EditMovie {...props} />} />
      </div>
    );
  }
}
export default Routes;
