/* eslint-disable react/prop-types */
import React from 'react';
import { useState } from 'react';
import { useParams } from 'react-router-dom';

export default function NotasDisplay({ notas }) {
    const [grades, setGrades] = useState(notas);
    const [editing, setEditing] = useState(false);
    const { id } = useParams();

    const toggleEditing = () => {
        setEditing(!editing)
    }

    const handleInputChange = (section, property, value) => {
        setGrades((prevGrades) => ({
            ...prevGrades,
            [section]: {
                ...prevGrades[section],
                [property]: value,
                ['media']: recalculateAverage(section, property, value)
            },
            
        }));
    };

    const postGrades = () => {
        fetch(`https://localhost:7215/api/Notas/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(grades)
        })
            .then((response) => {
                if (response.ok)
                {
                    console.log("Notas atualizadas com sucesso!");
                }
            })
            .catch(error => console.error("Erro ao atualizar informações:", error))
    };

    function recalculateAverage(section, property, value) {
        if (section == 'speaking') {
            return recalculateSpeakingAverage(property, value);
        }
        if (section == 'classPerformance') {
            return recalculateClassPerformanceAverage(property, value)
        }

        var primeiraNota = parseFloat(grades[section]['primeiraNota']);
        var segundaNota = parseFloat(grades[section]['segundaNota']);
        value = parseFloat(value);
        if (property == 'primeiraNota') {
            var nota = (segundaNota + value) / 2;
            return nota;
        }
        nota = (primeiraNota + value) / 2
        return nota;
    }

    function recalculateSpeakingAverage(property, value) {
        var speaking = {...notas.speaking}
        speaking[property] = parseInt(value)

        var sum = speaking['productionAndFluencyGrade'] + speaking['spokenInteractionGrade'] + speaking['languageRangeGrade'] + speaking['accuracyGrade'];
        var notaFinal = sum * 5;
        var multiplier = (5 - speaking.l2Use) * 0.15;
        notaFinal = notaFinal - (notaFinal * multiplier);
        return notaFinal / 10;
    }

    function recalculateClassPerformanceAverage(property, value) {
        var classPerformance = { ...notas.classPerformance }
        classPerformance[property] = parseInt(value);

        var sum = classPerformance['presenceGrade'] + classPerformance['homeworkGrade'] + classPerformance['participationGrade'] + classPerformance['behaviorGrade'];
        var notaFinal = sum / 2;
        return notaFinal;
    }

    return (
        <div className="gradesDisplay" >
            <button onClick={toggleEditing}>Toggle Edit</button>
            <div>
                <div>
                    <h3>Reading</h3>
                    {editing ? (
                        <div>
                            <label>
                                Primeira Nota:
                                <input
                                    type="text"
                                    value={grades.reading.primeiraNota}
                                    onChange={(e) =>
                                        handleInputChange('reading', 'primeiraNota', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Segunda Nota:
                                <input
                                    type="text"
                                    value={grades.reading.segundaNota}
                                    onChange={(e) =>
                                        handleInputChange('reading', 'segundaNota', e.target.value)
                                    }
                                />
                            </label>
                            <p>Media: {grades.reading.media}</p>
                        </div>
                    ) : (
                        <div>
                            <p>Primeira nota: {grades.reading.primeiraNota}</p>
                            <p>Segunda nota: {grades.reading.segundaNota}</p>
                            <p>Media: {grades.reading.media}</p>
                        </div>
                    )}
                </div>
                <div>
                    <h3>Writing</h3>
                    {editing ? (
                        <div>
                            <label>
                                Primeira Nota:
                                <input
                                    type="text"
                                    value={grades.writing.primeiraNota}
                                    onChange={(e) =>
                                        handleInputChange('writing', 'primeiraNota', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Segunda Nota:
                                <input
                                    type="text"
                                    value={grades.writing.segundaNota}
                                    onChange={(e) =>
                                        handleInputChange('writing', 'segundaNota', e.target.value)
                                    }
                                />
                            </label>
                            <p>Media: {grades.writing.media}</p>
                        </div>
                    ) : (
                        <div>
                            <p>Primeira nota: {grades.writing.primeiraNota}</p>
                            <p>Segunda nota: {grades.writing.segundaNota}</p>
                            <p>Media: {grades.writing.media}</p>
                        </div>
                    )}
                </div>
            </div>

            <div>
                <div>
                    <h3>Listening</h3>
                    {editing ? (
                        <div>
                            <label>
                                Primeira Nota:
                                <input
                                    type="text"
                                    value={grades.listening.primeiraNota}
                                    onChange={(e) =>
                                        handleInputChange('listening', 'primeiraNota', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Segunda Nota:
                                <input
                                    type="text"
                                    value={grades.listening.segundaNota}
                                    onChange={(e) =>
                                        handleInputChange('listening', 'segundaNota', e.target.value)
                                    }
                                />
                            </label>
                            <p>Media: {grades.listening.media}</p>
                        </div>
                    ) : (
                        <div>
                            <p>Primeira nota: {grades.listening.primeiraNota}</p>
                            <p>Segunda nota: {grades.listening.segundaNota}</p>
                            <p>Media: {grades.listening.media}</p>
                        </div>
                    )}
                </div>
                <div>
                    <h3>Grammar</h3>
                    {editing ? (
                        <div>
                            <label>
                                Primeira Nota:
                                <input
                                    type="text"
                                    value={grades.grammar.primeiraNota}
                                    onChange={(e) =>
                                        handleInputChange('grammar', 'primeiraNota', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Segunda Nota:
                                <input
                                    type="text"
                                    value={grades.grammar.segundaNota}
                                    onChange={(e) =>
                                        handleInputChange('grammar', 'segundaNota', e.target.value)
                                    }
                                />
                            </label>
                            <p>Media: {grades.grammar.media}</p>
                        </div>
                    ) : (
                        <div>
                            <p>Primeira nota: {grades.grammar.primeiraNota}</p>
                            <p>Segunda nota: {grades.grammar.segundaNota}</p>
                            <p>Media: {grades.grammar.media}</p>
                        </div>
                    )}
                </div>
            </div>

            <div>
                <div>
                    <h3>Speaking</h3>
                    {editing ? (
                        <div>
                            <label>
                                Production and Fluency:
                                <input
                                    type="text"
                                    value={grades.speaking.productionAndFluencyGrade}
                                    onChange={(e) =>
                                        handleInputChange('speaking', 'productionAndFluencyGrade', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Spoken Interaction:
                                <input
                                    type="text"
                                    value={grades.speaking.spokenInteractionGrade}
                                    onChange={(e) =>
                                        handleInputChange('speaking', 'spokenInteractionGrade', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Spoken Interaction:
                                <input
                                    type="text"
                                    value={grades.speaking.languageRangeGrade}
                                    onChange={(e) =>
                                        handleInputChange('speaking', 'languageRangeGrade', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Spoken Interaction:
                                <input
                                    type="text"
                                    value={grades.speaking.accuracyGrade}
                                    onChange={(e) =>
                                        handleInputChange('speaking', 'accuracyGrade', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Spoken Interaction:
                                <input
                                    type="text"
                                    value={grades.speaking.l2Use}
                                    onChange={(e) =>
                                        handleInputChange('speaking', 'l2Use', e.target.value)
                                    }
                                />
                            </label>
                            <p>Media: {grades.speaking.media}</p>
                        </div>
                    ) : (
                        <div>
                            <p>Production and Fluency: {grades.speaking.productionAndFluencyGrade}</p>
                            <p>Spoken Interaction: {grades.speaking.spokenInteractionGrade}</p>
                            <p>Language Range: {grades.speaking.languageRangeGrade}</p>
                            <p>Accuracy: {grades.speaking.accuracyGrade}</p>
                            <p>L2 Use: {grades.speaking.l2Use}</p>
                            <p>Media: {grades.speaking.media}</p>
                        </div>
                    )}
                </div>
                <div>
                    <h3>Class Perfomance</h3>{editing ? (
                        <div>
                            <label>
                                Presence:
                                <input
                                    type="text"
                                    value={grades.classPerformance.presenceGrade}
                                    onChange={(e) =>
                                        handleInputChange('classPerformance', 'presenceGrade', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Homework:
                                <input
                                    type="text"
                                    value={grades.classPerformance.homeworkGrade}
                                    onChange={(e) =>
                                        handleInputChange('classPerformance', 'homeworkGrade', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Participation:
                                <input
                                    type="text"
                                    value={grades.classPerformance.participationGrade}
                                    onChange={(e) =>
                                        handleInputChange('classPerformance', 'participationGrade', e.target.value)
                                    }
                                />
                            </label>
                            <label>
                                Behavior:
                                <input
                                    type="text"
                                    value={grades.classPerformance.behaviorGrade}
                                    onChange={(e) =>
                                        handleInputChange('classPerformance', 'behaviorGrade', e.target.value)
                                    }
                                />
                            </label>
                            <p>Media: {grades.classPerformance.media}</p>
                        </div>
                    ) : (
                        <div>
                            <p>Presence: {grades.classPerformance.presenceGrade}</p>
                            <p>Homework: {grades.classPerformance.homeworkGrade}</p>
                            <p>Participation: {grades.classPerformance.participationGrade}</p>
                            <p>Behavior: {grades.classPerformance.behaviorGrade}</p>
                            <p>Media: {grades.classPerformance.media}</p>
                        </div>
                    )}
                </div>
            </div>
            <button onClick={postGrades}>Save Changes</button>
        </div>
  );
}