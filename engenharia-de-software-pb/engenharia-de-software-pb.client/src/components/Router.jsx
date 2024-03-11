import React from 'react';
import { Routes, Route } from 'react-router-dom'
import HomePage from '../pages/HomePage';
import AlunoListPage from '../pages/Alunos/AlunoListPage';
import AlunoDetailPage from '../pages/Alunos/AlunoDetailPage';
import NotasListPage from '../pages/Notas/NotasListPage';
import NotasDetailPage from '../pages/Notas/NotasDetailPage';
import AlunoCreatePage from '../pages/Alunos/AlunoCreatePage';
import NotasCreatePage from '../pages/Notas/NotasCreatePage';
import TurmasListPage from '../pages/Turmas/TurmasListPage';
import TurmasCreatePage from '../pages/Turmas/TurmaCreatePage';
import TurmasDetailPage from '../pages/Turmas/TurmasDetailPage';
import ProfessorListPage from '../pages/Professores/ProfessorListPage';
import ProfessorCreatePage from '../pages/Professores/ProfessorCreatePage';
import ProfessorDetailPage from '../pages/Professores/ProfessorDetailPage';

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
          <Route element={<TurmasListPage />} exact path="/turmas" />
          <Route element={<TurmasDetailPage />} exact path="/turmas/:id" />
          <Route element={<TurmasCreatePage />} exact path="/turmas/create" />
          <Route element={<ProfessorListPage />} exact path="/professores" />
          <Route element={<ProfessorDetailPage />} exact path="/professores/:id" />
          <Route element={<ProfessorCreatePage />} exact path="/professores/create" />

      </Routes>
  );
}

export default ReactComponent;