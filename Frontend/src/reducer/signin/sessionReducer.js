import {createSlice} from '@reduxjs/toolkit';

const sessionSlice = createSlice({
                                     name: 'session',
                                     initialState: {
                                         isConnected: false
                                     },
                                     reducers: {
                                         setIsConnected(state)
                                         {
                                             state.isConnected = !this.setIsConnected;
                                         }
                                     }
                                 });

export const {
    setIsConnected
} = sessionSlice.actions;

export default sessionSlice.reducer;