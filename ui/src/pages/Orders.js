import React from 'react'

import {Link} from 'react-router-dom'

import { OrderContext } from '../context/Orders';

export default function Orders({children}){

    const [loading, setLoading] = React.useState(true);

    const { orders} = React.useContext(OrderContext);

    React.useEffect(() => {

        if (orders && orders.length > 0) {
            setLoading(false); 
          }

    },[orders])
    
    return(
        <div className=''>
                          {loading ? (
                            // Show a loading indicator while data is being fetched
                            <div>Loading...</div>
                          ) : (
                            // Data is available, render the products
                            (
                              <div className="bg-white p-4 rounded-lg shadow-md overflow-x-auto flex flex-col justify-start items-center h-screen">
                                   <div className=' mt-16 w-96'>
                                      <table className="w-full">
                                        <thead>
                                          <tr>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Order ID</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Total price</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Pizza Size</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Toppings Amount</th>
                                          </tr>
                                        </thead>
                                        <tbody>
                                          {orders.map((order) => (
                                            <tr key={order.id}>
                                              <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{order.id}</td>
                                              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{parseFloat(order.totalPrice).toFixed(2)} $</td>
                                              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{order.size}</td>
                                              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{order.toppingsCount}</td>
                                            </tr>
                                          ))}
                                        </tbody>
                                      </table>
                                      <div className='mt-10'>
                                            <Link to={`/`} className='bg-[#12486B] mt-4 text-white font-semibold py-4 px-8 rounded'>
                                                Go Back
                                            </Link>
                                      </div>
                                      
                                      </div>  
                                    </div>
                  
                  
                  ))}
            </div> 
    )
}