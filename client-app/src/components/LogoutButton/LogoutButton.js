import React, {useContext} from 'react';
import styles from './LogoutButton.module.scss';
import {UserContext} from "../../context/UserContext";
import { useNavigate } from 'react-router-dom';

const LogoutButton = () => {
    const { logout } = useContext(UserContext);
    const navigate = useNavigate();

    const handleLogout = async () => {
        try {
            logout();
        } catch (error) {
            console.error(error);
        }
        navigate('/', { replace: true });
    };

    return (
        <div className={styles.LogoutButton}>
            <button onClick={handleLogout}>Logout</button>
        </div>
    );
};

export default LogoutButton;