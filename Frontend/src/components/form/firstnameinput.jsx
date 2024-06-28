import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {
    setFirstName
} from '../../reducer/signup/signupreducer.js';
import {ErrorForm} from './errorform.jsx';
import {
    getFirstName,
    getIsSubmit,
    getIsValidFirstName
} from '../../reducer/signup/signupselectors.js';

export const FirstnameInput = () =>
{
    const dispatch = useDispatch();
    const firstName = useSelector(getFirstName);
    const isValidFirstName = useSelector(getIsValidFirstName);
    const isSubmit = useSelector(getIsSubmit);

    return (<div>
        <Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                First Name</Form.Label>
            <Form.Control
                value={firstName} onChange={(event) =>
            {
                dispatch(setFirstName(event.target.value));
            }}
                placeholder="first name"
                className={formStyles.formTextInput}
                type="text">
            </Form.Control>
        </Form.Group>
        <ErrorForm isValid={isValidFirstName} isSubmit={isSubmit}
                   message="Please enter between 2 and 50 characters"></ErrorForm>
    </div>);
};