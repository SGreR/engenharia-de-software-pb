/* eslint-disable react/prop-types */
import React, { useEffect } from 'react';
import { useState } from 'react';
import { useParams } from 'react-router-dom';

export default function NotasDisplay({ id, notas }) {
    const [grades, setGrades] = useState(notas);

    useEffect(() => {
        setGrades(notas)
    },[notas])

    return (
        <div className="gradesDisplay" >
            <div>
                <div>
                    <h3>Reading</h3>
                    <div>
                        <p>Primeira nota: {grades.reading.primeiraNota}</p>
                        <p>Segunda nota: {grades.reading.segundaNota}</p>
                        <h3>Media: {grades.reading.media}</h3>
                    </div>
                </div>
                <div>
                    <h3>Writing</h3>
                    <div>
                        <p>Primeira nota: {grades.writing.primeiraNota}</p>
                        <p>Segunda nota: {grades.writing.segundaNota}</p>
                        <h3>Media: {grades.writing.media}</h3>
                    </div>
                </div>
            </div>

            <div>
                <div>
                    <h3>Listening</h3>
                    <div>
                        <p>Primeira nota: {grades.listening.primeiraNota}</p>
                        <p>Segunda nota: {grades.listening.segundaNota}</p>
                        <h3>Media: {grades.listening.media}</h3>
                    </div>
                </div>
                <div>
                    <h3>Grammar</h3>
                    <div>
                        <p>Primeira nota: {grades.grammar.primeiraNota}</p>
                        <p>Segunda nota: {grades.grammar.segundaNota}</p>
                        <h3>Media: {grades.grammar.media}</h3>
                    </div>
                </div>
            </div>

            <div>
                <div>
                    <h3>Speaking</h3>
                    <div>
                        <p>Production and Fluency: {grades.speaking.productionAndFluencyGrade}</p>
                        <p>Spoken Interaction: {grades.speaking.spokenInteractionGrade}</p>
                        <p>Language Range: {grades.speaking.languageRangeGrade}</p>
                        <p>Accuracy: {grades.speaking.accuracyGrade}</p>
                        <p>L2 Use: {grades.speaking.l2Use}</p>
                        <h3>Media: {grades.speaking.media}</h3>
                    </div>
                </div>
                <div>
                    <h3>Class Perfomance</h3>
                    <div>
                        <p>Presence: {grades.classPerformance.presenceGrade}</p>
                        <p>Homework: {grades.classPerformance.homeworkGrade}</p>
                        <p>Participation: {grades.classPerformance.participationGrade}</p>
                        <p>Behavior: {grades.classPerformance.behaviorGrade}</p>
                        <h3>Media: {grades.classPerformance.media}</h3>
                    </div>
                </div>
            </div>
        </div>
  );
}