import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import NotasList from '@components/NotasList';
import AlunoList from '@components/AlunoList';

const TurmasDetailPage = () => {

    const [turma, setTurma] = useState(null)
    const [notas, setNotas] = useState([])
    const [editing, setEditing] = useState(false);
    const { id } = useParams();

    useEffect(() => {
        fetch(`https://localhost:7215/api/Turmas/${id}`)
            .then(response => response.json())
            .then(data => setTurma(data))
            .catch(error => console.error(error));
    }, [id]);

    useEffect(() => {
        fetch(`https://localhost:7128/api/Notas/GetByRelatedId/turma/${id}`)
            .then(response => response.json())
            .then(data => {
                if (data && Array.isArray(data.$values)) {
                    setNotas(data.$values);
                } else {
                    console.error("Invalid data structure received from API:", data);
                }
            })
            .catch(error => console.error(error));
    }, [id])

    const toggleEditing = () => {
        setEditing(!editing)
    }

    const handleInputChange = (value) => {
        setTurma((prevData) => ({
            ...prevData,
            ['nome']: value
        }))
    }

    const putTurma = () => {
        fetch(`https://localhost:7215/api/Turmas/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(turma)
        })
            .then((response) => {
                if (response.ok) {
                    console.log("Informações da turma atualizadas com sucesso!");
                    window.location.reload();
                }
            })
            .catch(error => console.error("Erro ao atualizar informações:", error))
    };

    return (
        <div>

            {turma === null ?
                (
                    <div>
                        <h2>Turma Detail Page</h2>
                        <h2>Loading....</h2>
                    </div>
                )
                : (
                    <div>
                        <h2>{turma.name}</h2>
                        <button onClick={toggleEditing}>Toggle Edit</button>
                        {editing ? (
                            <div>
                                <label>
                                    Nome:
                                    <input
                                        type="text"
                                        value={turma.nome}
                                        onChange={(e) =>
                                            handleInputChange(e.target.value)
                                        }
                                    />
                                </label>
                            </div>
                        ) : (
                            <div>
                                <p>Nome: {turma.nome}</p>
                            </div>
                        )}
                        {editing ? (
                            <button onClick={putTurma}>Save Changes</button>
                        ) : (
                            <>
                            </>
                        )}
                        <h2>Alunos</h2>
                        <AlunoList alunosList={turma.alunos.$values} />
                        <hr></hr>
                        <h2>Notas</h2>
                        <NotasList notasList={notas} />
                        
                    </div>
                )}
        </div>
    );
}

export default TurmasDetailPage;