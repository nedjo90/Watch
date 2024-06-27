import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';

export const Passwordinput = () =>
{
    return (
        <Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                Password</Form.Label>
            <Form.Control placeholder="password"
                          className={formStyles.formTextInput}
                          type="password">
            </Form.Control>
        </Form.Group>
    );
};