// NotasCreatePage.jsx
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import NotasEditDisplay from '../components/NotasEditDisplay';

const NotasCreatePage = () => {
    
    const navigate = useNavigate();
    const [notasData, setNotasData] = useState({
        "id": 0,
        "alunoId": 0,
        "reading": {
            "primeiraNota": "",
            "segundaNota": ""
        },
        "writing": {
            "primeiraNota": "",
            "segundaNota": ""
        },
        "listening": {
            "primeiraNota": "",
            "segundaNota": ""
        },
        "grammar": {
            "primeiraNota": "",
            "segundaNota": ""
        },
        "speaking": {
            "productionAndFluencyGrade": "",
            "spokenInteractionGrade": "",
            "languageRangeGrade": "",
            "accuracyGrade": "",
            "l2Use": ""
        },
        "classPerformance": {
            "presenceGrade": "",
            "homeworkGrade": "",
            "participationGrade": "",
            "behaviorGrade": ""
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
            body: JSON.stringify({"id": 0,"alunoId": notasData.alunoId})
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
