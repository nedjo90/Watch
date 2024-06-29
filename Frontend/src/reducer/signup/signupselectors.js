import {createSelector} from 'reselect';

export const getSignUpState = (state) => state.signUp;

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

export const getErrorUsernameMessage = createSelector(
    [getSignUpState],
    (signUp) => signUp.errorUsernameMessage);

export const getIsValidUsername = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidUsername);

export const getEmail = createSelector(
    [getSignUpState],
    (signUp) => signUp.email);

export const getIsValidEmail = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidEmail);

export const getErrorEmailMessage = createSelector(
    [getSignUpState],
    (signUp) => signUp.errorEmailMessage);

export const getEmailConfirmation = createSelector(
    [getSignUpState],
    (signUp) => signUp.emailConfirmation);

export const getIsValidEmailConfirmation = createSelector(
    [getSignUpState],
    (signUp) => signUp.isSameEmail);

export const getPassword = createSelector(
    [getSignUpState],
    (signUp) => signUp.password);

export const getPasswordHide = createSelector(
    [getSignUpState],
    (signUp) => signUp.passwordHide);

export const getIsValidPassword = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidPassword);

export const getPasswordConfirmation = createSelector(
    [getSignUpState],
    (signUp) => signUp.passwordConfirmation);

export const getIsValidPasswordConfirmation = createSelector(
    [getSignUpState],
    (signUp) => signUp.isSamePassword);

export const getBirthday = createSelector(
    [getSignUpState],
    (signUp) => signUp.birthday);

export const getIsValidBirthday = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidBirthday);

export const getIsValidFullAddress = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidFullAddress);

export const getListOfProfessionalStatus = createSelector(
    [getSignUpState],
    (signUp) => signUp.listOfProfessionalStatus);

export const getProfessionalStatusId = createSelector(
    [getSignUpState],
    (signUp) => signUp.isProfessionalStatusId);

export const getIsValidProfessionalStatusId = createSelector(
    [getSignUpState],
    (signUp) => signUp.isValidProfessionalStatusId);
