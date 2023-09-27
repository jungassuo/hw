import React, { createContext, useState, useEffect } from 'react';
import axios from 'axios';

export const ToppingsContext = createContext();

const ToppingProvider = ({ children }) => {
  const [toppings, setToppings] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const getToppings = async () => {
      try {
        const response = await axios.get('https://localhost:7287/api/toppings');
        const productsData = response.data.result;
        setToppings(productsData);
        setLoading(false); // Set loading to false when data is available
      } catch (err) {
        console.error('Error fetching products:', err);
      }
    };

    getToppings();
  }, []);

  return (
    <ToppingsContext.Provider value={{ toppings, loading }}>
      {children}
    </ToppingsContext.Provider>
  );
};

export default ToppingProvider