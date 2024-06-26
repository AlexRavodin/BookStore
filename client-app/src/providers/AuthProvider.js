import React, {useEffect, useState} from 'react';
import axios from "axios";
import {AuthContext} from "../context/AuthContext";

const AuthProvider = ({children}) => {
    const [user, setUser] = useState(null);

    useEffect(() => {
        const storedUser = localStorage.getItem('user');
        if (storedUser) {
            console.log("User logged in.")
            const claim  = localStorage.getItem('claim');
            setUser({ claim : claim, isLoggedIn: true });
        } else {
            console.log("User is not logged in.")
            setUser(null);
        }
    }, []);

    const login = async (username, password) => {
        const response = await axios.post('http://localhost:5103/api/auth/login',
            {username, password}
        );

        localStorage.setItem('user', "logged in.");
        localStorage.setItem('claim', response.data["claim"]);
        const loggedUser = { claim : response.data["claim"], isLoggedIn: true };
        setUser(loggedUser);
    };

    const register = async (username, password, confirmPassword) => {
        const response = await axios.post('http://localhost:5103/api/auth/register',
            {username, password, confirmPassword}
        );

        localStorage.setItem('user', "logged in.");
        localStorage.setItem('claim', response.data["claim"]);
        const registeredUser = { claim : response.data["claim"], isLoggedIn: true };
        setUser(registeredUser);
    }

    const logout = async () => {
        await axios.get('http://localhost:5103/api/auth/logout',
            {withCredentials: true});

        localStorage.removeItem('user');
        localStorage.removeItem('claim');
        setUser(null);
    };

    return (
        <AuthContext.Provider value={{user, setUser, login, logout, register}}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthProvider;