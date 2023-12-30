import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import NotasDisplay from '../components/NotasDisplay';

export default function NotasDetailPage() {
    const [notas, setNotas] = useState(null)
    const { id } = useParams();

    useEffect(() => {
        fetch(`https://localhost:7215/api/Notas/${id}`)
            .then(response => response.json())
            .then(data => setNotas(data))
            .catch(error => console.error(error));
    }, [id]);

    return (
        <div>

            {notas === null ?
                (
                    <div>
                        <h2>Loading....</h2>
                    </div>
                )
                : (
                    <div>
                        <p>Id: {id}</p>
                        <NotasDisplay notas={ notas } />
                    </div>
                )}
        </div>
    );
}
