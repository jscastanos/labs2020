import React, { useState } from 'react';

const Counter = () => {
    const initialCount = 0;
    const [count, setCount] = useState(initialCount);

    return(
        <React.Fragment>
            <p>Count: {count}</p>
            <button onClick={() => setCount(initialCount)}>Reset</button>
            <button onClick={() => setCount(prevCount => prevCount + 1)}>Increment</button>
            <button onClick={() => setCount(prevCount => prevCount - 1)}>Decrement</button>
       </React.Fragment>
    )
}


// class Counter extends Component{
//     constructor(props){
//         super(props);
//         this.state = {
//             count : 0
//         }
//     }

//     incrementCount = () => {
//         this.setState({
//             count : this.state.count + 1
//         })
//     }

//     render(){
//         const {count} = this.state;
//         return(
//             <React.Fragment>
//                 <button onClick={() => this.incrementCount()}>Count {count}</button>
//             </React.Fragment>
//         )
//     }
// }

export default Counter;