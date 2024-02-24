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

export default function TurmasList({ turmasList }) {
    const [turmas, setTurmas] = useState(null)
    const [loading, setLoading] = useState(true);
    const [deleteConfirmationOpen, setDeleteConfirmationOpen] = useState(false);
    const [selectedTurmaId, setSelectedTurmaId] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        setTurmas(turmasList)
        setLoading(turmasList === null);
    }, [turmasList]);

    const handleEditClick = (turmaId) => {
        navigate(`/turmas/${turmaId}`)
    };

    const handleDeleteClick = (turmaId) => {
        setSelectedTurmaId(turmaId);
        setDeleteConfirmationOpen(true);
    };

    const handleDeleteConfirmation = () => {
        setDeleteConfirmationOpen(false);
        window.location.reload();
    };

    const handleDeleteCancel = () => {
        setDeleteConfirmationOpen(false);
    };


    return (
        <>
            <Table hoverRow stripe={'odd'} stickyHeader>
                <TableHead>
                    <TableRow>
                        <TableCell>ID</TableCell>
                        <TableCell>Turma</TableCell>
                        <TableCell>Alunos</TableCell>
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
                        turmas.map((turma) => (
                            <TableRow key={turma.id}>
                                <TableCell>{turma.id}</TableCell>
                                <TableCell>{turma.nome}</TableCell>
                                <TableCell>{turma.alunos.count}</TableCell>
                                <TableCell>
                                    <IconButton onClick={() => handleEditClick(turma.id)} color="primary">
                                        <EditIcon />
                                    </IconButton>
                                    <IconButton onClick={() => handleDeleteClick(turma.id)} color="error">
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
                itemId={selectedTurmaId}
                itemType={"Turmas"}
            />
        </>
    );
}