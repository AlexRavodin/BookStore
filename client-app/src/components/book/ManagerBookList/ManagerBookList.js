import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import './ManagerBookList.css';

const ManagerBookList = ({ books }) => {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    return (
        <table className="book-list">
            <thead>
            <tr>
                <th></th>
                <th>Name</th>
                <th>Price</th>
                <th>Genre</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            {books.map((book) => (
                <tr key={book.id}>
                    <td>
                        <img src={`${process.env.PUBLIC_URL}/${book.imagePath}`}  width="80" height="120" alt={book.name}/>
                    </td>
                    <td>{book.name}</td>
                    <td>${book.price}</td>
                    <td>{book.genres.map(g => g.name).join(", ")}</td>
                    <td>
                        <Link to={`/book/manager/${book.id}`}>
                            <button>Details</button>
                        </Link>
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
    );
};

export default ManagerBookList;
