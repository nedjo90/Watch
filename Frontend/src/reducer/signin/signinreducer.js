import {createSlice} from '@reduxjs/toolkit';

const signInSlice = createSlice({
                                    name: 'signIn',
                                    initialState: {
                                        userName: '',
                                        password: ''
                                    },
                                    reducers: {
                                        setLoginUserName(state, action){
                                            state.userName = action.payload
                                        },
                                        setLoginPassword(state, action){
                                            state.password = action.payload
                                        },
                                    }
                                });
export default signInSlice.reducer;