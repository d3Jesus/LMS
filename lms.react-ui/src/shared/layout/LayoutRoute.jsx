import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Home";
import Authors from "../../components/author/Authors";
import Edit from "../../components/author/Edit";
import Bookcases from "../../components/bookcase/Bookcases";
import EditBookcase from "../../components/bookcase/EditBookcase";
import EditLibrarian from "../../components/librarian/EditLibrarian";
import Librarians from "../../components/librarian/Librarians";

const Routing = () => {
    return (
        <Router>
            <Routes>
                <Route path='/' element={<Home />}></Route>
                <Route path='/authors'>
                    <Route index element={<Authors />} />
                    <Route path=":id" element={<Edit />} />
                </Route>
                <Route path='/bookcases'>
                    <Route index element={<Bookcases />} />
                    <Route path=":id" element={<EditBookcase />} />
                </Route>
                <Route path='/librarians'>
                    <Route index element={<Librarians />} />
                    <Route path=":id" element={<EditLibrarian />} />
                </Route>
            </Routes>
        </Router>
    )
}

export default Routing;