import {createSelector} from 'reselect';

export const getSessionState = (state) => state.session;

export const getIsConnected = createSelector(
    [getSessionState],
    (session) => session.isConnected);

export const getIsNotConnected = createSelector(
    [getSessionState],
    (session) => session.isNotConnected);