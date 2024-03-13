import { useEffect, useState } from 'react';

export default function TurmasEditDisplay({ turma, onChange }) {

    const [group, setGroup] = useState(turma);
    const [professores, setProfessores] = useState([]);

    useEffect(() => {
        onChange(group)
    }, [group])

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
        const parsedValue = parseInt(value, 10);
        setGroup((prevData) => ({
            ...prevData,
            [name]: name == 'semestre' ? parsedValue : value,
        }));
    };

    return (
            <div>
                <label>
                    Nome:
                    <input
                        type="text"
                        name="nome"
                        value={group.nome}
                        onChange={handleInputChange}
                    />
                </label>
                <label>
                    Ano:
                    <input
                        type="number"
                        name="ano"
                        value={group.ano}
                        onChange={handleInputChange}
                    />
                </label>
                <label>
                    Semestre:
                    <select
                        value={group.semestre}
                        name="semestre"
                        onChange={handleInputChange}
                    >
                        <option value={1}>
                            Primeiro
                        </option>
                        <option value={2}>
                            Segundo
                        </option>
                    </select>
                </label>
                    Professor:
                <select
                    value={group.professorId}
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
    );
}