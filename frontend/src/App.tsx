
import './App.css';

import Navbar from './Components/Navbar/Navbar';

import { Outlet } from 'react-router';

function App() {


  return (
    <div>
      <Navbar />
      <Outlet />
    </div>
  );
}

export default App;
