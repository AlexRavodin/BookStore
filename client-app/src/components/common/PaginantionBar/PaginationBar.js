import React from 'react';
import ReactPaginate from 'react-paginate';
import { AiFillLeftCircle, AiFillRightCircle } from "react-icons/ai";
import { IconContext } from "react-icons";
import "./PaginationBar.css"

const Pagination = ({  pageCount, onPageChange }) => {
    return (
        <ReactPaginate
            containerClassName={"pagination"}
            pageClassName={"page-item"}
            activeClassName={"active"}
            onPageChange={onPageChange}
            pageCount={pageCount}
            breakLabel="..."
            pageRangeDisplayed={3}
            previousLabel={
                <IconContext.Provider value={{ color: "#B8C1CC", size: "36px" }}>
                    <AiFillLeftCircle />
                </IconContext.Provider>
            }
            nextLabel={
                <IconContext.Provider value={{ color: "#B8C1CC", size: "36px" }}>
                    <AiFillRightCircle />
                </IconContext.Provider>
            }
        />
    );
};

export default Pagination;