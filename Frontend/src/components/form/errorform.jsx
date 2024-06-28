import React from 'react';
import {
    ErrorContainer,
    ErrorText
} from '../../styles/styled-components.js';

export const ErrorForm = ({
                              isValid,
                              isSubmit,
                              message
                          }) =>
{


    return (
        <ErrorContainer>
            <ErrorText
                style={{display: `${!isValid && isSubmit ? 'block' : 'none'}`}}>
                {message}
            </ErrorText>
        </ErrorContainer>
    );
};