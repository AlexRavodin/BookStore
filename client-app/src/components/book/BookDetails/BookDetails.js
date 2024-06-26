import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from "react-router-dom";
import styles from "./BookDetails.module.scss";

const BookDetails = () => {
    const params = useParams();
    const id = params.id;
    const [book, setBook] = useState({});

    useEffect(() => {
        axios.get(`http://localhost:5103/api/books/${id}`)
            .then(response => {
                setBook(response.data);
            })
            .catch(error => {
                console.error(error);
            });
    }, [id]);

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setBook({ ...book, [name]: value });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        const updateBookRequest = {
            Id: book.id,
            Name: book.name,
            Summary: book.summary,
            Price: book.price,
            QualityDescription: book.qualityDescription,
        };
        axios.put(`http://localhost:5103/api/books`, updateBookRequest)
            .then(response => {
                console.log("Book updated successfully!");
            })
            .catch(error => {
                console.error(error);
            });
    };

    const handleDeleteBook = () => {
        axios.delete(`http://localhost:5103/api/books/${id}`)
            .then(response => {
                console.log("Book deleted successfully!");
                // You can also redirect the user to a different page or update the UI here
            })
            .catch(error => {
                console.error(error);
            });
    };

    return (
        <div className={styles.bookDetails}>
            <form onSubmit={handleSubmit}>
                <label>
                    Name:
                    <input type="text" name="name" value={book.name} onChange={handleInputChange}/>
                </label>
                <br/>
                <label>
                    Summary:
                    <textarea name="summary" value={book.summary} onChange={handleInputChange}/>
                </label>
                <br/>
                <label>
                    Price:
                    <input type="number" name="price" value={book.price} onChange={handleInputChange}/>
                </label>
                <br/>
                <label>
                    Genre:
                    <input type="text" name="genreName" value={book.genreName} onChange={handleInputChange}/>
                </label>
                <br/>
                <label>
                    Quality:
                    <input type="text" name="qualityDescription" value={book.qualityDescription}
                           onChange={handleInputChange}/>
                </label>
                <br/>
                <button type="submit">Save Changes</button>
                <button type="button" onClick={handleDeleteBook}>Delete</button>
            </form>
        </div>
    );
};

export default BookDetails;