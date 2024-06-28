import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';
import {ErrorForm} from './errorform.jsx';
import {useSelector} from 'react-redux';
import {getIsSubmit} from '../../reducer/signup/signupselectors.js';

export const CountryInput = () => {
    const isSubmit = useSelector(getIsSubmit);

    return (
        <div>
            <Form.Group className={formStyles.formGroup}>
                <Form.Label className={formStyles.formLabel}>
                    Country</Form.Label>
                <Form.Control
                    style={{backgroundColor: '#a8a8a8'}}
                    placeholder="France"
                    className={formStyles.formTextInput}
                    type="text"
                    disabled>
                </Form.Control>
            </Form.Group>
            <ErrorForm isValid={true} isSubmit={isSubmit}
                       message="Invalid input"></ErrorForm>
        </div>
    );
}