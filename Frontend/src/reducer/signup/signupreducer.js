import {
    createSlice,
    current
} from '@reduxjs/toolkit';
import {
    isValidBirthday,
    isValidEmail,
    isValidFirstName,
    isValidLastName,
    isValidPassword,
    isValidUsername
} from './signupvalidations.js';

const signUpSlice = createSlice({
                                    name: 'signUp',
                                    initialState: {
                                        username: '',
                                        isValidUsername: false,
                                        email: '',
                                        isValidEmail: false,
                                        emailConfirmation: '',
                                        isSameEmail: false,
                                        password: '',
                                        isValidPassword: false,
                                        passwordConfirmation: '',
                                        isSamePassword: false,
                                        firstName: '',
                                        isValidFirstName: false,
                                        lastName: '',
                                        isValidLastName: false,
                                        birthday: '',
                                        isValidBirthday: false,
                                        fullAddress: {
                                            address: '',
                                            postcode: '',
                                            city: '',
                                            country: 'France'
                                        },
                                        isValidFullAddress: false,
                                        isSubmit: false
                                    },
                                    reducers: {
                                        setUsername(state, action)
                                        {
                                            state.username = action.payload.toString();
                                            state.isValidUsername = isValidUsername(
                                                state.username);
                                            console.log(current(state));
                                        },
                                        setEmail(state, action)
                                        {
                                            state.email = action.payload.toString();
                                            state.isValidEmail = isValidEmail(
                                                state.email);
                                            console.log(current(state));
                                        },
                                        setEmailConfirmation(state, action)
                                        {
                                            state.emailConfirmation = action.payload.toString();
                                            state.isSameEmail = state.emailConfirmation === state.email;
                                            console.log(current(state));
                                        },
                                        setPassword(state, action)
                                        {
                                            state.password = action.payload.toString();
                                            state.isValidPassword = isValidPassword(
                                                state.password);
                                            console.log(current(state));
                                        },
                                        setPasswordConfirmation(state,
                                                                action)
                                        {
                                            state.passwordConfirmation = action.payload.toString();
                                            state.isSamePassword = state.passwordConfirmation === state.password;
                                            console.log(current(state));
                                        },
                                        setBirthday(state, action)
                                        {
                                            state.birthday = action.payload.toString();
                                            state.isValidBirthday = isValidBirthday(
                                                state.birthday);
                                            console.log(current(state));
                                        },
                                        setFirstName(state, action)
                                        {
                                            state.firstName = action.payload.toString();
                                            state.isValidFirstName = isValidFirstName(
                                                state.firstName);
                                            console.log(current(state));
                                        },
                                        setLastName(state, action)
                                        {
                                            state.lastName = action.payload.toString();
                                            state.isValidLastName = isValidLastName(
                                                state.lastName);
                                            console.log(current(state));
                                        },
                                        setFullAddress(state, action)
                                        {
                                            state.fullAddress.address = action.payload.address;
                                            state.fullAddress.city = action.payload.city;
                                            state.fullAddress.postcode = action.payload.postcode;
                                        },
                                        submitForm(state)
                                        {
                                            state.isSubmit = true;
                                        }
                                    }
                                });

export const dateNow = () =>
{
    const today = new Date();
    const yyyy = today.getFullYear();
    let mm = today.getMonth() + 1; // Months start at 0!
    let dd = today.getDate();

    if (dd < 10) dd = '0' + dd;
    if (mm < 10) mm = '0' + mm;

    return (dd + '/' + mm + '/' + yyyy);
};

export const {
    setUsername,
    setEmail,
    setEmailConfirmation,
    setPassword,
    setPasswordConfirmation,
    setBirthday,
    setFirstName,
    setLastName,
    setFullAddress,
    submitForm
} = signUpSlice.actions;

export default signUpSlice.reducer;