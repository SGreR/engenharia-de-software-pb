import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import TurmasList from '@components/TurmasList';

function ProfessorDetailPage() {
    const [professor, setProfessor] = useState(null)
    const [turmas, setTurmas] = useState([])
    const [editing, setEditing] = useState(false);
    const { id } = useParams();

    useEffect(() => {
        fetch(`https://localhost:7006/api/Professores/${id}`)
            .then(response => response.json())
            .then(data => setProfessor(data))
            .catch(error => console.error(error));
    }, [id]);

    useEffect(() => {
        fetch(`https://localhost:7215/api/Turmas/GetByRelatedId/professores/${id}`)
            .then(response => response.json())
            .then(data => {
                if (data && Array.isArray(data.$values)) {
                    setTurmas(data.$values);
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
        setProfessor((prevData) => ({
            ...prevData,
            ['name']: value
        }))
    }

    const putProfessor = () => {
        fetch(`https://localhost:7006/api/Professores/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(professor)
        })
            .then((response) => {
                if (response.ok) {
                    console.log("Informações do professor atualizadas com sucesso!");
                    window.location.reload();
                }
            })
            .catch(error => console.error("Erro ao atualizar informações:", error))
    };

    return (
        <div>

            {professor === null ?
                (
                    <div>
                        <h2>Professor Detail Page</h2>
                        <h2>Loading....</h2>
                    </div>
                )
                : (
                    <div>
                        <h2>{professor.name}</h2>
                        <button onClick={toggleEditing}>Toggle Edit</button>
                        {editing ? (
                            <div>
                                <label>
                                    Nome:
                                    <input
                                        type="text"
                                        value={professor.name}
                                        onChange={(e) =>
                                            handleInputChange(e.target.value)
                                        }
                                    />
                                </label>
                            </div>
                        ) : (
                            <div>
                                <p>Nome: {professor.name}</p>
                            </div>
                        )}
                        {editing ? (
                            <button onClick={putProfessor}>Save Changes</button>
                        ) : (
                            <>
                            </>
                        )}
                        <TurmasList turmasList= { turmas } />
                    </div>
                )}
        </div>
    );
}

export default ProfessorDetailPage;
