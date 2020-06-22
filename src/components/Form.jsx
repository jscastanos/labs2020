import React, { useState } from 'react';

const Form = () => {
    const [name, setName] = useState({ firstName: '', lastName: ''});

    return(
        <React.Fragment>
            <input type="text"
                    value={name.firstName}
                    placeholder="First Name"
                    onChange={e => setName({...name, firstName: e.target.value})}/>
            <input type="text"
                    value={name.lastName}
                    placeholder="Last Name"
                    onChange={e => setName({...name, lastName: e.target.value})}/>
        
            <p>
                {JSON.stringify(name)}
            </p>
        </React.Fragment>
    )
}

export default Form;