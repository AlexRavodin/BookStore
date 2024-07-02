import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import styles from './UserDetails.module.scss';
import LogoutButton from "../../auth/LogoutButton/LogoutButton";

const UserDetails = () => {
    const { id } = useParams();
    const [loading, setLoading] = useState(true);
    const [user, setUser] = useState({});
    const [newImage, setNewImage] = useState(null);

    useEffect(() => {
        const loadUserCurrentUser = async () => {
            try {
                const response = await axios.get(`http://localhost:5103/api/users/current`, {
                    withCredentials: true,
                });

                console.log(response.data);

                setUser(response.data);
                setLoading(false);
            } catch (error) {
                console.error(error);
                setLoading(false);
            }
        };

        loadUserCurrentUser().then(() => {

        }).catch((error) => {
            console.error(error);
        });
    }, [id]);

    const handleImageChange = (event) => {
        setNewImage(event.target.files[0]);
    };

    const handleUpdateImage = () => {
        const formData = new FormData();
        formData.append('image', newImage);

        axios.post(`http://localhost:5103/api/images/user`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            },
        })
            .then((response) => {
                console.log("Image updated successfully!");
            })
            .catch((error) => {
                console.error(error);
            });
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    return (
        <div className={styles.userDetails}>
            <h2>User Details</h2>
            <img src={`${process.env.PUBLIC_URL}/${user.imagePath}`} alt={user.username} width="100" height="100"
                 className={styles.profileImage}/>
            <input type="file" onChange={handleImageChange}/>
            <button onClick={handleUpdateImage}>Update Image</button>
            <br/>
            <br/>
            <label>
                Username:
                <input type="text" value={user.username} disabled/>
            </label>
        </div>
    );
};

export default UserDetails;
