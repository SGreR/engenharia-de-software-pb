import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

const TurmaCreatePage = () => {

    const [turmaData, setTurmaData] = useState({
        nome: '',
        ano: 0,
        semestre: 1,
        professor: null,
        professorId: 0,
    });
    const [professores, setProfessores] = useState([])
    const navigate = useNavigate();

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
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setTurmaData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const handleCreateTurma = () => {
        console.log(JSON.stringify(turmaData))
        fetch('https://localhost:7215/api/Turmas', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(turmaData),
        })
            .then((response) => {
                if (response.ok) {
                    console.log('Turma adicionada com sucesso!');
                    navigate('/turmas');
                } else {
                    console.error('Erro ao adicionar turma:', response.statusText);
                }
            })
            .catch((error) => {
                console.error('Error ao criar turma:', error);
            });
    };

    return (
        <div>
            <h2>Create Turma</h2>
            <form>
                <div>
                    <label>
                        Nome:
                        <input
                            type="text"
                            name="nome"
                            value={turmaData.nome}
                            onChange={handleInputChange}
                        />
                    </label>
                    <label>
                        Ano:
                        <input
                            type="number"
                            name="ano"
                            value={turmaData.ano}
                            onChange={handleInputChange}
                        />
                    </label>
                    <label>
                        Semestre:
                        <select
                            value={turmaData.semestre}
                            name="semestre"
                            onChange={handleInputChange}
                        >
                            <option value={ 0 }>
                                Selecione o Semestre:
                            </option>
                            <option value={ 1 }>
                                Primeiro
                            </option>
                            <option value={ 2 }>
                                Segundo
                            </option>
                        </select>
                    </label>
                    <select
                        value={turmaData.professorId}
                        name = "professorId"
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

                <div>
                    <button type="button" onClick={handleCreateTurma}>
                        Adicionar Turma
                    </button>
                </div>
            </form>
        </div>
    );
}

export default TurmaCreatePage;