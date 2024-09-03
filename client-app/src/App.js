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
import AdminUserDetails from "./components/user/AdminUserDetails/AdminUserDetails";
import ManagerBookDetails from "./components/book/ManagerBookDetails/ManagerBookDetails";
import ManagerBookCatalog from "./components/book/ManagerBookCatalog/ManagerBookCatalog";
import Footer from "./components/common/Footer/Footer";
import BookAddForm from "./components/book/BookAddForm/BookAddForm";


BrowserRouter.propTypes = {children: PropTypes.node};

function App() {
    return (
        <BrowserRouter>
            <AuthProvider>
                <NavigationBar/>
                <div className="MainContent">
                    <Routes>
                        <Route exact path="/" element={<MainPage/>}/>

                        <Route path="/auth/login" element={<LoginForm/>}/>
                        <Route path="/auth/register" element={<RegisterForm/>}/>

                        <Route path="/users" element={<UserCatalog/>}/>
                        <Route path="/user/:id" element={<AdminUserDetails/>}/>
                        <Route path="/user" element={<UserDetails/>}/>

                        <Route path="/books" element={<BookCatalog/>}/>
                        <Route path="/books/manager" element={<ManagerBookCatalog/>}/>
                        <Route path="/books/manager/add" element={<BookAddForm/>}/>
                        <Route path="/book/:id" element={<BookDetails/>}/>
                        <Route path="/book/manager/:id" element={<ManagerBookDetails/>}/>

                        <Route path="/cart" element={<CartDetails/>}/>
                    </Routes>
                    
                </div>
                <Footer/>
            </AuthProvider>
        </BrowserRouter>
    );
}

export default App;
