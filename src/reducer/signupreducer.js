import {
    createSlice,
    current
} from '@reduxjs/toolkit';
import {loadConfigFromFile} from 'vite';

const signUpSlice = createSlice(
    {
        name: 'signup',
        initialState: {
            username: '',
            email: '',
        },
        reducers: {
            changeUsername(state, action)
            {
                console.log(current(state));
                state.username = action.payload.toString();
            },

        }
    }
);

export const {
    changeUsername,
} = signUpSlice.actions;

export default signUpSlice.reducer;