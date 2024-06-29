import {createSelector} from 'reselect';

export const getSignInState = (state) => state.signIn;

export const getLoginUsername = createSelector(
    [getSignInState],
    (signIn) => signIn.userName);

export const getLoginPassword = createSelector(
    [getSignInState],
    (signIn) => signIn.password);