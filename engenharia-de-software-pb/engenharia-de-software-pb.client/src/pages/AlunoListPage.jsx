import { useState, useEffect } from 'react';
import '../App.css'
import AlunoList from '../components/AlunoList';
import AddIcon from '@mui/icons-material/Add';
import { IconButton } from '@mui/material';
import { useNavigate } from 'react-router-dom'

const AlunoListPage = () => {
    const [alunos, setAlunos] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        fetch("https://localhost:7215/api/Alunos")
            .then(response => response.json())
            .then(data => {
                if (data && Array.isArray(data.$values)) {
                    setAlunos(data.$values);
                } else {
                    console.error("Invalid data structure received from API:", data);
                }
            })
            .catch(error => console.error(error));
    }, []);

    const handleClick = () => {
        navigate('/alunos/create')
    }

    return (
        <div>
            <h1>Lista de Alunos</h1>
            <IconButton onClick={() => handleClick()} color="primary">
                <AddIcon /> Adicionar Aluno
            </IconButton>
            <AlunoList alunosList={ alunos } />
        </div>
    );
};

export default AlunoListPage;
