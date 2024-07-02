import React, { useState, useEffect } from 'react';
import styles from './AdminUserDetails.module.scss';
import {useNavigate, useParams} from 'react-router-dom';
import axios from 'axios';

const AdminUserDetails = () => {
    const { id } = useParams();
    const [loading, setLoading] = useState(true);
    const [user, setUser] = useState({});
    const [role, setRole] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        axios.get(`http://localhost:5103/api/users/${id}`, { withCredentials: true })
            .then(response => {
                setUser(response.data);
                setRole(response.data.role.split(" ")[1]);
                setLoading(false);
            })
            .catch(error => {
                console.error(error);
                setLoading(false);
            });
    }, [id]);

    const handleRoleChange = async event => {
        const newRole = event.target.value;
        setRole(newRole);
        try {
            await axios.post(`http://localhost:5103/api/users/change-role/`, { userId: id, newRoleName: newRole }, { withCredentials: true });
            console.log("Role updated successfully");
        } catch (error) {
            console.error(error);
        }
    };

    const handleDelete = async () => {
        try {
            await axios.delete(`http://localhost:5103/api/users/${id}`, { withCredentials: true });
            console.log("User deleted successfully");
            navigate('/users', { replace: true });
            // You can also redirect the user to a different page or show a success message
        } catch (error) {
            console.error(error);
        }
    };

    if (loading) return <div className={styles.loading}>Loading...</div>;
    if (!user) return <div className={styles.notFound}>User not found</div>;

    return (
        <div className={styles.AdminUserDetails}>
            <h2 className={styles.title}>User Details</h2>
            <ul className={styles.list}>
                <li>
                    <strong className={styles.label}>User ID:</strong> {user.userId}
                </li>
                <li>
                    <strong className={styles.label}>Username:</strong> {user.username}
                </li>
                <li>
                    <strong className={styles.label}>Role:</strong>
                    <div className={styles.roleContainer}>
                        <input type="radio" id="customer" name="role" value="customer" checked={role === 'customer'}
                               onChange={handleRoleChange}/>
                        <label htmlFor="customer">Customer</label>
                        <br/>
                        <input type="radio" id="moderator" name="role" value="moderator" checked={role === 'moderator'}
                               onChange={handleRoleChange}/>
                        <label htmlFor="moderator">Moderator</label>
                        <br/>
                        <input type="radio" id="admin" name="role" value="admin" checked={role === 'admin'}
                               onChange={handleRoleChange}/>
                        <label htmlFor="admin">Admin</label>
                    </div>
                </li>
                <li>
                    <button className={styles.deleteButton} onClick={handleDelete}>Delete User</button>
                </li>
            </ul>
        </div>
    );
};

export default AdminUserDetails;
