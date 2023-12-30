// App.js
import React from 'react';
import './App.css';
import { BrowserRouter,Route, Link } from 'react-router-dom';
import AlunoPage from './pages/AlunoListPage';
import NotasPage from './pages/NotasListPage';
import HomePage from './pages/HomePage';
import Router from './components/Router'
import Header from './components/Header';

const App = () => {
    return (
        <BrowserRouter>
            <Header />
            <div className="content">
                <Router />
            </div>
        </BrowserRouter>
    );
};

export default App;
