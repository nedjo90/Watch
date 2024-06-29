import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React, {useState} from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {
    setPasswordConfirmation
} from '../../reducer/signup/signupreducer.js';
import {ErrorForm} from './errorform.jsx';
import {
    getPasswordConfirmation,
    getIsSubmit,
    getIsValidPasswordConfirmation,
    getPasswordHide,
    getPassword
} from '../../reducer/signup/signupselectors.js';
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';

export const PasswordConfirmationInput = () =>
{
    const dispatch = useDispatch();
    const passwordConfirmation = useSelector(getPasswordConfirmation);
    const passwordHide = useSelector(getPasswordHide);
    const isValidPasswordConfirmation = useSelector(
        getIsValidPasswordConfirmation);
    const isSubmit = useSelector(getIsSubmit);

    return (<div>
        <Form.Group className={formStyles.formGroup}>
            <Form.Label
                className={formStyles.formLabel}>
                Password confirmation</Form.Label>
            <div
                style={{position: 'relative'}}>
                <Form.Control
                    value={passwordConfirmation} onChange={(event) =>
                {
                    dispatch(setPasswordConfirmation(event.target.value));
                }}
                    style={{color: `${isValidPasswordConfirmation ? "black" : "red"}`}}
                    placeholder="password confirmation"
                    className={formStyles.formTextInput}
                    type={passwordHide ? 'password' : 'text'}>
                </Form.Control>
            </div>
        </Form.Group>
        <ErrorForm isValid={isValidPasswordConfirmation} isSubmit={isSubmit}
                   message="Password confirmation does not match"></ErrorForm>
    </div>);
};