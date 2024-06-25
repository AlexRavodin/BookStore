import React, {useContext, useState} from 'react';
import {UserContext} from "../../context/UserContext";
import {useNavigate} from 'react-router-dom';

const LoginForm = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState(null);

    const {login} = useContext(UserContext);
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            login(username, password);
            navigate('/', {replace: true});
        } catch (error) {
            setError(error.message);
            console.error(error.message);
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <label>
                    Username:
                    <input type="text" value={username} onChange={(event) => setUsername(event.target.value)}/>
                </label>
                <br/>
                <label>
                    Password:
                    <input type="password" value={password} onChange={(event) => setPassword(event.target.value)}/>
                </label>
                <br/>
                {error && <div style={{color: 'red'}}>{error}</div>}
                <button type="submit">Login</button>
            </form>
        </div>
    );
};

export default LoginForm;
