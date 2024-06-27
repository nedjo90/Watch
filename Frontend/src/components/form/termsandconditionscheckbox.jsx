import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';

export const TermsAndConditionsCheckbox = () =>{
    return(
        <Form.Group className={formStyles.formGroup}>
            <Form.Check type="checkbox" id={`check-api-checkbox`}>
                <Form.Check.Input className={formStyles.formCheckbox}
                                  type="checkbox" isValid/>
                <Form.Check.Label className={formStyles.formLabel}>I
                    agree to the terms and conditions of the {<strong>Watch
                        Subscriber
                        Agreement</strong>} and {<strong>the privacy
                        policy</strong>}.</Form.Check.Label>
            </Form.Check>
        </Form.Group>
    );
}