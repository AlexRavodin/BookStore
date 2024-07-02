import React, { useState, useEffect } from 'react';
import styles from './CartDetails.module.scss';
import axios from 'axios';

const CartDetails = () => {
    const [cart, setCart] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const loadCart = async () => {
            try {
                const response = await axios.get('http://localhost:5103/api/cart', {
                    withCredentials: true,
                });

                console.log(response.data);

                setCart(response.data);
                setLoading(false);
            } catch (error) {
                console.error(error);
                setError(error.message);
                setLoading(false);
            }
        };

        loadCart().then(() => {

        }).catch((error) => {
            console.error(error);
        });
    }, []);

    const handleUpdateCount = async (bookId, newCount) => {

        console.log(bookId);
        console.log(newCount);

        try {
            const response = await axios.post('http://localhost:5103/api/cart/change-count', {
                bookId,
                newCount,
            }, {
                withCredentials: true,
            });

            setCart(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    if (!cart) {
        return <div>No cart found.</div>;
    }

    return (
        <div className={styles.CartDetails}>
            <h2>Cart Details</h2>
            <div className={styles.grid}>
                {cart.cartItems.map((item, index) => (
                    <div key={index} className={styles.gridItem}>
                        <div className={styles.gridCell}>
                            <span>Name:</span>
                            <span>{item.bookName}</span>
                        </div>
                        <div className={styles.gridCell}>
                            <span>Price:</span>
                            <span>{item.price}</span>
                        </div>
                        <div className={styles.gridCell}>
                            <span>Count:</span>
                            <span>{item.count}</span>
                            <button onClick={() => handleUpdateCount(item.bookId, item.count + 1)}>+</button>
                            <button onClick={() => handleUpdateCount(item.bookId, item.count - 1)}>-</button>
                        </div>
                    </div>
                ))}
            </div>
            <p>Total: {cart.cartItems.reduce((acc, item) => acc + item.price * item.count, 0)}</p>
        </div>
    );
};

export default CartDetails;
