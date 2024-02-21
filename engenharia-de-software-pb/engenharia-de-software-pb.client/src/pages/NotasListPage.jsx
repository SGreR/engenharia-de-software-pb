import { useState, useEffect } from 'react';
import {useNavigate } from 'react-router-dom'
import '../App.css';
import NotasList from '../components/NotasList';
import AddIcon from '@mui/icons-material/Add';
import { IconButton } from '@mui/material';

export default function NotasListPage() {
    const [notas, setNotas] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        fetch("https://localhost:7128/api/Notas")
            .then(response => response.json())
            .then(data => {
                if (data && Array.isArray(data.$values)) {
                    setNotas(data.$values);
                } else {
                    console.error("Invalid data structure received from API:", data);
                }
            })
            .catch(error => console.error(error));
    }, []);

    const handleClick = () => {
        navigate('/notas/create')
    }

    return (
        <div>
            <h1>Notas</h1>
            <IconButton onClick={() => handleClick()} color="primary">
                <AddIcon /> Adicionar Notas
            </IconButton>
            <NotasList allGrades={true} notasList={notas} />
        </div>
    );
}
