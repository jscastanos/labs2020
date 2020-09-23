import React from 'react';
import "./styles.scss";

const Headline = (props) => {
    const { header, desc } = props;

    return(
       <>
        {!header ? null : (
            <div data-test="HeadlineComponent">
                <h1 data-test="header">{header}</h1>
                <p data-test="desc">{desc}</p>
            </div>
        ) }
       </>
    )
}

export default Headline;