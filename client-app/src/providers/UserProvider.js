import React, {useState} from 'react';
import axios from "axios";
import {UserContext} from "../context/UserContext";

const UserProvider = ({children}) => {
    const [user, setUser] = useState(null);

    const login = async (username, password) => {
        try {
            await axios.post('http://localhost:5103/api/auth/login',
                {username, password }
            );

            /*const loggedUser = loadUser();
            setUser(loggedUser);*/
        } catch (error) {
            console.error(error.message);
        }
    };

    const logout = async () => {
        await axios.get('http://localhost:5103/api/auth/logout',
            {withCredentials: true});
        setUser(null);
    };

    const register = async (username, password, confirmPassword) => {
        try {
            await axios.post('http://localhost:5103/api/auth/register',
                {username, password, confirmPassword }
            );

            const loggedUser = loadUser();
            setUser(loggedUser);
        } catch (error) {
            console.error(error.message);
        }
    }

    const loadUser = async () => {
        try {
            const response = await axios.get('http://localhost:5103/api/auth/users',
                {withCredentials: true}
            );

            console.log(response.data);

            setUser(response.data);
        } catch (error) {
            console.error(error);
        }
    }

    const loadUserById = async (userId) => {
        try {
            const response = await axios.get(`http://localhost:5103/api/auth/users/${userId}`, {
                withCredentials: true,
            });

            console.log(response.data);

            setUser(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <UserContext.Provider value={{user, setUser, login, logout, register, loadUser}}>
            {children}
        </UserContext.Provider>
    );
};

export {UserProvider};