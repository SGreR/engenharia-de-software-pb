import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import NotasList from '@components/NotasList';
import AlunoList from '@components/AlunoList';

const TurmasDetailPage = () => {

    const [turma, setTurma] = useState(
        {
            $id: 0,
            id: 0,
            nome: "",
            ano: 0,
            semestre: 1,
            professorId: 0,
            professor: null,
            alunos: []
        })
    const [alunos, setAlunos] = useState(null)
    const [professores, setProfessores] = useState([])
    const [alunoSelecionado, setAlunoSelecionado] = useState([])
    const [notas, setNotas] = useState([])
    const [editing, setEditing] = useState(false);
    const [adding, setAdding] = useState(false);
    const { id } = useParams();

    useEffect(() => {
        fetch(`https://localhost:7215/api/Turmas/${id}`)
            .then(response => response.json())
            .then(data => {
                var novaTurma =
                {
                    $id: data.$id,
                    id: data.id,
                    nome: data.nome,
                    ano: data.ano,
                    semestre: data.semestre,
                    professorId: data.professorId,
                    professor: data.professor,
                    alunos: data.alunos.$values.map(aluno => {
                        const { $id, ...rest } = aluno;
                        return rest;
                    })
                }
                console.log(novaTurma)
                setTurma(novaTurma)
            })
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

    useEffect(() => {
        fetch("https://localhost:7245/api/Alunos")
            .then(response => response.json())
            .then(data => {
                if (data && data.$values) {
                    const alunosWithoutId = data.$values.map(aluno => {
                        const { $id, ...rest } = aluno;
                        return rest;
                    })
                    setAlunos(alunosWithoutId);
                } else {
                    console.error("Invalid data structure received from API:", data);
                }
            })
            .catch(error => console.log(error));
    }, [id])

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
    }, [id]);

    const toggleEditing = () => {
        setEditing(!editing)
    }

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setTurma((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

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
                else {
                    // Log the status code and status text
                    console.log("Response Status:", response.status);
                    console.log("Response Status Text:", response.statusText);


                    // If the response contains JSON data, log that as well
                    response.json().then(data => {
                        console.log("Response Data:", data.errors)
                        console.log("Turma Errors:", data.errors.turma);
                        console.log("Alunos Errors:", data.errors['$.alunos.$values']);
                    }
                    );
                }
            })
            .catch(error => console.log("Erro ao atualizar informações:", error))
    };
    

    const toggleAdicionarAluno = () => {
        setAdding(!adding);
    }

    const handleStudentChange = (value) => {
        setAlunoSelecionado(value)
    }

    const addStudent = () => {
        if (alunoSelecionado) {
            const selectedAluno = alunos.find(aluno => aluno.id === parseInt(alunoSelecionado));
            if (selectedAluno) {
                selectedAluno.turmas.$values = [{$ref: turma.$id}];
                const updatedAlunos = [...turma.alunos, selectedAluno];
                setTurma(prevTurma => ({ ...prevTurma, alunos: updatedAlunos }));
            }
        }
    }

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
                        <h2>{turma.nome}</h2>
                        <button onClick={toggleEditing}>Toggle Edit</button>
                        {editing ? (
                            <div>
                                <label>
                                    Nome:
                                    <input
                                        type="text"
                                        name="nome"
                                        value={turma.nome}
                                        onChange={handleInputChange}
                                    />
                                </label>
                                <label>
                                    Ano:
                                    <input
                                        type="number"
                                        name="ano"
                                        value={turma.ano}
                                        onChange={handleInputChange}
                                    />
                                </label>
                                <select
                                    value={turma.semestre}
                                    name="semestre"
                                    onChange={handleInputChange}
                                >
                                    <option value={0}>
                                        Selecione o Semestre:
                                    </option>
                                    <option value={1}>
                                        Primeiro
                                    </option>
                                    <option value={2}>
                                        Segundo
                                    </option>
                                </select>
                                <select
                                    value={turma.professorId}
                                    name="professorId"
                                    onChange={handleInputChange}
                                >
                                    <option value="">
                                        Escolha um professor
                                    </option>
                                    {professores.map((professor) => (
                                        <option key={professor.id} value={professor.id}>
                                            {professor.name}
                                        </option>
                                    ))}
                                </select>
                            </div>
                        ) : (
                            <div>
                                <p>Turma: {turma.nome}</p>
                                <p>Semestre: {turma.ano}-{turma.semestre}</p>
                                <p>Professor: {turma.professor == null ? "" : turma.professor.name}</p>
                            </div>
                        )}
                        {editing ? (
                            <button onClick={putTurma}>Save Changes</button>
                        ) : (
                            <>
                            </>
                        )}
                        <h2>Alunos</h2>
                        { alunos == null ? <></> : <button onClick={toggleAdicionarAluno}>Adicionar aluno</button>}
                        {adding ?
                            (
                                <div>
                                    <label>
                                        Selecione o aluno:
                                        <select
                                            value={alunoSelecionado}
                                            onChange={(e) => handleStudentChange(e.target.value)}
                                        >
                                            <option value="">
                                                Escolha um aluno
                                            </option>
                                            {alunos.map((aluno) => {
                                                const isStudentInTurma = turma.alunos.some(turmaAluno => turmaAluno.id === aluno.id);
                                                return <option
                                                    key={aluno.id}
                                                    value={aluno.id}
                                                    disabled={isStudentInTurma}
                                                    style={{ color: isStudentInTurma ? 'gray' : 'black' }}
                                                    >
                                                    {aluno.name}
                                                </option>
                                            })}
                                        </select>
                                    </label>
                                    <button onClick={addStudent}>+</button>
                                    <button onClick={putTurma}>Save Changes</button>
                                </div>
                            ) : (
                                <></>
                            )}
                        <AlunoList alunosList={turma.alunos} />
                        <hr></hr>
                        <h2>Notas</h2>
                        <NotasList notasList={notas} />
                        
                    </div>
                )}
        </div>
    );
}

export default TurmasDetailPage;