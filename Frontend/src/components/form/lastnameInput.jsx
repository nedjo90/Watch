import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {setLastName} from '../../reducer/signup/signupreducer.js';
import {ErrorForm} from './errorform.jsx';
import {
    getLastName,
    getIsSubmit,
    getIsValidLastName
} from '../../reducer/signup/signupselectors.js';

export const LastnameInput = () =>
{
    const dispatch = useDispatch();
    const lastName = useSelector(getLastName);
    const isValidLastName = useSelector(getIsValidLastName);
    const isSubmit = useSelector(getIsSubmit);
    return (
        <div>
            <Form.Group className={formStyles.formGroup}>
                <Form.Label className={formStyles.formLabel}>
                    Last Name</Form.Label>
                <Form.Control
                    value={lastName} onChange={(event) =>
                {
                    dispatch(setLastName(event.target.value));
                }}
                    placeholder="last name"
                    className={formStyles.formTextInput}
                    type="text">
                </Form.Control>
            </Form.Group>
            <ErrorForm isValid={isValidLastName} isSubmit={isSubmit}
                       message="Please enter between 2 and 50 characters"></ErrorForm>
        </div>
    );
};