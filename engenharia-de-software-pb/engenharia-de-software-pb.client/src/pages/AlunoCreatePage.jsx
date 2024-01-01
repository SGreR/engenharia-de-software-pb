// AlunoCreatePage.jsx
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const AlunoCreatePage = () => {
    const [alunoData, setAlunoData] = useState({
        // Initialize the state with any default values you need
        name: '',
        // Add other fields as needed
    });

    const navigate = useNavigate();

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setAlunoData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const handleCreateAluno = () => {
        // Perform the API request to create a new aluno
        fetch('https://localhost:7215/api/Alunos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(alunoData),
        })
            .then((response) => {
                if (response.ok) {
                    console.log('Aluno adicionado com sucesso!');
                    navigate('/alunos');
                } else {
                    console.error('Erro ao adicionar aluno:', response.statusText);
                }
            })
            .catch((error) => {
                console.error('Error ao criar aluno:', error);
            });
    };

    return (
        <div>
            <h2>Create Aluno</h2>
            <form>
                <div>
                    <label>
                        Name:
                        <input
                            type="text"
                            name="name"
                            value={alunoData.name}
                            onChange={handleInputChange}
                        />
                    </label>
                </div>

                <div>
                    <button type="button" onClick={handleCreateAluno}>
                        Adicionar Aluno
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AlunoCreatePage;
