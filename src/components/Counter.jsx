import React, { useState } from 'react';

const Counter = () => {
    const [count, setCount] = useState(0);

    return(
        <React.Fragment>
            <button onClick={() => setCount(count + 1)}>Count {count}</button>
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