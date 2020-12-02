import React from 'react';
import PropTypes from 'prop-types';
import './styles.scss';

const ListItem = (props) => {
  const { title, desc } = props;

  return (
    <>
      {!title ? null : (
        <div data-test='listItemComponent'>
          <h2 data-test='componentTitle'>{title}</h2>
          <div data-test='componentDesc'>{desc}</div>
        </div>
      )}
    </>
  );
};

ListItem.propTypes = {
  title: PropTypes.string,
  desc: PropTypes.string,
};

export default ListItem;
