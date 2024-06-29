import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React, {useState} from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {
    togglePasswordVisibility,
    setPassword
} from '../../reducer/signup/signupreducer.js';
import {ErrorForm} from './errorform.jsx';
import {
    getPassword,
    getIsSubmit,
    getIsValidPassword,
    getPasswordHide
} from '../../reducer/signup/signupselectors.js';
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {
    faEyeSlash,
    faEye
} from '@fortawesome/fontawesome-free-solid';
import {InputGroup} from 'react-bootstrap';

export const PasswordInput = () =>
{
    const dispatch = useDispatch();
    const password = useSelector(getPassword);
    const passwordHide = useSelector(getPasswordHide);
    const isValidPassword = useSelector(getIsValidPassword);
    const isSubmit = useSelector(getIsSubmit);
    return (<div>
        <Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                Password</Form.Label>
            <div
                style={{position: 'relative'}}
            >
                <Form.Control
                    className={formStyles.formTextInput}
                    value={password} onChange={(event) =>
                {
                    dispatch(setPassword(event.target.value));
                }}
                    placeholder="password"
                    type={passwordHide ? 'password' : 'text'}>
                </Form.Control>
                <FontAwesomeIcon className={formStyles.passwordIcon}
                                 onClick={() =>
                                 {
                                     dispatch(togglePasswordVisibility());
                                 }}
                                 icon={passwordHide ? 'eye-slash' : 'eye'}/>
            </div>
        </Form.Group>
        <ErrorForm isValid={isValidPassword} isSubmit={isSubmit}
                   message="At least one digit, one lowercase letter, and one uppercase letter, and be at least 10 characters long"></ErrorForm>
    </div>);
};
