/* eslint-disable react/prop-types */
import React from 'react';
import Table from '@mui/joy/Table';
import { TableHead, TableBody, TableRow, TableCell, CircularProgress } from '@mui/material';
import { useEffect, useState } from 'react';

export default function NotasList({ studentName = null, notasList }) {
    const [notas, setNotas] = useState(null)
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        setNotas(notasList);
        setLoading(notas === null);
    }, [notasList]);

  return (
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
                {loading ? (
                    <TableRow>
                        <TableCell colSpan={9} style={{ textAlign: 'center' }}>
                            <CircularProgress />
                            Loading...
                        </TableCell>
                    </TableRow>
                ) : (
                    notas.map((nota) => (
                        <TableRow key={nota.id}>
                            <TableCell>{nota.id}</TableCell>
                            <TableCell>{studentName == null ? nota.aluno.name : studentName}</TableCell>
                            <TableCell>{nota.reading.media}</TableCell>
                            <TableCell>{nota.writing.media}</TableCell>
                            <TableCell>{nota.listening.media}</TableCell>
                            <TableCell>{nota.grammar.media}</TableCell>
                            <TableCell>{nota.speaking.media}</TableCell>
                            <TableCell>{nota.classPerformance.media}</TableCell>
                            <TableCell>{nota.mediaFinal}%</TableCell>
                        </TableRow>
                    ))
                )}
            </TableBody>
        </Table>
    );
}