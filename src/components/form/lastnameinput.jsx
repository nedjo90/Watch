import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';

export const Lastnameinput = () => {
    return (
        <Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                Last Name</Form.Label>
            <Form.Control placeholder="last name"
                          className={formStyles.formTextInput}
                          type="text">
            </Form.Control>
        </Form.Group>
    );
}