import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React from 'react';
import {useDispatch} from 'react-redux';
import {changeUsername} from '../../reducer/signupreducer.js';

export const UsernameInput = () =>
{
    const dispatch = useDispatch();

    return (<Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                Username</Form.Label>
            <Form.Control onChange={(event) => {
                dispatch(changeUsername(event.target.value));
            }}
                placeholder="username"
                          className={formStyles.formTextInput}
                          type="text">
            </Form.Control>
        </Form.Group>);
};