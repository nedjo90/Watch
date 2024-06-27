import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';

export const CountryInput = () => {
    return (
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
    );
}