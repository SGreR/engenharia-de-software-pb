import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom'
import '@/App.css';
import AddIcon from '@mui/icons-material/Add';
import { IconButton } from '@mui/material';
import TurmasList from '@components/TurmasList';

export default function TurmasListPage() {
    const [turmas, setTurmas] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        fetch("https://localhost:7215/api/Turmas")
            .then(response => response.json())
            .then(data => {
                if (data && Array.isArray(data.$values)) {
                    setTurmas(data.$values);
                } else {
                    console.error("Invalid data structure received from API:", data);
                }
            })
            .catch(error => console.error(error));
    }, []);

    const handleClick = () => {
        navigate('/turmas/create')
    }

    return (
        <div>
            <h1>Notas</h1>
            <IconButton onClick={() => handleClick()} color="primary">
                <AddIcon /> Adicionar Turmas
            </IconButton>
            <TurmasList turmasList={turmas} />
        </div>
    );
}
