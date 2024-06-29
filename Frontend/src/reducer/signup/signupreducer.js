import {
    createSlice,
    current
} from '@reduxjs/toolkit';
import {
    allInputAreValid,
    isValidBirthday,
    isValidEmail,
    isValidFirstName,
    isValidFullAddress,
    isValidLastName,
    isValidPassword,
    isValidProfessionalStatusId,
    isValidUsername
} from './signupvalidations.js';
import WatchApiServices from '../../services/watchapi.js';

const signUpSlice = createSlice({
                                    name: 'signUp',
                                    initialState: {
                                        username: '',
                                        isValidUsername: false,
                                        errorUsernameMessage: '',
                                        email: '',
                                        isValidEmail: false,
                                        errorEmailMessage: '',
                                        emailConfirmation: '',
                                        isSameEmail: false,
                                        password: '',
                                        passwordHide: true,
                                        isValidPassword: false,
                                        passwordConfirmation: '',
                                        isSamePassword: false,
                                        firstName: '',
                                        isValidFirstName: false,
                                        lastName: '',
                                        isValidLastName: false,
                                        birthday: '',
                                        isValidBirthday: false,
                                        listOfProfessionalStatus: [],
                                        professionalStatusId: '0',
                                        isValidProfessionalStatusId: false,
                                        fullAddress: {
                                            address: '',
                                            postcode: '',
                                            city: '',
                                            country: 'France'
                                        },
                                        isValidFullAddress: false,
                                        isSubmit: false,
                                        allInputAreValid: false
                                    },
                                    reducers: {
                                        setUsername(state, action)
                                        {
                                            state.errorUsernameMessage = 'Please enter between 2 and 50 characters';
                                            state.username = action.payload.toString();
                                            state.isValidUsername = isValidUsername(
                                                state.username);
                                        },
                                        setErrorUsernameMessage(state, action){
                                            console.log("changed");
                                            state.errorUsernameMessage = action.payload;
                                            state.username = '';
                                            state.isValidUsername = false;
                                        },
                                        setEmail(state, action)
                                        {
                                            state.errorEmailMessage = 'Please enter a valid email format';
                                            state.email = action.payload.toString();
                                            state.isSameEmail = state.emailConfirmation === state.email;
                                            state.isValidEmail = isValidEmail(
                                                state.email);
                                        },
                                        setErrorEmailMessage(state, action)
                                        {
                                            state.errorEmailMessage = action.payload;
                                            state.email = '';
                                            state.isValidEmail = false;
                                        }
                                        ,
                                        setEmailConfirmation(state, action)
                                        {
                                            state.emailConfirmation = action.payload.toString();
                                            state.isSameEmail = state.emailConfirmation === state.email;
                                            // console.log(current(state));
                                        },
                                        setPassword(state, action)
                                        {
                                            state.password = action.payload.toString();
                                            state.isSamePassword = state.passwordConfirmation === state.password;
                                            state.isValidPassword = isValidPassword(
                                                state.password);
                                            // console.log(current(state));
                                        },
                                        togglePasswordVisibility(state)
                                        {
                                            state.passwordHide = !state.passwordHide;
                                        },
                                        setPasswordConfirmation(state, action)
                                        {
                                            state.passwordConfirmation = action.payload.toString();
                                            state.isSamePassword = state.passwordConfirmation === state.password;
                                            // console.log(current(state));
                                        },
                                        setBirthday(state, action)
                                        {
                                            state.birthday = action.payload.toString();
                                            state.isValidBirthday = isValidBirthday(
                                                state.birthday);
                                            // console.log(current(state));
                                        },
                                        setFirstName(state, action)
                                        {
                                            state.firstName = action.payload.toString();
                                            state.isValidFirstName = isValidFirstName(
                                                state.firstName);
                                            // console.log(current(state));
                                        },
                                        setLastName(state, action)
                                        {
                                            state.lastName = action.payload.toString();
                                            state.isValidLastName = isValidLastName(
                                                state.lastName);
                                            // console.log(current(state));
                                        },
                                        setFullAddress(state, action)
                                        {
                                            state.fullAddress.address = action.payload.address;
                                            state.fullAddress.city = action.payload.city;
                                            state.fullAddress.postcode = action.payload.postcode;
                                            state.isValidFullAddress = isValidFullAddress(
                                                state.fullAddress);
                                            // console.log(current(state));
                                        },
                                        submitForm(state)
                                        {
                                            state.isSubmit = true;
                                            state.allInputAreValid = allInputAreValid(
                                                state);
                                        },
                                        loadProfessionalStatus(state, action)
                                        {
                                            state.listOfProfessionalStatus = action.payload;
                                        },
                                        setProfessionalStatusId(state, action)
                                        {
                                            state.professionalStatusId = action.payload;
                                            state.isValidProfessionalStatusId = isValidProfessionalStatusId(
                                                current(
                                                    state.listOfProfessionalStatus),
                                                state.professionalStatusId);
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
    togglePasswordVisibility,
    setPasswordConfirmation,
    setBirthday,
    setFirstName,
    setLastName,
    setFullAddress,
    submitForm,
    loadProfessionalStatus,
    setProfessionalStatusId,
    setErrorEmailMessage,
    setErrorUsernameMessage
} = signUpSlice.actions;

export default signUpSlice.reducer;

export const initializeProfessionalStatus = () =>
{
    return async dispatch =>
    {
        const data = await WatchApiServices.getAllProfessionalStatus();
        const placeholder = [{
            id: '0',
            label: 'Please select a' + ' professional status'
        }];
        dispatch(loadProfessionalStatus(placeholder.concat(data)));
    };
};