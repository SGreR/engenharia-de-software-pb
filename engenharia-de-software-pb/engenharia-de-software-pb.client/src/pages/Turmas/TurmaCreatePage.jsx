import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const TurmaCreatePage = () => {

    const [turmaData, setTurmaData] = useState({
        nome: '',
    });

    const navigate = useNavigate();

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setTurmaData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const handleCreateTurma = () => {
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