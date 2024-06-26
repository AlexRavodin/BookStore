import React, {useEffect, useState} from "react";
import axios from "axios";
import FilterForm from "../FilterForm/FilterForm";
import BookList from "../BookList/BookList";
import PaginationBar from "../../common/PaginantionBar/PaginationBar";
import styles from "./BookCatalog.module.scss";

const BookCatalog = () => {
    const [books, setBooks] = useState([]);
    const [pageCount, setPageCount] = useState(2);
    const [parameters, setParameters] = useState({
        PageSize: 3,
        PageIndex: 1,
        MinimalPrice: 100,
        MaximumPrice: 200,
        Name: '',
        OrderByPriceAscending: false,
        OrderByPriceDescending: false
    });

    useEffect(() => {
        axios.create({
            baseURL: 'http://localhost:5103/api/',
            withCredentials: true,
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .get('/books', {
                params: parameters
            })
            .then(response => {
                setBooks(response.data);
                const paginationHeader = response.headers.get('x-pagination');
                const paginationData = JSON.parse(paginationHeader);
                setPageCount(paginationData.TotalPages);
            })
            .catch(error => {
                console.error(error);
            });
    }, [parameters]);

    const handlePageClick = (event) => {
        const newPageIndex = event.selected + 1;
        setParameters({
            ...parameters,
            PageIndex: newPageIndex
        });
    };

    return (
        <div className={styles.bookCatalogContainer}>
            <div className={styles.bookCatalogInnerContainer}>
                <div className={styles.filterFormContainer}>
                    <FilterForm parameters={parameters} setParameters={setParameters}/>
                </div>
                <div className={styles.bookListContainer}>
                    <BookList books={books}/>
                </div>
            </div>
            <div className={styles.paginationBarContainer}>
                <PaginationBar pageCount={pageCount} onPageChange={handlePageClick}/>
            </div>
        </div>
    );
};

export default BookCatalog;