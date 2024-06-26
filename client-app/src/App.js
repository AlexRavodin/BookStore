import './App.css';
import * as PropTypes from "prop-types";
import LoginForm from "./components/auth/LoginForm/LoginForm";
import RegisterForm from "./components/auth/RegisterForm/RegisterForm";
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import MainPage from "./components/common/MainPage/MainPage";
import AuthProvider from "./providers/AuthProvider";
import NavigationBar from "./components/common/NavigationBar/NavigationBar";
import BookCatalog from "./components/book/BookCatalog/BookCatalog";
import BookDetails from "./components/book/BookDetails/BookDetails";
import UserCatalog from "./components/user/UserCatalog/UserCatalog";
import UserDetails from "./components/user/UserDetails/UserDetails";
import CartDetails from "./components/cart/CartDetails/CartDetails";

BrowserRouter.propTypes = {children: PropTypes.node};

function App() {
    return (
        <AuthProvider>
            <BrowserRouter>
                <NavigationBar/>
                <Routes>
                    <Route exact path="/" element={<MainPage/>}/>

                    <Route path="/auth/login" element={<LoginForm/>}/>
                    <Route path="/auth/register" element={<RegisterForm/>}/>

                    <Route path="/users" element={<UserCatalog/>}/>
                    <Route path="/user/:id" element={<UserDetails/>}/>

                    <Route path="/books" element={<BookCatalog/>}/>
                    <Route path="/book/:id" element={<BookDetails/>}/>

                    <Route path="/cart" element={<CartDetails/>}/>
                </Routes>
            </BrowserRouter>
        </AuthProvider>
    );
}

export default App;
