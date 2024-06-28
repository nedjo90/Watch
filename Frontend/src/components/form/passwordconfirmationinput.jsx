import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';
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
    getIsValidPasswordConfirmation
} from '../../reducer/signup/signupselectors.js';

export const PasswordConfirmationInput = () =>
{
    const dispatch = useDispatch();
    const passwordConfirmation = useSelector(getPasswordConfirmation);
    const isValidPasswordConfirmation = useSelector(getIsValidPasswordConfirmation);
    const isSubmit = useSelector(getIsSubmit);
    return (<div>
            <Form.Group className={formStyles.formGroup}>
                <Form.Label
                    className={formStyles.formLabel}>
                    Password confirmation</Form.Label>
                <Form.Control
                    value={passwordConfirmation} onChange={(event) =>
                {
                    dispatch(setPasswordConfirmation(event.target.value));
                }}
                    placeholder="password confirmation"
                    className={formStyles.formTextInput}
                    type="password">
                </Form.Control>
            </Form.Group>
            <ErrorForm isValid={isValidPasswordConfirmation} isSubmit={isSubmit}
                       message="Password confirmation does not match"></ErrorForm>
        </div>);
};