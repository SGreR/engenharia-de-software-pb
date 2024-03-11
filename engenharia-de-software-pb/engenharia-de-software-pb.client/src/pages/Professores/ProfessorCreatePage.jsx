import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const ProfessorCreatePage = () => {
    const [professorData, setProfessorData] = useState({
        name: '',
    });

    const navigate = useNavigate();

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setProfessorData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const handleCreateProfessor = () => {
        fetch('https://localhost:7006/api/Professores', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(professorData),
        })
            .then((response) => {
                if (response.ok) {
                    console.log('Professor adicionado com sucesso!');
                    navigate('/professores');
                } else {
                    console.error('Erro ao adicionar professor:', response.statusText);
                }
            })
            .catch((error) => {
                console.error('Error ao criar professor:', error);
            });
    };

    return (
        <div>
            <h2>Create Professor</h2>
            <form>
                <div>
                    <label>
                        Name:
                        <input
                            type="text"
                            name="name"
                            value={professorData.name}
                            onChange={handleInputChange}
                        />
                    </label>
                </div>

                <div>
                    <button type="button" onClick={handleCreateProfessor}>
                        Adicionar Professor
                    </button>
                </div>
            </form>
        </div>
    );
};

export default ProfessorCreatePage;
