import React from 'react';
import "./FilterForm.css"

const FilterForm = ({ parameters, setParameters }) => {
    const handleFilterChange = (event) => {
        const { name, value, type, checked } = event.target;
        setParameters((prevParameters) => {
            const newParameters = { ...prevParameters };
            if (type === 'checkbox') {
                newParameters[name] = checked;
            } else {
                newParameters[name] = value;
            }
            return newParameters;
        });
    };
    
    return (
        <form className="filter-form">
            <h2>Filter Options</h2>
            <div className="filter-group">
                <label>Minimal Price:</label>
                <input type="number" name="MinimalPrice" value={parameters.MinimalPrice} onChange={handleFilterChange} />
            </div>
            <div className="filter-group">
                <label>Maximum Price:</label>
                <input type="number" name="MaximumPrice" value={parameters.MaximumPrice} onChange={handleFilterChange} />
            </div>
            <div className="filter-group">
                <label>Name:</label>
                <input type="text" name="Name" value={parameters.Name} onChange={handleFilterChange} />
            </div>
            <div className="filter-group">
                <label>Order by Price Ascending:</label>
                <input type="checkbox" name="OrderByPriceAscending" checked={parameters.OrderByPriceAscending} onChange={handleFilterChange} />
            </div>
            <div className="filter-group">
                <label>Order by Price Descending:</label>
                <input type="checkbox" name="OrderByPriceDescending" checked={parameters.OrderByPriceDescending} onChange={handleFilterChange} />
            </div>
        </form>
    );
};

export default FilterForm;
