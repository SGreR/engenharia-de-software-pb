import { useState, useEffect } from 'react';
import '@/App.css'
import ProfessorList from '@components/ProfessorList';
import AddIcon from '@mui/icons-material/Add';
import { IconButton } from '@mui/material';
import { useNavigate } from 'react-router-dom'

const ProfessorListPage = () => {
    const [professores, setProfessores] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        fetch("https://localhost:7006/api/Professores")
            .then(response => response.json())
            .then(data => {
                if (data && Array.isArray(data.$values)) {
                    setProfessores(data.$values);
                } else {
                    console.error("Invalid data structure received from API:", data);
                }
            })
            .catch(error => console.error(error));
    }, []);

    const handleClick = () => {
        navigate('/professores/create')
    }

    return (
        <div>
            <h1>Lista de Professores</h1>
            <IconButton onClick={() => handleClick()} color="primary">
                <AddIcon /> Adicionar Professor
            </IconButton>
            <ProfessorList professoresList={professores} />
        </div>
    );
};

export default ProfessorListPage;
