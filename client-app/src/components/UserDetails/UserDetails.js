import React, { useEffect, useContext, useState } from 'react';
import styles from './UserDetails.module.scss';
import LogoutButton from "../LogoutButton/LogoutButton";
import { UserContext } from "../../context/UserContext";
import { useParams } from 'react-router-dom';
import axios from 'axios';

const UserDetails = () => {
    const { user, setUser } = useContext(UserContext);
    const { id } = useParams();
    const [loading, setLoading] = useState(true);
    const [role, setRole] = useState('');

    useEffect(() => {
        const loadUserById = async () => {
            try {
                const response = await axios.get(`http://localhost:5103/api/auth/user/${id}`, {
                    withCredentials: true,
                });

                console.log("GOT DATA");
                console.log(response.data.level);

                setUser(response.data);

                setRole(response.data.level); // Set initial role value
                setLoading(false);
            } catch (error) {
                console.error(error);
                setLoading(false);
            }
        };

        loadUserById().then(() => {
            // Handle the promise returned by loadUserById
        }).catch((error) => {
            console.error(error);
        });
    }, [id]);

    const handleRoleChange = async (event) => {
        const newRole = event.target.value;
        setRole(newRole);

        try {
            const response = await axios.get(`http://localhost:5103/api/auth/change-role/${id}/${newRole}`, {
                withCredentials: true,
            });

            console.log("Role updated successfully");
        } catch (error) {
            console.error(error);
        }
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    if (!user) {
        return <div>User not found</div>;
    }

    return (
        <div className={styles.UserDetails}>
            <h2>User Details</h2>
            <ul>
                <li>
                    <strong>User ID:</strong> {user.id}
                </li>
                <li>
                    <strong>Username:</strong> {user.name}
                </li>
                <li>
                    <strong>Level:</strong>
                    <div>
                        <input type="radio" id="customer" name="role" value="Customer" checked={role === 'Customer'} onChange={handleRoleChange} />
                        <label htmlFor="customer">Customer</label>
                        <br />
                        <input type="radio" id="moderator" name="role" value="Moderator" checked={role === 'Moderator'} onChange={handleRoleChange} />
                        <label htmlFor="moderator">Moderator</label>
                        <br />
                        <input type="radio" id="admin" name="role" value="Admin" checked={role === 'Admin'} onChange={handleRoleChange} />
                        <label htmlFor="admin">Admin</label>
                    </div>
                </li>
            </ul>
            <LogoutButton/>
        </div>
    );
};

export default UserDetails;
