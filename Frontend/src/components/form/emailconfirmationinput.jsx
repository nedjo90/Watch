import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';

export const EmailConfirmationInput = () => {
    return (
        <Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                E-mail confirmation</Form.Label>
            <Form.Control placeholder="e-mail confirmation"
                          className={formStyles.formTextInput}
                          type="email"
                          pattern="[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+.[a-zA-Z.]{2,15}">
            </Form.Control>
        </Form.Group>
    );
}