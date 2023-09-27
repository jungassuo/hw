import React, {useContext} from 'react'

import {Link} from 'react-router-dom'

import { ProductContext } from '../context/Store'
import { ToppingsContext } from '../context/Topping'

import toast, { Toaster } from 'react-hot-toast';
import Select from 'react-select'

import axios from 'axios'

const ProductDetails = () => {

    const {products} = useContext(ProductContext)
    const {toppings} = useContext(ToppingsContext)

    const [currentSizePrice, setCurrentSizePrice] = React.useState()
    const [toppingsList, setToppingsList] = React.useState([])

    let sizes = []
    products.map((val) => {
        sizes.push({value: val.sizePrice, label: val.sizeName})
    })

    let arr = []
    toppings.map((val) => {
        arr.push({value: val.id, label: val.name})
    })

    const setToppings = (val) => {
        setToppingsList(val)
    }

    const postData = (arr) => {
       axios.post('https://localhost:7287/api/orders', arr).then(function (response){
       
       if(!response.data.isSuccess){
            toast.error(response.data.message)
       }else{
            toast.success('Your order has been completed!');
       }

       }).catch(function error(){
            toast(error, {
                icon: '⚠️',
              });
       })
    }

    function refreshPage() {
        window.location.reload(false);
      }


    const checkSubmit = () => {
        if(currentSizePrice != undefined){
            let toppingsArr = []
            toppingsList.map((val) =>{
                toppingsArr.push(val.label)
            })
            const returnData = {size: currentSizePrice.label, toppingsCount: toppingsList.length, toppingsArr: toppingsArr, price: currentSizePrice.value}
            postData(returnData)
        }else{
            toast('Please select pizza size!', {
                icon: '⚠️',
              });
        }        
        refreshPage()
    }

    return (

        <div className="flex justify-center items-center h-screen">

            <div className="bg-gray-200 p-4 rounded-lg shadow-lg h-[350px] w-[800px]">

                <div className="flex">

                <div className="w-1/2 p-4 ">
                <img className='w-full h-auto rounded-lg' src={'https://www.pizzachefs.com.au/wp-content/uploads/2017/03/pizza-placeholder.jpg'}/>
                </div>

                <div className="w-1/2 p-4 justify-start items-start ">
                <Select
                                            name="colors"
                                            options={sizes}
                                            className=" text-black font-semibold py-4 px-8 rounded mr-2"
                                            classNamePrefix="select"
                                            onChange={setCurrentSizePrice}
                                        />
                                        <Select
                                            isMulti
                                            name="colors"
                                            options={arr}
                                            className=" text-black font-semibold py-4 px-8 rounded mr-2 "
                                            classNamePrefix="select"
                                            onChange={setToppings}
                                        />
                                        <div className='flex space-x-5'>
                                            <button onClick={()=> checkSubmit()} className='bg-[#12486B] text-white font-semibold py-4 px-8 mr-2 rounded'>
                                                Add to cart
                                            </button>
                                            <Link to={`/orders`} className='bg-[#12486B] text-white font-semibold py-4 px-8 mr-2 rounded'>
                                                View Orders
                                            </Link>
                                        </div>
                </div>
                </div>
            </div>
            <Toaster 
                position="top-right"
                reverseOrder={false}
            />
        </div>


    )
}

export default ProductDetails