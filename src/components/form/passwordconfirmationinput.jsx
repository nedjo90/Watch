import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';

export const PasswordConfirmationInput = () =>
{
    return (
        <Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                Password confirmation</Form.Label>
            <Form.Control placeholder="password confirmation"
                          className={formStyles.formTextInput}
                          type="password">
            </Form.Control>
        </Form.Group>
    );
};