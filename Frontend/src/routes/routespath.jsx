import {
    Navigate,
    Route,
    Routes
} from 'react-router-dom';
import {Home} from '../components/home/home.jsx';
import {SignInForm} from '../components/authentication/signinform.jsx';
import {SignUpForm} from '../components/authentication/signupform.jsx';
import Candidateprofile from '../components/profile/profile.jsx';
import profile from '../components/profile/profile.jsx';
import Admindashboard from '../components/admin/admindashboard.jsx';
import Profdashboard from '../components/prof/profdashboard.jsx';
import Logout from '../components/authentication/logout.jsx';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {getIsConnected} from '../reducer/session/sessionselector.js';
import Profile from '../components/profile/profile.jsx';
import {useEffect} from 'react';
import {initializeConnexion} from '../reducer/session/sessionReducer.js';

export const SIGN_IN = '/authentication/signin';
export const SIGN_UP = '/authentication/signup';
export const PROFILE = '/profile';
export const ADMIN_DASHBOARD = '/admin/dashboard';
export const PROF_DASHBOARD = '/prof/dashboard';
export const LOGOUT = '/logout';
export const HOME = '/';

export const RoutesPath = ({isConnected}) =>
{
    return (
        <Routes>
            <Route path={HOME} element={!isConnected ? <Home/> :
                <Navigate replace to={PROFILE}/>}></Route>
            <Route path={SIGN_IN} element={!isConnected ? <SignInForm/> :
                <Navigate replace to={PROFILE}/>}></Route>
            <Route path={SIGN_UP} element={!isConnected ? <SignUpForm/> :
                <Navigate replace to={PROFILE}/>}></Route>
            <Route path={PROFILE} element={<Profile/>}></Route>
            <Route path={ADMIN_DASHBOARD}
                   element={isConnected ? <Admindashboard/> :
                       <Navigate replace to={SIGN_IN}/>}></Route>
            <Route path={PROF_DASHBOARD}
                   element={isConnected ? <Profdashboard/> :
                       <Navigate replace to={SIGN_IN}/>}></Route>
            <Route path={LOGOUT} element={<Logout/>}></Route>
        </Routes>
    );
};

