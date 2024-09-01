import React from 'react';
import styles from './MainPage.module.scss';

const MainPage = () => (
    <div className={styles.MainPage}>
        <div className={styles.welcomeSection}>
            <img
                src={`${process.env.PUBLIC_URL}/images/common/welcome-image.webp`}
                alt="Welcome to Our Book Store"
                className={styles.welcomeImage}
            />
            <h1 className={styles.welcomeTitle}>Welcome to Our Book Store</h1>
            <p className={styles.welcomeMessage}>
                Discover a world of books that will inspire, educate, and entertain you.
                From timeless classics to the latest bestsellers, our collection is curated
                to offer something for every reader.
            </p>
        </div>
    </div>
);

export default MainPage;