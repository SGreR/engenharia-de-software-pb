import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import TurmasEditDisplay from '@components/TurmasEditDisplay';

const TurmaCreatePage = () => {

    const [turmaData, setTurmaData] = useState({
        nome: '',
        ano: 0,
        semestre: 1,
        professorId: 0,
    });
    const navigate = useNavigate();

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

    const handleChange = (newTurma) => {
        setTurmaData(newTurma);
    }

    return (
        <div>
            <h2>Create Turma</h2>
            <form>
                <TurmasEditDisplay turma={turmaData} onChange={handleChange}/>
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