import React from 'react';
import { Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions, Button } from '@mui/material';

const DeleteConfirmationModal = ({ open, onCancel, onConfirm, itemId }) => {

    const handleDelete = () => {
        fetch(`https://localhost:7215/api/Alunos/${itemId}`, {
            method: 'DELETE',
        })
            .then((response) => {
                if (response.ok) {
                    console.log("Notas deletadas com sucesso!");
                }
            })
            .catch(error => console.error("Erro ao deletar informações:", error))
        onConfirm(itemId);
    };

    return (
        <Dialog open={open} onClose={onCancel} aria-labelledby="delete-confirmation-dialog">
            <DialogTitle>Delete Confirmation</DialogTitle>
            <DialogContent>
                <DialogContentText>
                    Are you sure you want to delete this record?
                </DialogContentText>
            </DialogContent>
            <DialogActions>
                <Button onClick={onCancel} color="primary">
                    Cancel
                </Button>
                <Button onClick={handleDelete} color="error">
                    Delete
                </Button>
            </DialogActions>
        </Dialog>
    );
};

export default DeleteConfirmationModal;
