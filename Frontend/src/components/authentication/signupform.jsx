import React, {
    useEffect,
    useState
} from 'react';
import Form from 'react-bootstrap/Form';
import {
    Button
} from 'react-bootstrap';
import 'react-bootstrap-typeahead/css/Typeahead.css';
import {VARIANT} from '../../App.jsx';
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
import {
    initializeProfessionalStatus,
    submitForm
} from '../../reducer/signup/signupreducer.js';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {ProfessionalStatusInput} from '../form/professionalstatusinput.jsx';

export const SignUpForm = () =>
{
    const dispatch = useDispatch();
    const data = useSelector((({signUp}) => signUp));


    const submitRegisterForm = () =>
    {
        dispatch(submitForm());
        console.log('data', data);
        if (data.allInputAreValid)
        {
            const dataForApi = {};
            //console.log("can be submit");
        }
        else
        {
            //console.log("cannot be submit");
        }
    };

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
                    <ProfessionalStatusInput/>
                </div>

            </div>
            <Button className={formStyles.formButton} variant={VARIANT}
                    onClick={() => {submitRegisterForm();}}>Sign Up</Button>
        </Form>
    </div>);
};

