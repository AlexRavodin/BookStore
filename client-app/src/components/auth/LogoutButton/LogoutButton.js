import React, {useContext} from 'react';
import styles from './LogoutButton.module.scss';
import {AuthContext} from "../../../context/AuthContext";
import { useNavigate } from 'react-router-dom';

const LogoutButton = () => {
    const { logout } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleLogout = async () => {
        try {
            logout();
            console.log('Logged out');
        } catch (error) {
            console.log('error');
            console.error(error);
        }
        navigate('/', { replace: true });
    };

    return (
        <button className={styles.LogoutButton} onClick={handleLogout}>Logout</button>
    );
};

export default LogoutButton;