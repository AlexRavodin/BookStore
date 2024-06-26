import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import styles from './UserCatalog.css';

const UserCatalog = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const response = await axios.get('http://localhost:5103/api/users', {
                    withCredentials: true,
                });
                setUsers(response.data);
                console.log(response.data);
            } catch (error) {
                console.error(error);
            }
        };

        fetchUsers().then(() => {
            // Handle the promise returned by fetchUsers
        }).catch((error) => {
            console.error(error);
        });
    }, []);

    return (
        <table className="user-catalog">
            <thead>
            <tr>
                <th>User ID</th>
                <th>Username</th>
                <th>Claim</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            {users.map((user) => (
                <tr key={user.id}>
                    <td>{user.id}</td>
                    <td>{user.username}</td>
                    <td>{user.claim}</td>
                    <td>
                        <Link to={`/user/${user.id}`}>
                            <button>View Details</button>
                        </Link>
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
    );
};

export default UserCatalog;
