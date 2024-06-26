import React, { useEffect, useState } from 'react';
import styles from './UserDetails.module.scss';
import LogoutButton from "../../auth/LogoutButton/LogoutButton";
import { useParams } from 'react-router-dom';
import axios from 'axios';

const UserDetails = () => {
    const { id } = useParams();
    const [loading, setLoading] = useState(true);
    const [user, setUser] = useState({});
    const [role, setRole] = useState('');

    useEffect(() => {
        const loadUserById = async () => {
            try {
                const response = await axios.get(`http://localhost:5103/api/users/${id}`, {
                    withCredentials: true,
                });

                console.log(response.data);

                setUser(response.data);
                setRole(response.data.role.split(" ")[1]);
                setLoading(false);
            } catch (error) {
                console.error(error);
                setLoading(false);
            }
        };

        loadUserById().then(() => {

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
        return <div className={styles.loading}>Loading...</div>;
    }

    if (!user) {
        return <div className={styles.notFound}>User not found</div>;
    }

    return (
        <div className={styles.UserDetails}>
            <h2 className={styles.title}>User Details</h2>
            <ul className={styles.list}>
                <li>
                    <strong className={styles.label}>User ID:</strong> {user.userId}
                </li>
                <li>
                    <strong className={styles.label}>Username:</strong> {user.username}
                </li>
                <li>
                    <strong className={styles.label}>Level:</strong>
                    <div className={styles.roleContainer}>
                        <input type="radio" id="customer" name="role" value="customer" checked={role === 'customer'} onChange={handleRoleChange} />
                        <label htmlFor="customer">Customer</label>
                        <br />
                        <input type="radio" id="moderator" name="role" value="moderator" checked={role === 'moderator'} onChange={handleRoleChange} />
                        <label htmlFor="moderator">Moderator</label>
                        <br />
                        <input type="radio" id="admin" name="role" value="admin" checked={role === 'admin'} onChange={handleRoleChange} />
                        <label htmlFor="admin">Admin</label>
                    </div>
                </li>
            </ul>
            <LogoutButton className={styles.logoutButton} />
        </div>
    );
};

export default UserDetails;
