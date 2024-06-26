import React, { useContext, useState, useEffect } from 'react';
import { AuthContext } from "../../../context/AuthContext";
import { useNavigate } from 'react-router-dom';
import styles from './LoginForm.module.scss';

const LoginForm = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState(null);

    const { user, login } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const result = await login(username, password);
            console.log('Login result:', result);
        } catch (error) {
            setError(error.message);
            console.error(error.message);
        }
    };

    useEffect(() => {
        if (user !== null && user.isLoggedIn) {
            console.log(user.claim);
            navigate('/', { replace: true });
        }
    }, [navigate, user]);

    return (
        <div className={styles.LoginForm}>
            <form onSubmit={handleSubmit}>
                <label>
                    Username:
                    <input type="text" value={username} onChange={(event) => setUsername(event.target.value)} />
                </label>
                <br />
                <label>
                    Password:
                    <input type="password" value={password} onChange={(event) => setPassword(event.target.value)} />
                </label>
                <br />
                {error && <div className={styles.error}>{error}</div>}
                <button type="submit">Login</button>
            </form>
        </div>
    );
};

export default LoginForm;
