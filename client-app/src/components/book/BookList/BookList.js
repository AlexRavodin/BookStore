import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import './BookList.css';
import {string} from "prop-types";

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
                <th></th>
                <th>Name</th>
                <th>Price</th>
                <th>Genres</th>
                <th>Actions</th>
                <th>Add to Cart</th>
            </tr>
            </thead>
            <tbody>
            {books.map((book) => (
                <tr key={book.id}>
                    <td>
                        <img src={book.imagePath} width="80" height="120" alt={book.name}/>
                    </td>
                    <td>{book.name}</td>
                    <td>${book.price}</td>
                    <td>{book.genres.map(g => g.name).join(", ")}</td>
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
