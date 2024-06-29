import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {setUsername} from '../../reducer/signup/signupreducer.js';
import {ErrorForm} from './errorform.jsx';
import {
    getUsername,
    getIsSubmit,
    getIsValidUsername,
    getErrorUsernameMessage
} from '../../reducer/signup/signupselectors.js';
import {FormSubField} from '../../styles/styled-components.js';

export const UsernameInput = () =>
{
    const dispatch = useDispatch();
    const username = useSelector(getUsername);
    const isValidUsername = useSelector(getIsValidUsername);
    const errorMessage = useSelector(getErrorUsernameMessage);
    const isSubmit = useSelector(getIsSubmit);

    return (
        <FormSubField>
            <Form.Group className={formStyles.formGroup}>
                <Form.Label className={formStyles.formLabel}>
                    Username</Form.Label>
                <Form.Control value={username} onChange={(event) =>
                {
                    dispatch(setUsername(event.target.value));
                }}
                              placeholder="username"
                              className={formStyles.formTextInput}
                              type="text">
                </Form.Control>
            </Form.Group>
            <ErrorForm isValid={isValidUsername} isSubmit={isSubmit}
                       message={errorMessage}></ErrorForm>
        </FormSubField>
    );
};