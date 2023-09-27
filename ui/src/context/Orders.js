import React, { createContext, useState, useEffect } from 'react';
import axios from 'axios';

export const OrderContext = createContext();

const OrderProvider = ({ children }) => {
  const [orders, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const getProducts = async () => {
      try {
        const response = await axios.get('https://localhost:7287/api/orders');
        const productsData = response.data.result;
        setProducts(productsData);
        setLoading(false);
      } catch (err) {
        console.error('Error fetching products:', err);
      }
    };

    getProducts();
  }, []);

  return (
    <OrderContext.Provider value={{ orders, loading }}>
      {children}
    </OrderContext.Provider>
  );
};

export default OrderProvider;