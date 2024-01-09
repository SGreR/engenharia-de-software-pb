// NotasCreatePage.jsx
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import NotasEditDisplay from '../components/NotasEditDisplay';

const NotasCreatePage = () => {
    
    const navigate = useNavigate();
    const [notasData, setNotasData] = useState({
        "alunoId": 0,
        "numeroTeste": 1,
        "reading": {
            "primeiraNota": 0.0,
            "segundaNota": 0.0
        },
        "writing": {
            "primeiraNota": 0.0,
            "segundaNota": 0.0
        },
        "listening": {
            "primeiraNota": 0.0,
            "segundaNota": 0.0
        },
        "grammar": {
            "primeiraNota": 0.0,
            "segundaNota": 0.0
        },
        "speaking": {
            "productionAndFluencyGrade": 0,
            "spokenInteractionGrade": 0,
            "languageRangeGrade": 0,
            "accuracyGrade": 0,
            "l2Use": 0
        },
        "classPerformance": {
            "presenceGrade": 0,
            "homeworkGrade": 0,
            "participationGrade": 0,
            "behaviorGrade": 0
        }
    });

    const handleChange = (newGrades) => {
        setNotasData(newGrades)
    }

    const handleCreateNotas = () => {
        console.log(JSON.stringify(notasData));
        
        fetch('https://localhost:7215/api/Notas', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(notasData)
        })
            .then((response) => {
                if (response.ok) {
                    console.log(response)
                    console.log('Notas adicionadas com sucesso!');
                    navigate('/notas');
                } else {
                    console.error('Erro ao criar notas:', response.statusText);
                }
            })
            .catch((error) => {
                console.error('Erro ao criar notas:', error);
            });
    };

    return (
        <div>
            <h2>Create Notas</h2>
            <form>
                <NotasEditDisplay student={notasData.alunoId} notas={notasData} onChange={handleChange} />
                <div>
                    <button type="button" onClick={handleCreateNotas}>
                        Adicionar Notas
                    </button>
                </div>
            </form>
        </div>
    );

};

export default NotasCreatePage;
