import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React, {useState} from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {setEmail} from '../../reducer/signup/signupreducer.js';
import {ErrorForm} from './errorform.jsx';
import {
    getEmail,
    getErrorEmailMessage,
    getIsSubmit,
    getIsValidEmail
} from '../../reducer/signup/signupselectors.js';

export const EmailInput = () =>
{
    const dispatch = useDispatch();
    const email = useSelector(getEmail);
    const isValidEmail = useSelector(getIsValidEmail);
    const errorMessage = useSelector(getErrorEmailMessage);
    const isSubmit = useSelector(getIsSubmit);

    return (
        <div>
            <Form.Group className={formStyles.formGroup}>
                <Form.Label className={formStyles.formLabel}>
                    E-mail</Form.Label>
                <Form.Control value={email} onChange={(event) =>
                {
                    dispatch(setEmail(event.target.value));
                }} placeholder="e-mail"
                              className={formStyles.formTextInput}
                              type="email">
                </Form.Control>
            </Form.Group>
            <ErrorForm isValid={isValidEmail} isSubmit={isSubmit}
                       message={errorMessage}></ErrorForm>
        </div>
    );
};