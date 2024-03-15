import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import NotasDisplay from '@components/NotasDisplay';
import NotasEditDisplay from '@components/NotasEditDisplay';

export default function NotasDetailPage() {
    const [notas, setNotas] = useState(null);
    const [editing, setEditing] = useState(false);
    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        fetch(`https://localhost:7128/api/Notas/${id}`)
            .then(response => response.json())
            .then(data => setNotas(data))
            .catch(error => console.error(error));
    }, [id]);

    const putGrades = () => {
        fetch(`https://localhost:7128/api/Notas/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(notas)
        })
            .then((response) => {
                if (response.ok) {
                    console.log("Notas atualizadas com sucesso!");
                    navigate(`/notas`)
                }
            })
            .catch(error => console.error("Erro ao atualizar informações:", error))
    };

    const toggleEditing = () => {
        setEditing(!editing);
    }

    const handleChange = (newGrades) => {
        setNotas(newGrades);
    }

    return (
        <div>
            {notas === null ? (
                <div>
                    <h2>Loading....</h2>
                </div>
            ) : (
                <div>
                    <p>Id: {id}</p>
                    <p>Aluno: {notas.aluno.name}</p>
                    <p>Teste: {notas.numeroTeste}</p>
                    {editing ? <button onClick={toggleEditing}>Cancelar</button> : <button onClick={toggleEditing}>Editar</button>}
                        {editing ? (
                            <>
                                <NotasEditDisplay onChange={handleChange} id={id} notas={notas} />
                                <button onClick={putGrades}>Salvar</button>
                            </>
                            
                        ) : (
                            <NotasDisplay id={id} notas={notas} />
                        )}
                </div>
            )}
        </div>
    );
}
