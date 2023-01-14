import './App.css';
import Navbar from './features/navigation/Navbar';
import GridPage from './pages/GridPage';
import ChartPage from './pages/ChartPage';
import Home from './pages/Home';
import GridChartRangePage from './pages/GridChartRangePage';


const App = () => {
  return (
    <div className="App">
      <Navbar />
      <Home />
      <br /><br /><br />
      <GridPage />
      <br /><br /><br />
      <GridChartRangePage />
      <br /><br /><br />
      <ChartPage />
    </div>
  );
}

export default App;
