import {
    createSlice,
    current
} from '@reduxjs/toolkit';
import WatchApiServices from '../../services/watchapi.js';

const sessionSlice = createSlice({
                                     name: 'session',
                                     initialState: {
                                         isConnected: false,
                                         user: {
                                             username: '',
                                             firstName: '',
                                             lastName: '',
                                             profilePicture: '',
                                             address: '',
                                             postcode: '',
                                             city: '',
                                             country: '',
                                             birthday: '',
                                             professionalStatus: '',
                                             roles: []
                                         },
                                         listOfProfessionalStatus: [],
                                         userForUpdate: {
                                             firstName: '',
                                             lastName: '',
                                             address: '',
                                             postcode: '',
                                             city: '',
                                             country: '',
                                             birthday: '',
                                             professionalStatusId: ''
                                         }
                                     },
                                     reducers: {
                                         setIsConnected(state)
                                         {
                                             state.isConnected = true;
                                         },
                                         setIsNotConnected(state)
                                         {
                                             state.isConnected = false;
                                         }
                                         ,
                                         setUserInfo(state, action)
                                         {
                                             state.user = action.payload;
                                         },
                                         setListOfProfessionalStatus(state,
                                                                     action)
                                         {
                                             state.listOfProfessionalStatus = action.payload;
                                             console.log(
                                                 state.listOfProfessionalStatus);
                                         },
                                         setUserForUpdate(state)
                                         {
                                             state.userForUpdate.firstName = state.user.firstName;
                                             state.userForUpdate.lastName = state.user.lastName;
                                             state.userForUpdate.address = state.user.address;
                                             state.userForUpdate.postcode = state.user.postcode;
                                             state.userForUpdate.city = state.user.city;
                                             state.userForUpdate.country = state.user.country;
                                             state.userForUpdate.birthday = state.user.birthday;
                                             state.userForUpdate.professionalStatusId = state.listOfProfessionalStatus.find(
                                                 e => e.label === state.user.professionalStatus).id;
                                             console.log(current(state));
                                         },
                                         setNewAddress(state, action)
                                         {
                                             state.userForUpdate.address = action.payload.address;
                                             state.userForUpdate.city = action.payload.city;
                                             state.userForUpdate.postcode = action.payload.postcode;
                                             console.log('on' +
                                                             ' address' +
                                                             ' change', current(
                                                 state.userForUpdate));
                                         },
                                         setNewFirstName(state, action)
                                         {
                                             state.userForUpdate.firstName = action.payload;
                                             console.log('on firstname' +
                                                             ' change', current(
                                                 state.userForUpdate));
                                         },
                                         setNewLastName(state, action)
                                         {
                                             state.userForUpdate.lastName = action.payload;
                                             console.log('on lastname' +
                                                             ' change', current(
                                                 state.userForUpdate));
                                         },
                                         setNewProfessionalStatusId(state,
                                                                    action)
                                         {
                                             state.userForUpdate.professionalStatusId = action.payload;
                                             console.log('on prof status id' +
                                                             ' change', current(
                                                 state.userForUpdate));
                                         }
                                     }
                                 });

export const initializeConnexion = () =>
{
    return async dispatch =>
    {
        const accessToken = localStorage.getItem(
            'watchApiAccessToken');
        const refreshToken = localStorage.getItem(
            'watchApiRefreshToken');
        console.log('access token', accessToken);
        console.log('refresh token', refreshToken);
        if (!accessToken || !refreshToken)
        {
            dispatch(setIsNotConnected());
            return;
        }
        const response = await WatchApiServices.optionRoot();
        console.log(response);
        if (response.status === 200)
            dispatch(setIsConnected());
    };
};

export const initializeSession = () =>
{
    return async dispatch =>
    {
        dispatch(initializeConnexion());
        const response = await WatchApiServices.getUserInfo();
        if (response.status !== 200)
        {
            dispatch(setIsNotConnected());
            return;
        }
        console.log('userInfo: ', response.data);
        dispatch(setUserInfo(response.data));
        const list = await WatchApiServices.getAllProfessionalStatus();
        console.log('list of professional status', list);
        dispatch(setListOfProfessionalStatus(list));
        dispatch(setUserForUpdate());

    };
};

export const {
    checkConnection,
    setIsConnected,
    setIsNotConnected,
    setUserInfo,
    setListOfProfessionalStatus,
    setUserForUpdate,
    setNewAddress,
    setNewFirstName,
    setNewLastName
} = sessionSlice.actions;

export default sessionSlice.reducer;