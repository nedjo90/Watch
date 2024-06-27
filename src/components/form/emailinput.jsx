import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';

export const EmailInput = () =>{
    return(
        <Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                E-mail</Form.Label>
            <Form.Control placeholder="e-mail"
                          className={formStyles.formTextInput}
                          type="email"
                          pattern="[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+.[a-zA-Z.]{2,15}">
            </Form.Control>
        </Form.Group>
    );
}