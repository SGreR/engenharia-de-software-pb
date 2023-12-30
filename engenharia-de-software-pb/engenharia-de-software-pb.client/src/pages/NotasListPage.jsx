import React, { useState, useEffect } from 'react';
import '../App.css';
import NotasList from '../components/NotasList';

export default function NotasListPage() {
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
        <div>
            <h1>Notas</h1>
            <NotasList notasList={notas}/>
        </div>
    );
}
