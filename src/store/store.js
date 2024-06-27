import {configureStore} from '@reduxjs/toolkit';
import signUpReducer from '../reducer/signupreducer.js';

const store = configureStore({
                                 reducer: {
                                     signUp: signUpReducer
                                 }
                             });

export default store;