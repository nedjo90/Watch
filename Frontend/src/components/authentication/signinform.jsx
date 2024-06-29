import Form from 'react-bootstrap/Form';

const USERNAME = 'username';
const PASSWORD = 'password';

import React from 'react';
import {Button} from 'react-bootstrap';
import {VARIANT} from '../../App.jsx';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {getUsername} from '../../reducer/signup/signupselectors.js';
import {
    getLoginPassword,
    getLoginUsername
} from '../../reducer/signin/signinselector.js';
import formStyles from '../../styles/form-styles.module.css';
import {
    SIGN_IN,
    SIGN_UP
} from '../../routes/routespath.jsx';

export const SignInForm = () =>
{
    const dispatch = useDispatch();
    const username = useSelector(getLoginUsername);
    const password = useSelector(getLoginPassword);

    return (
        <div className={formStyles.formSignInContainer}>
            <div className={formStyles.formTitle}>
                <h1>Authentication</h1>
                <div>Don't have an account? <a href={SIGN_UP}>Sign Up</a></div>
            </div>
            <Form className={formStyles.form}>
                <Form.Group className={formStyles.formGroup}
                            controlId="formBasicUsername">
                    <Form.Label
                        className={formStyles.formLabel}>Username</Form.Label>
                    <Form.Control className={formStyles.formTextInput}
                                  type="username"
                                  placeholder="Enter Username"/>
                </Form.Group>

                <Form.Group className={formStyles.formGroup}
                            controlId="formBasicPassword">
                    <Form.Label
                        className={formStyles.formLabel}>Password</Form.Label>
                    <Form.Control className={formStyles.formTextInput}
                                  type="password" placeholder="Password"/>
                </Form.Group>
                <Button className={formStyles.formButton} variant={VARIANT}
                        type="submit">Sign In
                </Button>
            </Form>
        </div>
    );
};
