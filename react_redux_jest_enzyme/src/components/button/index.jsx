import React from 'react';
import PropTypes from 'prop-types';
import './styles.scss';

const SharedButton = (props) => {
  const { buttonText, emitEvent } = props;

  const submitEvent = () => {
    if (emitEvent) {
      emitEvent();
    }
  };

  return (
    <button data-test='buttonComponent' onClick={() => submitEvent()}>
      {buttonText}
    </button>
  );
};

SharedButton.propTypes = {
  buttonText: PropTypes.string,
  emitEvent: PropTypes.func,
};

export default SharedButton;
