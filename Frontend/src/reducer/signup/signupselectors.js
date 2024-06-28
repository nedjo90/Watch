import {createSelector} from 'reselect';

const getSignUpState = (state) => state.signUp;

export const getIsSubmit = createSelector(
    [getSignUpState],
    (signUp) => signUp.isSubmit);

export const getFirstName = createSelector(
    [getSignUpState],
    (signUp) => signUp.firstName);

export const getIsValidFirstName = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidFirstName);

export const getLastName = createSelector(
    [getSignUpState],
    (signUp) => signUp.lastName);

export const getIsValidLastName = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidLastName);

export const getUsername = createSelector(
    [getSignUpState],
    (signUp) => signUp.username);

export const getIsValidUsername = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidUsername);

export const getEmail = createSelector(
    [getSignUpState],
    (signUp) => signUp.email);

export const getIsValidEmail = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidEmail);

export const getEmailConfirmation = createSelector(
    [getSignUpState],
    (signUp) => signUp.emailConfirmation);

export const getIsValidEmailConfirmation = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidEmailConfirmation);

export const getPassword = createSelector(
    [getSignUpState],
    (signUp) => signUp.password);

export const getIsValidPassword = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidPassword);

export const getPasswordConfirmation = createSelector(
    [getSignUpState],
    (signUp) => signUp.passwordConfirmation);

export const getIsValidPasswordConfirmation = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidPasswordConfirmation);


export const getBirthday = createSelector(
    [getSignUpState],
    (signUp) => signUp.birthday);

export const getIsValidBirthday = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidBirthday);
