import {createSelector} from 'reselect';

export const getSignInState = (state) => state.signIn;

export const getLoginUsername = createSelector(
    [getSignInState],
    (signIn) => signIn.userName);

export const getIsValidLoginUsername = createSelector(
    [getSignInState],
    (signIn) => signIn.isValidUsername);

export const getErrorLoginUsernameMessage = createSelector(
    [getSignInState],
    (signIn) => signIn.errorUsernameMessage);

export const getLoginPassword = createSelector(
    [getSignInState],
    (signIn) => signIn.password);

export const getIsValidLoginPassword = createSelector(
    [getSignInState],
    (signIn) => signIn.isValidPassword);

export const getErrorLoginPasswordMessage = createSelector(
    [getSignInState],
    (signIn) => signIn.errorPasswordMessage);

export const getIsSubmit = createSelector(
    [getSignInState],
    (signIn) => signIn.isSubmit);


