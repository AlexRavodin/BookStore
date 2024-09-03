import React, {useContext} from 'react';
import {Link} from 'react-router-dom';
import {AuthContext} from '../../../context/AuthContext';
import styles from './NavigationBar.module.scss';
import LogoutButton from "../../auth/LogoutButton/LogoutButton";

const NavigationBar = () => {
    const {user} = useContext(AuthContext);

    return (
        <nav className={styles.NavigationBar}>
            <ul>
                <li>
                    <Link to="/" className={styles.navLink}>
                        Home
                    </Link>
                </li>
                <li>
                    {user && user.isLoggedIn && user.claim === "customer" ? (
                        <ul>
                            <li><Link to="/books" className={styles.navLink}>
                                Books
                            </Link>
                            </li>
                            <li><Link to="/cart" className={styles.navLink}>
                                Cart
                            </Link>
                            </li>
                        </ul>
                    ) : user && user.isLoggedIn && user.claim === "admin" ? (
                        <Link to="/users" className={styles.navLink}>
                            Users
                        </Link>
                    ) : user && user.isLoggedIn && user.claim === "moderator" ?
                        (
                            <ul><li>
                                <Link to="/books/manager" className={styles.navLink}>
                                    Books
                                </Link>
                                </li>
                                <li><Link to="/books/manager/add" className={styles.navLink}>
                                    Add
                                </Link>
                                </li>
                            </ul>
                        ) : null}
                </li>
                <li>
                    {user && user.isLoggedIn ? (
                        <ul>
                            <li>
                                <Link to="/user" className={styles.navLink}>
                                Profile
                                </Link>
                            </li>
                            <li>
                                <LogoutButton>
                                    Logout
                                </LogoutButton>
                            </li>
                        </ul>
                    ) : (
                        <ul>
                            <li>
                                <Link to="/auth/login" className={styles.navLink}>
                                    Login
                                </Link>
                            </li>
                            <li>
                                <Link to="/auth/register" className={styles.navLink}>
                                    Register
                                </Link>
                            </li>
                        </ul>
                    )}
                </li>
            </ul>
        </nav>
    );
};

export default NavigationBar;
