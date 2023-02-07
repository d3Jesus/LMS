import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import LayoutComponent from './shared/layout/LayoutNav';
import { Container } from 'react-bootstrap';

function App() {

  return (
    <Container>
      <LayoutComponent />
    </Container>
  );
}

export default App;