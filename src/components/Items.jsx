import React, {useState} from 'react';

const Items = () => {
    const [items, setItems] = useState([]);

    const addItems = () => {
        setItems([...items, {
            id: items.length,
            value: Math.floor(Math.random() * 10) + 1
        }])
    }

    return(
        <React.Fragment>
            <button onClick={() => addItems()}>Add new item</button>
            <ul>
                {items.map(item => (
                    <li key={item.id}>{item.value}</li>
                ))}
            </ul>
        </React.Fragment>
    )
}

export default Items;