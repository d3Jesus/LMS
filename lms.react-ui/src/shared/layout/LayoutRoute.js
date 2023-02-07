import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "../Home";
import Authors from "../../pages/author/Authors";

const Routing = () => {
    return (
        <Router>
            <Routes>
                <Route path='/' element={<Home />}></Route>
                <Route path='/authors' element={<Authors />}></Route>
            </Routes>
        </Router>
    )
}

export default Routing;