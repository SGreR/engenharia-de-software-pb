import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import HomePage from '../pages/HomePage';
import AlunoListPage from '../pages/AlunoListPage';
import NotasListPage from '../pages/NotasListPage';

function ReactComponent() {
  return (
      <Routes>
          <Route element={<HomePage />} exact path="/" />
          <Route element={<HomePage />} exact path="/home" />
          <Route element={<AlunoListPage />} exact path="/alunos" />
          <Route element={<NotasListPage />} exact path="/notas" />
      </Routes>
  );
}

export default ReactComponent;