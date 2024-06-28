import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {setEmailConfirmation} from '../../reducer/signup/signupreducer.js';
import {ErrorForm} from './errorform.jsx';
import {
    getEmailConfirmation,
    getIsSubmit,
    getIsValidEmailConfirmation
} from '../../reducer/signup/signupselectors.js';

export const EmailConfirmationInput = () =>
{
    const dispatch = useDispatch();
    const emailConfirmation = useSelector(getEmailConfirmation);
    const isValidEmailConfirmation = useSelector(getIsValidEmailConfirmation);
    const isSubmit = useSelector(getIsSubmit);

    return (
        <div>
            <Form.Group className={formStyles.formGroup}>
                <Form.Label className={formStyles.formLabel}>
                    E-mail confirmation</Form.Label>
                <Form.Control value={emailConfirmation}
                              onChange={(event) => dispatch(
                                  setEmailConfirmation(event.target.value))}
                              placeholder="e-mail confirmation"
                              className={formStyles.formTextInput}
                              type="email"
                              pattern="[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+.[a-zA-Z.]{2,15}">
                </Form.Control>
            </Form.Group>
            <ErrorForm isValid={isValidEmailConfirmation} isSubmit={isSubmit}
                       message="Email confirmation does not match"></ErrorForm>
        </div>
    );
};