import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import Routes from "./MovieRoutes";

import "bootstrap/dist/css/bootstrap.css";
import { BrowserRouter } from "react-router-dom";

ReactDOM.render(
  <BrowserRouter>
    <Routes />
  </BrowserRouter>,
  document.getElementById("root")
);
