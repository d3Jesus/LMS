import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Home";
import Authors from "../../pages/author/Authors";
import Edit from "../../pages/author/Edit";

const Routing = () => {
    return (
        <Router>
            <Routes>
                <Route path='/' element={<Home />}></Route>
                <Route path='/authors'>
                    <Route index element={<Authors />} />
                    <Route path=":id" element={<Edit />} />
                </Route>
            </Routes>
        </Router>
    )
}

export default Routing;