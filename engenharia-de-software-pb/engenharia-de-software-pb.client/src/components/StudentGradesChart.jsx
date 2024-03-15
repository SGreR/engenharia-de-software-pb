import { useEffect, useState } from 'react';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Box from '@mui/material/Box';
import {
    LineChart,
    Line,
    XAxis,
    YAxis,
    CartesianGrid,
    Tooltip,
    Legend,
    ReferenceLine,
} from 'recharts';

export default function StudentGradesChart({ notasList }) {
    const [skill, setSkill] = useState('all');
    const [notas, setNotas] = useState(null);

    useEffect(() => {
        const resolvedNotas = resolveReferences(notasList);
        resolvedNotas.reverse();
        setNotas(resolvedNotas);
    }, [notasList]);

    const resolveReferences = (notasList) => {

        const referencedObjects = new Map();
        notasList.forEach((nota) => {
            if (nota.aluno && nota.aluno.$id) {
                referencedObjects.set(nota.aluno.$id, nota.aluno);
            }
            if (nota.turma && nota.turma.$id) {
                referencedObjects.set(nota.turma.$id, nota.turma);
            }
        });

        return notasList.map((nota) => {
            if (nota.aluno && nota.aluno.$ref) {
                const referencedAluno = referencedObjects.get(nota.aluno.$ref);
                if (referencedAluno) {
                    nota.aluno = referencedAluno;
                }
            }

            if (nota.turma && nota.turma.$ref) {
                const referencedTurma = referencedObjects.get(nota.turma.$ref);
                if (referencedTurma) {
                    nota.turma = referencedTurma;
                }
            }

            return nota;
        });
    };

    const handleChange = (event, newValue) => {
        setSkill(newValue);
    };

    const gradesToShow = () => {
        if (skill == "media") return <Line type="monotone" name="Media Final" dataKey="mediaFinal" stroke="#8A2BE2" />
        if (skill == "reading") return <Line type="monotone" name="Reading" dataKey={(nota) => nota.reading.media * 10} stroke="#4B0082" />
        if (skill == "writing") return <Line type="monotone" name="Writing" dataKey={(nota) => nota.writing.media * 10} stroke="#0000FF" />
        if (skill == "listening") return <Line type="monotone" name="Listening" dataKey={(nota) => nota.listening.media * 10} stroke="#006400" />
        if (skill == "grammar") return <Line type="monotone" name="Grammar" dataKey={(nota) => nota.grammar.media * 10} stroke="#CCCC00" />
        if (skill == "speaking") return <Line type="monotone" name="Speaking" dataKey={(nota) => nota.speaking.media * 10} stroke="#FFA500" />
        if (skill == "classPerformance") return <Line type="monotone" name="Class Performance" dataKey={(nota) => nota.classPerformance.media * 10} stroke="#FF0000" />
        if (skill == "all") {
            return (
                <>
                    <Line type="monotone" name="Media Final" dataKey="mediaFinal" stroke="#8A2BE2" />
                    <Line type="monotone" name="Reading" dataKey={(nota) => nota.reading.media * 10} stroke="#4B0082" />
                    <Line type="monotone" name="Writing" dataKey={(nota) => nota.writing.media * 10} stroke="#0000FF" />
                    <Line type="monotone" name="Listening" dataKey={(nota) => nota.listening.media * 10} stroke="#006400" />
                    <Line type="monotone" name="Grammar" dataKey={(nota) => nota.grammar.media * 10} stroke="#CCCC00" />
                    <Line type="monotone" name="Speaking" dataKey={(nota) => nota.speaking.media * 10} stroke="#FFA500" />
                    <Line type="monotone" name="Class Performance" dataKey={(nota) => nota.classPerformance.media * 10} stroke="#FF0000" />
                </>
            )
        }
    }

    return (
        <Box sx={{ width: '100%' }} >
            <Tabs
                value={skill}
                onChange={handleChange}
                textColor="secondary"
                indicatorColor="secondary"
                aria-label="secondary tabs example"
            >
                <Tab value="all" label="Todas as Notas" />
                <Tab value="media" label="Media Final" />
                <Tab value="reading" label="Reading" />
                <Tab value="writing" label="Writing" />
                <Tab value="listening" label="Listening" />
                <Tab value="grammar" label="Grammar" />
                <Tab value="speaking" label="Speaking" />
                <Tab value="classPerformance" label="Class Performance" />
            </Tabs>

            <LineChart
                width={1000}
                height={600}
                data={notas}
                margin={{
                    top: 20,
                    right: 50,
                    left: 20,
                    bottom: 5,
                }}
            >
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey={(nota) => `${nota.turma.nome} (${nota.turma.ano}-${nota.turma.semestre})`} />
                <YAxis domain={[0, 100]} />
                <Tooltip />
                <Legend />
                <ReferenceLine y={60} label="Media" stroke="red" />
                {gradesToShow()}
            </LineChart>
        </Box>
    )
}
