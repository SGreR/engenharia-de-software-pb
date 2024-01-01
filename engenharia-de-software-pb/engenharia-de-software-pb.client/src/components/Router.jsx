import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import HomePage from '../pages/HomePage';
import AlunoListPage from '../pages/AlunoListPage';
import AlunoDetailPage from '../pages/AlunoDetailPage';
import NotasListPage from '../pages/NotasListPage';
import NotasDetailPage from '../pages/NotasDetailPage';
import AlunoCreatePage from '../pages/AlunoCreatePage';
import NotasCreatePage from '../pages/NotasCreatePage';

function ReactComponent() {
  return (
      <Routes>
          <Route element={<HomePage />} exact path="/" />
          <Route element={<HomePage />} exact path="/home" />
          <Route element={<AlunoListPage />} exact path="/alunos" />
          <Route element={<AlunoDetailPage />} exact path="/alunos/:id" />
          <Route element={<AlunoCreatePage />} exact path="/alunos/create" />
          <Route element={<NotasListPage />} exact path="/notas" />
          <Route element={<NotasDetailPage />} exact path="/notas/:id" />
          <Route element={<NotasCreatePage />} exact path="/notas/create" />
      </Routes>
  );
}

export default ReactComponent;