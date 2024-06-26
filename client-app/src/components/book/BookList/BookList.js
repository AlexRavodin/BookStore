import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import './BookList.css';

const BookList = ({ books }) => {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleAddToCart = async (bookId) => {
        setLoading(true);
        try {
            const response = await axios.put(`http://localhost:5103/api/cart/${bookId}`, {}, {
                withCredentials: true,
            });
            console.log(response.data);
        } catch (error) {
            setError(error.message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <table className="book-list">
            <thead>
            <tr>
                <th>Name</th>
                <th>Price</th>
                <th>Genre</th>
                <th>Actions</th>
                <th>Add to Cart</th> {/* New column */}
            </tr>
            </thead>
            <tbody>
            {books.map((book) => (
                <tr key={book.id}>
                    <td>{book.name}</td>
                    <td>${book.price}</td>
                    <td>{book.genreName}</td>
                    <td>
                        <Link to={`/book/${book.id}`}>
                            <button>Details</button>
                        </Link>
                    </td>
                    <td>
                        <button onClick={() => handleAddToCart(book.id)}>Add to Cart</button>
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
    );
};

export default BookList;
