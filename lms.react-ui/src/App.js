import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import NavigationBar from './shared/NavbarComponent';
import BreadCrumb from './shared/BreadcrumbComponent';
import { Container } from 'react-bootstrap';
import CardComponent from './shared/CardComponent';

function App() {
  return (
    <Container>
      <NavigationBar />
      <BreadCrumb />
      <CardComponent/>
    </Container>
  );
}

export default App;
