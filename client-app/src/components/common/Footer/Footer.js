import React from 'react';
import styles from './Footer.module.scss';

const Footer = () => {
    return (
        <footer className={styles.footer}>
            <div className={styles.footerContent}>
                <p className={styles.footerText}>© {new Date().getFullYear()} Book Store</p>
                <p className={styles.footerText}>Created on: 01 September 2024</p>
                <a
                    href="https://github.com/AlexRavodin"
                    target="_blank"
                    rel="noopener noreferrer"
                    className={styles.footerLink}
                >
                    GitHub Repository
                </a>
                <p className={styles.footerMessage}>Thank you for visiting our store. Happy reading!</p>
            </div>
        </footer>
    );
};

export default Footer;