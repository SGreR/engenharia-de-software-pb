import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import NotasList from '../components/NotasList';

function AlunoDetailPage() {
    const [aluno, setAluno] = useState(null)
    const [editing, setEditing] = useState(false);
    const { id } = useParams();

    useEffect(() => {
        fetch(`https://localhost:7215/api/Alunos/${id}`)
            .then(response => response.json())
            .then(data => setAluno(data))
            .catch(error => console.error(error));
    }, [id]);

    const toggleEditing = () => {
        setEditing(!editing)
    }

    const handleInputChange = (value) => {
        setAluno((prevData) => ({
            ...prevData,
            ['name']: value
        }))
    }

    const putStudent = () => {
        fetch(`https://localhost:7215/api/Alunos/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(aluno)
        })
            .then((response) => {
                if (response.ok) {
                    console.log("Informações do aluno atualizadas com sucesso!");
                    window.location.reload();
                }
            })
            .catch(error => console.error("Erro ao atualizar informações:", error))
    };

    return (
        <div>
            
            {aluno === null ?
                (
                <div>
                    <h2>Aluno Detail Page</h2>
                    <h2>Loading....</h2>
                </div>
                )
                : (
                <div>
                    <h2>{aluno.name}</h2>
                    <button onClick={toggleEditing}>Toggle Edit</button>
                    {editing ? (
                        <div>
                            <label>
                                Nome:
                                <input
                                    type="text"
                                    value={aluno.name}
                                    onChange={(e) =>
                                        handleInputChange(e.target.value)
                                    }
                                />
                            </label>
                        </div>
                    ) : (
                        <div>
                                <p>Nome: {aluno.name}</p>
                        </div>
                    )}
                    <button onClick={putStudent}>Save Changes</button>
                    <NotasList studentName={ aluno.name } notasList={ aluno.notas.$values }/>
                </div>
            )}
        </div>
    );
}

export default AlunoDetailPage;
