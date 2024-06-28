import React, {useState} from 'react';
import Form from 'react-bootstrap/Form';
import {
    Button
} from 'react-bootstrap';
import 'react-bootstrap-typeahead/css/Typeahead.css';
import {VARIANT} from '../../App.jsx';
import LocalisationService from '../../services/localisation.js';
import formStyles from '../../styles/form-styles.module.css';
import {UsernameInput} from '../form/usernameinput.jsx';
import {EmailInput} from '../form/emailinput.jsx';
import {EmailConfirmationInput} from '../form/emailconfirmationinput.jsx';
import {PasswordInput} from '../form/passwordinput.jsx';
import {PasswordConfirmationInput} from '../form/passwordconfirmationinput.jsx';
import {FirstnameInput} from '../form/firstnameinput.jsx';
import {LastnameInput} from '../form/lastnameInput.jsx';
import {Birthdaydatepicker} from '../form/birthdaydatepicker.jsx';
import {CountryInput} from '../form/countryinput.jsx';
import {FullAddressInput} from '../form/fulladdressinput.jsx';
import {useDispatch} from 'react-redux';
import {ErrorContainer} from '../../styles/styled-components.js';
import {submitForm} from '../../reducer/signup/signupreducer.js';

export const SignUpForm = () =>
{
    const dispatch = useDispatch();

    const [selectedCity, setSelectedCity] = useState([]);
    const [birthday, setBirthday] = useState(new Date());

    return (<div className={formStyles.formContainer}>
        <h1 className={formStyles.formTitle}>Registration</h1>
        <Form className={formStyles.form}>
            <div className={formStyles.formFields}>
                <div>
                    <UsernameInput/>
                    <EmailInput/>
                    <EmailConfirmationInput/>
                    <PasswordInput/>
                    <PasswordConfirmationInput/>
                </div>
                <div>
                    <FirstnameInput/>
                    <LastnameInput/>
                    <Birthdaydatepicker/>
                    <CountryInput/>
                    <FullAddressInput/>
                </div>

            </div>
            <Button className={formStyles.formButton} variant={VARIANT}
                    onClick={() => {dispatch(submitForm());}}>Sign Up</Button>
        </Form>
    </div>);
};
