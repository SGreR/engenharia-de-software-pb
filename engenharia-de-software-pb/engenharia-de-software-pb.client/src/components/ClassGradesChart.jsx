import { useEffect, useState } from 'react';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Box from '@mui/material/Box';
import { BarChart, Bar, Rectangle, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';

export default function ClassGradesChart({ notasList }) {
    const [notas, setNotas] = useState(null);

    useEffect(() => {
        const resolvedNotas = resolveReferences(notasList);
        const skillData = getSkillData(resolvedNotas);
        setNotas(skillData);
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

    const getSkillData = (resolvedNotas) => {
        const skills = ['reading', 'writing', 'listening', 'grammar', 'speaking', 'classPerformance', 'mediaFinal'];

        return skills.map(skill => {
            const skillGrades = resolvedNotas.map(nota => skill == 'mediaFinal' ? nota[skill] : nota[skill].media * 10);
            const minGrade = Math.min(...skillGrades);
            const maxGrade = Math.max(...skillGrades);
            const averageGrade = skillGrades.reduce((acc, curr) => acc + curr, 0) / skillGrades.length;

            return {
                skill: skill.charAt(0).toUpperCase() + skill.slice(1),
                min: minGrade,
                max: maxGrade,
                average: averageGrade.toFixed(2)
            };
        });
    };


    return (
        <BarChart
            width={1000}
            height={600}
            data={notas}
            margin={{
                top: 5,
                right: 30,
                left: 20,
                bottom: 5,
            }}
        >
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="skill" />
            <YAxis domain={[0, 100]} />
            <Tooltip />
            <Legend />
            <Bar dataKey="min" name="Min" fill="#8884d8" />
            <Bar dataKey="average" name="Average" fill="#ffc658" />
            <Bar dataKey="max" name="Max" fill="#82ca9d" />
            
        </BarChart>
    )
}
