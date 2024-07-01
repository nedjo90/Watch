import {
    createSlice,
    current
} from '@reduxjs/toolkit';
import {
    isValidPassword,
    isValidUsername
} from '../signup/signupvalidations.js';

const signInSlice = createSlice({
                                    name: 'signIn',
                                    initialState: {
                                        username: '',
                                        isValidUsername: false,
                                        errorUsernameMessage: 'Please enter between 2 and 50 characters',
                                        password: '',
                                        isValidPassword: false,
                                        errorPasswordMessage: 'At least one digit, one lowercase letter, and one uppercase letter, and be at least 10 characters long',
                                        allInputAreValid: false,
                                        errorConnectionMessage: 'Invalid' +
                                            ' username or password',
                                        isConnectionFailed: false,
                                        isSubmit: false
                                    },
                                    reducers: {
                                        setLoginUsername(state, action)
                                        {
                                            state.isSubmit = false;
                                            state.username = action.payload;
                                            state.isValidUsername = isValidUsername(
                                                state.username);
                                            console.log(current(state));
                                        },
                                        setErrorLoginUsername(state, action)
                                        {
                                            state.errorUsernameMessage = action.payload;
                                        },
                                        setLoginPassword(state, action)
                                        {
                                            state.isSubmit = false;
                                            state.password = action.payload;
                                            state.isValidPassword = isValidPassword(
                                                state.password);
                                            console.log(current(state));
                                        },
                                        setErrorLoginPassword(state, action)
                                        {
                                            state.errorPasswordMessage = action.payload;
                                        },
                                        submitLogin(state)
                                        {
                                            state.isConnectionFailed = true;
                                            state.isSubmit = true;
                                            state.allInputAreValid = state.isValidPassword && state.isValidUsername;
                                        },
                                        setConnectionFailed(state)
                                        {
                                            state.isConnectionFailed = false;
                                        }
                                    }
                                });

export const {
    setLoginUsername,
    setLoginPassword,
    submitLogin,
    setConnectionFailed,
} = signInSlice.actions;

export default signInSlice.reducer;