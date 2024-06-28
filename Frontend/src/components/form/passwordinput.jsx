import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {
    setPassword
} from '../../reducer/signup/signupreducer.js';
import {ErrorForm} from './errorform.jsx';
import {
    getPassword,
    getIsSubmit,
    getIsValidPassword
} from '../../reducer/signup/signupselectors.js';

export const PasswordInput = () =>
{
    const dispatch = useDispatch();
    const password = useSelector(getPassword);
    const isValidPassword = useSelector(getIsValidPassword);
    const isSubmit = useSelector(getIsSubmit);
    return (<div>
        <Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                Password</Form.Label>
            <Form.Control
                value={password} onChange={(event) =>
            {
                dispatch(setPassword(event.target.value));
            }}
                placeholder="password"
                className={formStyles.formTextInput}
                type="password">
            </Form.Control>
        </Form.Group>
        <ErrorForm isValid={isValidPassword} isSubmit={isSubmit}
                   message="At least one digit, one lowercase letter, and one uppercase letter, and be at least 10 characters long"></ErrorForm>
    </div>);
};