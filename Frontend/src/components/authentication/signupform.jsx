import React, {useState} from 'react';
import Form from 'react-bootstrap/Form';
import {
    Button,
} from 'react-bootstrap';
import 'react-bootstrap-typeahead/css/Typeahead.css';
import {VARIANT} from '../../App.jsx';
import LocalisationService from '../../services/localisation.js';
import formStyles from '../../styles/form-styles.module.css';
import {UsernameInput} from '../form/usernameinput.jsx';
import {EmailInput} from '../form/emailinput.jsx';
import {EmailConfirmationInput} from '../form/emailconfirmationinput.jsx';
import {Passwordinput} from '../form/passwordinput.jsx';
import {PasswordConfirmationInput} from '../form/passwordconfirmationinput.jsx';
import {FirstnameInput} from '../form/firstnameinput.jsx';
import {Lastnameinput} from '../form/lastnameinput.jsx';
import {Birthdaydatepicker} from '../form/birthdaydatepicker.jsx';
import {CountryInput} from '../form/countryinput.jsx';
import {FullAddressInput} from '../form/fulladdressinput.jsx';
import {useDispatch} from 'react-redux';

export const SignUpForm = () =>
{
    const dispatch = useDispatch();
    const [isLoading, setIsLoading] = useState(false);
    const [options, setOptions] = useState([]);
    const [selectedCity, setSelectedCity] = useState([]);
    const [birthday, setBirthday] = useState(new Date());

    const handleSearch = (search) =>
    {
        setIsLoading(true);

        LocalisationService.getCity(search)
        .then((data) =>
              {
                  const arr = data.features.map(city =>
                                                {
                                                    return {
                                                        city: city.properties.name,
                                                        postcode: city.properties.postcode
                                                    };
                                                });
                  setOptions(arr);
                  setIsLoading(false);
              })
        .catch((error) =>
               {
                   console.error('Error fetching data:', error);
                   setIsLoading(false);
               });
    };

    const handleChange = (selected) =>
    {
        if (selected.length > 0)
        {
            setSelectedCity(selected[0]);
        }
        else
        {
            setSelectedCity([]);
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
                    <Passwordinput/>
                    <PasswordConfirmationInput/>
                </div>
                <div>
                    <FirstnameInput/>
                    <Lastnameinput/>
                    <Birthdaydatepicker/>
                    <CountryInput/>
                    <FullAddressInput handleSearch={handleSearch}
                                      handleChange={handleChange}
                                      isLoading={isLoading}
                                      options={options}
                    />
                </div>

            </div>
            <Button className={formStyles.formButton} variant={VARIANT}
                    type="submit">Sign Up</Button>
        </Form>
    </div>);
};
