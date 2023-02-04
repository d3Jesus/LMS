import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import NavigationBar from './shared/NavbarComponent';
import BreadCrumb from './shared/BreadcrumbComponent';
import { Container } from 'react-bootstrap';

function App() {
  return (
    <Container>
      <NavigationBar />
      <BreadCrumb />
    </Container>
  );
}

export default App;
