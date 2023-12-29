import React, { useState, useEffect } from 'react';
import Table from '@mui/joy/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import '../App.css'

const NotasListPage = () => {
    const [notas, setNotas] = useState([]);

    useEffect(() => {
        fetch("https://localhost:7215/api/Notas")
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

    return (
        <div className="listContainer">
            <h1>Notas</h1>
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
                    {notas.map((nota) => (
                        <TableRow key={nota.id}>
                            <TableCell>{nota.id}</TableCell>
                            <TableCell>{nota.aluno.name}</TableCell>
                            <TableCell>{nota.reading.media}</TableCell>
                            <TableCell>{nota.writing.media}</TableCell>
                            <TableCell>{nota.listening.media}</TableCell>
                            <TableCell>{nota.grammar.media}</TableCell>
                            <TableCell>{nota.speaking.media}</TableCell>
                            <TableCell>{nota.classPerformance.media}</TableCell>
                            <TableCell>{nota.mediaFinal}%</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </div>
    );
};

export default NotasListPage;
