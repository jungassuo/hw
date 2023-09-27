import React from "react"
import {BrowserRouter as Router, Route, Routes} from "react-router-dom"

//Add used pages to the routes
import Orders from './pages/Orders'
import ProductDetails from './components/ProductDetails'

function App() {
  return (
    <div className="overflow-hidden">
      <Router>
        <Routes>
          <Route path='/' element={<ProductDetails/>}/>
          <Route path="/orders" element={<Orders />}/>
        </Routes>
      </Router>  
    </div>
  );
}

export default App;
