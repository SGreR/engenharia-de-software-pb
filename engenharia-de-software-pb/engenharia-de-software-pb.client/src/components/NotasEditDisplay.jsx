import { useEffect, useState } from 'react';

export default function NotasEditDisplay({ notas, onChange }) {
    const [students, setStudents] = useState([]);
    const [turmas, setTurmas] = useState([])
    const [grades, setGrades] = useState(notas);

    useEffect(() => {
        onChange(grades)
    }, [grades])

    useEffect(() => {
        fetch('https://localhost:7245/api/Alunos')
            .then((response) => response.json())
            .then((data) => setStudents(data['$values']))
            .catch((error) => console.error('Erro coletando alunos:', error));
    }, []);

    useEffect(() => {
        fetch("https://localhost:7215/api/Turmas")
            .then(response => response.json())
            .then(data => {
                if (data && Array.isArray(data.$values)) {
                    setTurmas(data.$values);
                } else {
                    console.error("Invalid data structure received from API:", data);
                }
            })
            .catch(error => console.error(error));
    }, []);

    const handleSelectChange = (e) => {
        const { name, value } = e.target;
        const parsedValue = parseInt(value, 10)
        setGrades((prevData) => ({
            ...prevData,
            [name]: parsedValue,
        }));
    };

    const handleInputChange = (section, property, value) => {
        const rawValue = value.replace(',', '.');
        const floatValue = parseFloat(rawValue)

        if (section === 'speaking' || section === 'classPerformance') {
            if ((!Number.isInteger(floatValue) && rawValue != "") || floatValue < 0 || floatValue > 5) {
                console.warn('Nota inválida. A nota deve ser um número inteiro de 0 a 5.');
                return;
            }
        } else {
            if ((isNaN(floatValue) && rawValue != "") || floatValue < 0 || floatValue > 10) {
                console.warn('Nota inválida. A nota deve ser um número de 0.0 a 10.0.');
                return;
            }
        }

        setGrades((prevData) => ({
            ...prevData,
            [section]: {
                ...prevData[section],
                [property]: rawValue,
                media: recalculateAverage(section, property, floatValue),
            },
        }));
    };


    function recalculateAverage(section, property, value) {

        if (section == 'speaking') {
            return recalculateSpeakingAverage(property, value);
        }
        if (section == 'classPerformance') {
            return recalculateClassPerformanceAverage(property, value)
        }
        return recalculateSimpleAverage(section, property, value)

    }

    function recalculateSimpleAverage( section, property, value){

        var primeiraNota = parseFloat(grades[section].primeiraNota);
        var segundaNota = parseFloat(grades[section].segundaNota);
        if (property == 'primeiraNota') {
            var nota = (segundaNota + value) / 2;
            return nota;
        }
        nota = (primeiraNota + value) / 2
        return nota.toFixed(1);
    }

    function recalculateSpeakingAverage(property, value) {
        var speaking = { ...grades.speaking }
        speaking[property] = parseInt(value)

        var sum = parseInt(speaking['productionAndFluencyGrade']) + parseInt(speaking['spokenInteractionGrade']) + parseInt(speaking['languageRangeGrade']) + parseInt(speaking['accuracyGrade']);
        var notaFinal = sum * 5;
        var multiplier = (5 - speaking.l2Use) * 0.15;
        notaFinal = notaFinal - (notaFinal * multiplier);
        return (notaFinal / 10).toFixed(1);
    }

    function recalculateClassPerformanceAverage(property, value) {
        var classPerformance = { ...grades.classPerformance }
        classPerformance[property] = parseInt(value);

        var sum = parseInt(classPerformance['presenceGrade']) + parseInt(classPerformance['homeworkGrade']) + parseInt(classPerformance['participationGrade']) + parseInt(classPerformance['behaviorGrade']);
        var notaFinal = sum / 2;
        return notaFinal.toFixed(1);
    }

    return (
        <div className="gradesDisplay">
            <div>
                <label>
                    Selecione o aluno:
                    <select
                        value={grades.alunoId}
                        name = "alunoId"
                        onChange={handleSelectChange}
                    >
                        <option value="">
                            Escolha um aluno
                        </option>
                        {students.map((student) => (
                            <option key={student.id} value={student.id}>
                                {student.name}
                            </option>
                        ))}
                    </select>
                </label>
                <label>
                    Selecione a turma:
                    <select
                        value={grades.turmaId}
                        name = "turmaId"
                        onChange={handleSelectChange}
                    >
                        <option value="">
                            Escolha uma turma
                        </option>
                        {turmas.map((turma) => (
                            <option key={turma.id} value={turma.id}>
                                {turma.nome}
                            </option>
                        ))}
                    </select>
                </label>
                <label>
                    Selecione o teste:
                    <select
                        value={grades.numeroTeste}
                        name = "numeroTeste"
                        onChange={handleSelectChange}
                    >
                        <option value={1}>
                            Primeiro
                        </option>
                        <option value={2}>
                            Segundo
                        </option>
                        
                    </select>
                </label>
            </div>
            <div>
                <div>
                    <h3>Reading</h3>
                    <div className="skills">
                        <label>
                            Primeira Nota:
                        </label>
                        <input
                            type="text"
                            value={grades.reading.primeiraNota}
                            onChange={(e) =>
                                handleInputChange('reading', 'primeiraNota', e.target.value)
                            }
                        />
                        <label>
                            Segunda Nota:
                        </label>
                        <input
                            type="text"
                            value={grades.reading.segundaNota}
                            onChange={(e) =>
                                handleInputChange('reading', 'segundaNota', e.target.value)
                            }
                        />
                        <h3>Media: {grades.reading.media}</h3>
                    </div>
                </div>
                <div>
                    <h3>Writing</h3>
                    <div className="skills">
                        <label>
                            Primeira Nota:
                        </label>
                        <input
                            type="text"
                            value={grades.writing.primeiraNota}
                            onChange={(e) =>
                                handleInputChange('writing', 'primeiraNota', e.target.value)
                            }
                        />
                        <label>
                            Segunda Nota:
                        </label>
                        <input
                            type="text"
                            value={grades.writing.segundaNota}
                            onChange={(e) =>
                                handleInputChange('writing', 'segundaNota', e.target.value)
                            }
                        />
                        <h3>Media: {grades.writing.media}</h3>
                    </div>
                </div>
            </div>
            <div>
                <div>
                    <h3>Listening</h3>
                    <div className="skills">
                        <label>
                            Primeira Nota:
                            
                        </label>
                        <input
                            type="text"
                            value={grades.listening.primeiraNota}
                            onChange={(e) =>
                                handleInputChange('listening', 'primeiraNota', e.target.value)
                            }
                        />
                        <label>
                            Segunda Nota:
                            
                        </label>
                        <input
                            type="text"
                            value={grades.listening.segundaNota}
                            onChange={(e) =>
                                handleInputChange('listening', 'segundaNota', e.target.value)
                            }
                        />
                        <h3>Media: {grades.listening.media}</h3>
                    </div>
                </div>
                <div>
                    <h3>Grammar</h3>
                    <div className="skills">
                        <label>
                            Primeira Nota:
                            
                        </label>
                        <input
                            type="text"
                            value={grades.grammar.primeiraNota}
                            onChange={(e) =>
                                handleInputChange('grammar', 'primeiraNota', e.target.value)
                            }
                        />

                        <label>
                            Segunda Nota:
                            
                        </label>
                        <input
                            type="text"
                            value={grades.grammar.segundaNota}
                            onChange={(e) =>
                                handleInputChange('grammar', 'segundaNota', e.target.value)
                            }
                        />
                        <h3>Media: {grades.grammar.media}</h3>
                    </div>
                </div>
            </div>
            <div>
                <div>
                    <h3>Speaking</h3>
                    <div className="skills">
                        <label>
                            Production and Fluency:
                        </label>
                        <select
                            value={grades.speaking.productionAndFluencyGrade}
                            onChange={(e) =>
                                handleInputChange('speaking', 'productionAndFluencyGrade', e.target.value)
                            }
                        >
                            {[0, 1, 2, 3, 4, 5].map((option) => (
                                <option key={option} value={option}>
                                    {option}
                                </option>
                            ))}
                        </select>

                        <label>
                            Spoken Interaction:
                        </label>
                        <select
                            value={grades.speaking.spokenInteractionGrade}
                            onChange={(e) =>
                                handleInputChange('speaking', 'spokenInteractionGrade', e.target.value)
                            }
                        >
                            {[0, 1, 2, 3, 4, 5].map((option) => (
                                <option key={option} value={option}>
                                    {option}
                                </option>
                            ))}
                        </select>

                        <label>
                            Language Range:
                        </label>
                        <select
                            value={grades.speaking.languageRangeGrade}
                            onChange={(e) =>
                                handleInputChange('speaking', 'languageRangeGrade', e.target.value)
                            }
                        >
                            {[0, 1, 2, 3, 4, 5].map((option) => (
                                <option key={option} value={option}>
                                    {option}
                                </option>
                            ))}
                        </select>

                        <label>
                            Accuracy:
                        </label>
                        <select
                            value={grades.speaking.accuracyGrade}
                            onChange={(e) =>
                                handleInputChange('speaking', 'accuracyGrade', e.target.value)
                            }
                        >
                            {[0, 1, 2, 3, 4, 5].map((option) => (
                                <option key={option} value={option}>
                                    {option}
                                </option>
                            ))}
                        </select>

                        <label>
                            L2 Use:
                        </label>
                        <select
                            value={grades.speaking.l2Use}
                            onChange={(e) =>
                                handleInputChange('speaking', 'l2Use', e.target.value)
                            }
                        >
                            {[0, 1, 2, 3, 4, 5].map((option) => (
                                <option key={option} value={option}>
                                    {option}
                                </option>
                            ))}
                        </select>
                        <h3>Media: {grades.speaking.media}</h3>
                    </div>
                </div>
                <div>
                    <h3>Class Perfomance</h3>
                    <div className="skills">
                        <label>
                            Presence:
                        </label>
                        <select
                            value={grades.classPerformance.presenceGrade}
                            onChange={(e) =>
                                handleInputChange('classPerformance', 'presenceGrade', e.target.value)
                            }
                        >
                            {[0, 1, 2, 3, 4, 5].map((option) => (
                                <option key={option} value={option}>
                                    {option}
                                </option>
                            ))}
                        </select>

                        <label>
                            Homework:
                        </label>
                        <select
                            value={grades.classPerformance.homeworkGrade}
                            onChange={(e) =>
                                handleInputChange('classPerformance', 'homeworkGrade', e.target.value)
                            }
                        >
                            {[0, 1, 2, 3, 4, 5].map((option) => (
                                <option key={option} value={option}>
                                    {option}
                                </option>
                            ))}
                        </select>

                        <label>
                            Participation:
                        </label>
                        <select
                            value={grades.classPerformance.participationGrade}
                            onChange={(e) =>
                                handleInputChange('classPerformance', 'participationGrade', e.target.value)
                            }
                        >
                            {[0, 1, 2, 3, 4, 5].map((option) => (
                                <option key={option} value={option}>
                                    {option}
                                </option>
                            ))}
                        </select>

                        <label>
                            Behavior:
                        </label>
                        <select
                            value={grades.classPerformance.behaviorGrade}
                            onChange={(e) =>
                                handleInputChange('classPerformance', 'behaviorGrade', e.target.value)
                            }
                        >
                            {[0, 1, 2, 3, 4, 5].map((option) => (
                                <option key={option} value={option}>
                                    {option}
                                </option>
                            ))}
                        </select>
                        <h3>Media: {grades.classPerformance.media}</h3>
                    </div>
                </div>
            </div>
        </div>
    )
}