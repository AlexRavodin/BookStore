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
                console.log(book.genres);
            })
            .catch(error => {
                console.error(error);
            });
    }, [id]);

    useEffect(() => {
        if (book.genres) {
            console.log(book.genres.map(g => g.name).join(", "));
        }
    }, [book]);

    return (
        <div className={styles.bookDetails}>
            <div className={styles.imageContainer}>
                <img src={`${process.env.PUBLIC_URL}/${book.imagePath}`} alt={book.name} width="300" height="550" className={styles.bookImage} />
            </div>
            <div className={styles.formContainer}>
                <form>
                    <label>
                        Name:
                        <input type="text" name="name" value={book.name} disabled={true}/>
                    </label>
                    <br/>
                    <label>
                        Summary:
                        <textarea name="summary" value={book.summary} disabled={true}/>
                    </label>
                    <br/>
                    <label>
                        Price:
                        <input type="number" name="price" value={book.price} disabled={true}/>
                    </label>
                    <br/>
                    <label>
                        Genre:
                        <input type="text" name="genreName" value={book.genres.map(g => g.name).join(", ")} disabled={true}/>
                    </label>
                    <br/>
                </form>
            </div>
        </div>
    );
};

export default BookDetails;
