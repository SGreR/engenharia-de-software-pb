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
        setNotas(notasList);
        setLoading(notas === null);
    }, [notasList]);

    const handleEditClick = (notaId) => {
        navigate(`/notas/${notaId}`)
    };

    const handleDeleteClick = (notaId) => {
        setSelectedNotaId(notaId);
        setDeleteConfirmationOpen(true);
    };

    const handleDeleteConfirmation = () => {
        console.log(`Delete confirmed for Nota ID: ${selectedNotaId}`);
        setDeleteConfirmationOpen(false);
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
                    <TableCell>Aluno</TableCell>
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
                            <TableCell>{studentName == null ? nota.aluno.name : studentName}</TableCell>
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
            />
        </>
    );
}