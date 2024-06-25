import './App.css';
import * as PropTypes from "prop-types";
import UserCatalog from "./components/UserCatalog/UserCatalog";
import LoginForm from "./components/LoginForm/LoginForm";
import RegisterForm from "./components/RegisterForm/RegisterForm";
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import MainPage from "./components/MainPage/MainPage";
import UserDetails from "./components/UserDetails/UserDetails";
import {UserProvider} from "./providers/UserProvider";

BrowserRouter.propTypes = {children: PropTypes.node};

function App() {
    return (
        <UserProvider>
            <BrowserRouter>
                <Routes>
                    <Route exact path="/" element={<MainPage/>}/>
                    <Route path="/user/:id" element={<UserDetails/>}/>
                    <Route path="/login" element={<LoginForm/>}/>
                    <Route path="/register" element={<RegisterForm/>}/>
                    <Route path="/userCatalog" element={<UserCatalog/>}/>
                </Routes>
            </BrowserRouter>
        </UserProvider>
    );
}

export default App;
