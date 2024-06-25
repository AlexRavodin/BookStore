import React from 'react';
import styles from './MainPage.module.scss';
import LogoutButton from "../LogoutButton/LogoutButton";
import {Link} from "react-router-dom";

const MainPage = () => (
  <div className={styles.MainPage}>
    MainPage Component

      <div>
          <ul>
              <li>
                  <Link to="/userDetails">User details</Link>
              </li>
              <li>
                  <Link to="/login">Login</Link>
              </li>
              <li>
                  <Link to="/register">Register</Link>
              </li>
          </ul>
          <LogoutButton/>
      </div>
  </div>
);

export default MainPage;
