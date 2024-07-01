import {configureStore} from '@reduxjs/toolkit';
import signUpReducer from '../reducer/signup/signupreducer.js';
import signInReducer from '../reducer/signin/signinreducer.js';
import sessionReducer from '../reducer/signin/sessionReducer.js';

const store = configureStore({
                                 reducer: {
                                     signUp: signUpReducer,
                                     signIn: signInReducer,
                                     session: sessionReducer,
                                 }
                             });

export default store;