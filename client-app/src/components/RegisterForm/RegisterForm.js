import React, {useContext, useState} from 'react';
import {useNavigate} from 'react-router-dom';
import {UserContext} from "../../context/UserContext";

const RegisterForm = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [error, setError] = useState(null);

    const {register} = useContext(UserContext);
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            await register(username, password, confirmPassword);
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
                <label>
                    Confirm Password:
                    <input type="password" value={confirmPassword}
                           onChange={(event) => setConfirmPassword(event.target.value)}/>
                </label>
                <br/>
                {error && <div style={{color: 'red'}}>{error}</div>}
                <button type="submit">Register</button>
            </form>
        </div>
    );
};

export default RegisterForm;