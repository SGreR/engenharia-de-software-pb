/* eslint-disable react/prop-types */
import { useEffect, useState } from 'react';
import Table from '@mui/joy/Table';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import RemoveIcon from '@mui/icons-material/Remove';

import {
    TableHead,
    TableBody,
    TableRow,
    TableCell,
    CircularProgress,
    IconButton,
} from '@mui/material';
import { useNavigate } from 'react-router-dom'
import DeleteConfirmationModal from './DeleteConfirmationModal';

export default function AlunoList({ turma = false, alunosList, handleRemove }) {
    const [alunos, setAlunos] = useState(alunosList)
    const [loading, setLoading] = useState(true);
    const [deleteConfirmationOpen, setDeleteConfirmationOpen] = useState(false);
    const [selectedNotaId, setSelectedNotaId] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        setAlunos(alunosList);
        setLoading(alunosList === null);
    }, [alunosList]);

    const handleEditClick = (alunoId) => {
        navigate(`/alunos/${alunoId}`)
    };

    const handleDeleteClick = (alunoId) => {
        setSelectedNotaId(alunoId);
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
                        <TableCell>Name</TableCell>
                        <TableCell></TableCell>
                        {turma ? (<TableCell>Remover da Turma</TableCell>) : (<></>) }
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
                        alunos.map((aluno) => (
                            <TableRow key={aluno.id}>
                                <TableCell>{aluno.id}</TableCell>
                                <TableCell>{aluno.name}</TableCell>
                                <TableCell>
                                    <IconButton onClick={() => handleEditClick(aluno.id)} color="primary">
                                        <EditIcon />
                                    </IconButton>
                                    <IconButton onClick={() => handleDeleteClick(aluno.id)} color="error">
                                        <DeleteIcon />
                                    </IconButton>
                                </TableCell>
                                {turma ? (
                                    <TableCell>
                                        <IconButton onClick={() => handleRemove(aluno.id)} color="error">
                                            <RemoveIcon />
                                        </IconButton>
                                    </TableCell>
                                ) : (
                                    <></>
                                ) }
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
                itemType={'Alunos'}
            />
        </>
    )
}