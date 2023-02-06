import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import NavigationBar from './shared/NavbarComponent';
import BreadCrumb from './shared/BreadcrumbComponent';
import Container from 'react-bootstrap/Container';
import CardComponent from './shared/CardComponent';

import Author from "./pages/author/Authors";
import { BrowserRouter, Routes, Route } from 'react-router-dom';

function App() {

  return (
    <>
      <Container>
        <NavigationBar />
        <BreadCrumb />
        <CardComponent />
      </Container>
      <BrowserRouter>
        <Routes>
          <Route>
            <Route path="author" element={<Author />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;