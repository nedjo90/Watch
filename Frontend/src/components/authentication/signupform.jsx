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
    setErrorEmailMessage,
    setErrorUsernameMessage,
    submitForm
} from '../../reducer/signup/signupreducer.js';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {ProfessionalStatusInput} from '../form/professionalstatusinput.jsx';
import dayjs from 'dayjs';
import Watchapi from '../../services/watchapi.js';
import {SIGN_IN} from '../../routes/routespath.jsx';
import {useNavigate} from 'react-router-dom';

export const SignUpForm = () =>
{
    const dispatch = useDispatch();
    const data = useSelector((({signUp}) => signUp));
    const navigate = useNavigate();

    useEffect(
        () =>
        {
            if (data.isSubmit && data.allInputAreValid)
            {
                const dateFormatted = dayjs(data.birthday, 'DD/MM/YYYY')
                .format('YYYY-MM-DD');
                console.log('data', data);
                const dataForApi = {
                    firstName: data.firstName,
                    lastName: data.lastName,
                    userName: data.username,
                    password: data.password,
                    confirmpassword: data.passwordConfirmation,
                    email: data.email,
                    confirmemail: data.emailConfirmation,
                    address: data.fullAddress.address,
                    postcode: data.fullAddress.postcode,
                    city: data.fullAddress.city,
                    country: 'France',
                    birthday: dateFormatted,
                    professionalstatusId: data.professionalStatusId
                };
                Watchapi.createUser(dataForApi)
                .then(response =>
                      {
                          navigate(SIGN_IN);
                      })
                .catch(error =>
                       {
                           console.log('BAD REQUEST', error);
                           if (error.response.status === 400)
                           {
                               console.log('data', error.response.data);
                               if (error.response.data.DuplicateEmail !== undefined)
                               {
                                   console.log(
                                       'duplicate email',
                                       error.response.data.DuplicateEmail);
                                   dispatch(setErrorEmailMessage(
                                       error.response.data.DuplicateEmail.toString()));
                               }
                               if (error.response.data.DuplicateUserName !== undefined)
                               {
                                   console.log(
                                       'duplicate username',
                                       error.response.data.DuplicateUserName);
                                   dispatch(setErrorUsernameMessage(
                                       error.response.data.DuplicateUserName.toString()));
                               }

                           }
                       });
            }
        },
        [data.isSubmit, data.allInputAreValid, data.birthday, data.firstName, data.lastName, data.username, data.password, data.passwordConfirmation, data.email, data.emailConfirmation, data.fullAddress.address, data.fullAddress.postcode, data.fullAddress.city, data.professionalStatusId, navigate, dispatch]);

    const submitRegisterForm = async () =>
    {
        dispatch(submitForm());
    };


    return (<div className={formStyles.formContainer}>
        <div className={formStyles.formTitle}>
            <h1>Registration</h1>
            <div>Already have an account ? <a href={SIGN_IN}>Sign In</a></div>
        </div>
        <Form className={formStyles.form}>
            <div className={formStyles.formFields}>
                <div>
                    <FirstnameInput/>
                    <LastnameInput/>
                    <Birthdaydatepicker/>
                    <CountryInput/>
                    <FullAddressInput/>
                    <ProfessionalStatusInput/>
                </div>
                <div>
                    <UsernameInput/>
                    <EmailInput/>
                    <EmailConfirmationInput/>
                    <PasswordInput/>
                    <PasswordConfirmationInput/>
                    <div className={formStyles.formButtonCard}>
                        <Button className={formStyles.formButton}
                                onClick={() => {submitRegisterForm();}}>Sign
                            Up</Button>
                    </div>
                </div>
            </div>
        </Form>
    </div>);
};


