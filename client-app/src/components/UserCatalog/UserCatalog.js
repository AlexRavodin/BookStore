import React, { useState, useEffect } from 'react';
import axios from 'axios';
import styles from './UserCatalog.module.scss';
import {Link} from "react-router-dom";

const UserCatalog = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const response = await axios.get('http://localhost:5103/api/auth/users', {
                    withCredentials: true,
                });

                console.log("GOT DATA");

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
        <div className={styles.UserCatalog}>
            <h2>User Catalog</h2>
            <ul>
                {users.map((user) => (
                    <li key={user.id}>
                        <strong>User ID:</strong> {user.id}
                        <br/>
                        <strong>Username:</strong> {user.username}
                        <br/>
                        <strong>Claim:</strong> {user.claim}
                        <br/>
                        <Link to={`/user/${user.id}`}>
                            <button>View Details</button>
                        </Link>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default UserCatalog;
