/* eslint-disable react/prop-types */
import React from 'react';
import Table from '@mui/joy/Table';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import {
    TableHead,
    TableBody,
    TableRow,
    TableCell,
    CircularProgress,
    IconButton,
} from '@mui/material';
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom'
import DeleteConfirmationModal from './DeleteConfirmationModal';

export default function NotasList({ studentName = null, notasList }) {
    const [notas, setNotas] = useState(null)
    const [loading, setLoading] = useState(true);
    const [deleteConfirmationOpen, setDeleteConfirmationOpen] = useState(false);
    const [selectedNotaId, setSelectedNotaId] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        const resolvedNotas = resolveReferences(notasList);
        setNotas(resolvedNotas);
        setLoading(resolvedNotas === null);
    }, [notasList]);

    const handleEditClick = (notaId) => {
        navigate(`/notas/${notaId}`)
    };

    const handleDeleteClick = (notaId) => {
        setSelectedNotaId(notaId);
        setDeleteConfirmationOpen(true);
    };

    const handleDeleteConfirmation = () => {
        setDeleteConfirmationOpen(false);
        window.location.reload();
    };

    const handleDeleteCancel = () => {
        setDeleteConfirmationOpen(false);
    };

    const resolveReferences = (notasList) => {

        const referencedObjects = new Map();
        notasList.forEach((nota) => {
            if (nota.aluno && nota.aluno.$id) {
                referencedObjects.set(nota.aluno.$id, nota.aluno);
            }
            if (nota.turma && nota.turma.$id) {
                referencedObjects.set(nota.turma.$id, nota.turma);
            }
        });

        return notasList.map((nota) => {
            if (nota.aluno && nota.aluno.$ref) {
                const referencedAluno = referencedObjects.get(nota.aluno.$ref);
                if (referencedAluno) {
                    nota.aluno = referencedAluno;
                }
            }

            if (nota.turma && nota.turma.$ref) {
                const referencedTurma = referencedObjects.get(nota.turma.$ref);
                if (referencedTurma) {
                    nota.turma = referencedTurma;
                }
            }

            return nota;
        });
    };

    return (
      <>
        <Table hoverRow stripe={'odd'} stickyHeader>
            <TableHead>
                <TableRow>
                    <TableCell>ID</TableCell>
                    <TableCell>Aluno</TableCell>
                    <TableCell>Turma</TableCell>
                    <TableCell>Semestre</TableCell>
                    <TableCell>Teste</TableCell>
                    <TableCell>Reading</TableCell>
                    <TableCell>Writing</TableCell>
                    <TableCell>Listening</TableCell>
                    <TableCell>Grammar</TableCell>
                    <TableCell>Speaking</TableCell>
                    <TableCell>Class Performance</TableCell>
                    <TableCell>Media Final</TableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {loading ? (
                    <TableRow>
                        <TableCell colSpan={10} style={{ textAlign: 'center' }}>
                            <CircularProgress />
                            Loading...
                        </TableCell>
                    </TableRow>
                    ) : (
                        notas.map((nota) => (
                        <TableRow key={nota.id}>
                            <TableCell>{nota.id}</TableCell>
                            <TableCell>{studentName === null ? nota.aluno.name : studentName}</TableCell>
                            <TableCell>{nota.turma.nome}</TableCell>
                            <TableCell>{nota.turma.ano}-{nota.turma.semestre}</TableCell>
                            <TableCell>{nota.numeroTeste}</TableCell>
                            <TableCell>{nota.reading.media}</TableCell>
                            <TableCell>{nota.writing.media}</TableCell>
                            <TableCell>{nota.grammar.media}</TableCell>
                            <TableCell>{nota.listening.media}</TableCell>
                            <TableCell>{nota.speaking.media}</TableCell>
                            <TableCell>{nota.classPerformance.media}</TableCell>
                            <TableCell>{nota.mediaFinal}%</TableCell>
                            <TableCell>
                                <IconButton onClick={() => handleEditClick(nota.id)} color="primary">
                                    <EditIcon />
                                </IconButton>
                                <IconButton onClick={() => handleDeleteClick(nota.id)} color="error">
                                    <DeleteIcon />
                                </IconButton>
                            </TableCell>
                        </TableRow>
                    ))
                )}
                </TableBody>
            </Table>
            <DeleteConfirmationModal
                open={deleteConfirmationOpen}
                onCancel={handleDeleteCancel}
                onConfirm={handleDeleteConfirmation}
                itemId={selectedNotaId}
                itemType={"Notas"}
            />
        </>
    );
}