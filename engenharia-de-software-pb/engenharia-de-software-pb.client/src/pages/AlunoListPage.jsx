import React, { useState, useEffect } from 'react';
import Table from '@mui/joy/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import '../App.css'

const AlunoListPage = () => {
    const [alunos, setAlunos] = useState([]);

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

    return (
        <div>
            <h1>Lista de Alunos</h1>
            <Table hoverRow stripe={'odd'} stickyHeader>
                <TableHead>
                    <TableRow>
                        <TableCell>ID</TableCell>
                        <TableCell>Name</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {alunos.map((aluno) => (
                        <TableRow key={aluno.id}>
                            <TableCell>{aluno.id}</TableCell>
                            <TableCell>{aluno.name}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </div>
    );
};

export default AlunoListPage;
