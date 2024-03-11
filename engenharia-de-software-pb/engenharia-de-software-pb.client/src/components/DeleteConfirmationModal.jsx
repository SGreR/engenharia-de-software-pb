import React from 'react';
import { Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions, Button } from '@mui/material';

const DeleteConfirmationModal = ({ open, onCancel, onConfirm, itemType, itemId }) => {

    const handleDelete = () => {

        var link = "";
        switch (itemType) {
            case "Notas":
                link = "https://localhost:7128/api";
                break;
            case "Alunos":
                link = "https://localhost:7245/api";
                break;
            case "Turmas":
                link = "https://localhost:7215/api";
                break;
            case "Professores":
                link = "https://localhost:7006/api";
                break;
            default:
                link = "";
                break;
        }


        fetch(`${link}/${itemType}/${itemId}`, {
            method: 'DELETE',
        })
            .then((response) => {
                if (response.ok) {
                    console.log("Item deletado com sucesso!");
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
                    Tem certeza que deseja deletar esse item?
                </DialogContentText>
            </DialogContent>
            <DialogActions>
                <Button onClick={onCancel} color="primary">
                    Cancelar
                </Button>
                <Button onClick={handleDelete} color="error">
                    Deletar
                </Button>
            </DialogActions>
        </Dialog>
    );
};

export default DeleteConfirmationModal;
