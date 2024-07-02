import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from "react-router-dom";
import styles from "./ManagerBookDetails.module.scss";
import Select from "react-select";

const ManagerBookDetails = () => {
    const params = useParams();
    const id = params.id;
    const [book, setBook] = useState({}); // initialize book as an empty object
    const [newImage, setNewImage] = useState(null);
    const [selectedGenres, setSelectedGenres] = useState([]);
    const [loading, setLoading] = useState(true); // add a loading state

    useEffect(() => {
        console.log("request will be send!");
        axios.get(`http://localhost:5103/api/books/${id}`)
            .then(response => {
                setBook(response.data);
                const selectedGenres = response.data.genres.filter(genre => genre.selected);
                setSelectedGenres(selectedGenres.map(genre => ({
                    value: genre.id,
                    label: genre.name,
                })));
                setLoading(false); // set loading to false when data is fetched
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
            Genres: selectedGenres.map(genre => genre.value),
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

    const handleImageChange = (event) => {
        setNewImage(event.target.files[0]);
    };

    const handleUpdateImage = () => {
        const formData = new FormData();
        formData.append('image', newImage);

        axios.post(`http://localhost:5103/api/images/book/${id}`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            }
        })
            .then(response => {
                console.log("Image updated successfully!");
            })
            .catch(error => {
                console.error(error);
            });
    };

    const handleGenreChange = (options) => {
        setSelectedGenres(options);
    };

    return (
        <div className={styles.ManagerBookDetails}>
            {loading ? (
                <p>Loading...</p>
            ) : (
                <div>
                    <div className={styles.imageContainer}>
                        <img src={`${process.env.PUBLIC_URL}/${book.imagePath}`} alt={book.name} width="300" height="550" className={styles.bookImage} />
                        <input type="file" onChange={handleImageChange} />
                        <button onClick={handleUpdateImage}>Change Image</button>
                    </div>
                    <div className={styles.formContainer}>
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
                                {book.genres ? (
                                    <Select
                                        isMulti={true}
                                        value={selectedGenres}
                                        onChange={handleGenreChange}
                                        options={[
                                            ...book.genres.filter(genre => !genre.selected).map(genre => ({
                                                value: genre.id,
                                                label: genre.name,
                                            })),
                                        ]}
                                    />
                                ) : (
                                    <p>No genres available</p>
                                )}
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
                </div>
            )}
        </div>
    );
};

export default ManagerBookDetails;
