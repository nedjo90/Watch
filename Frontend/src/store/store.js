import {configureStore} from '@reduxjs/toolkit';
import signUpReducer from '../reducer/signup/signupreducer.js';

const store = configureStore({
                                 reducer: {
                                     signUp: signUpReducer
                                 }
                             });

export default store;