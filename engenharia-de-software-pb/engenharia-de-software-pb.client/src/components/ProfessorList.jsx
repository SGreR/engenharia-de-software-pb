/* eslint-disable react/prop-types */
import { useEffect, useState } from 'react';
import Table from '@mui/joy/Table';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import PreviewIcon from '@mui/icons-material/Preview';
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

export default function ProfessorList({ professoresList }) {
    const [professores, setProfessores] = useState(professoresList)
    const [loading, setLoading] = useState(true);
    const [deleteConfirmationOpen, setDeleteConfirmationOpen] = useState(false);
    const [selectedProfessorId, setSelectedProfessorId] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        setProfessores(professoresList);
        setLoading(professoresList === null);
    }, [professoresList]);

    const handleEditClick = (professorId) => {
        navigate(`/professores/${professorId}`)
    };

    const handleDeleteClick = (professorId) => {
        setSelectedProfessorId(professorId);
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
                        <TableCell>Nome</TableCell>
                        <TableCell></TableCell>
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
                        professores.map((professor) => (
                            <TableRow key={professor.id}>
                                <TableCell>{professor.id}</TableCell>
                                <TableCell>{professor.name}</TableCell>
                                <TableCell>
                                    <IconButton onClick={() => handleEditClick(professor.id)} color="primary">
                                        <PreviewIcon />
                                    </IconButton>
                                    <IconButton onClick={() => handleEditClick(professor.id)} color="primary">
                                        <EditIcon />
                                    </IconButton>
                                    <IconButton onClick={() => handleDeleteClick(professor.id)} color="error">
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
                itemId={selectedProfessorId}
                itemType={'Professores'}
            />
        </>
    )
}