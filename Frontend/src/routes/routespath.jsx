import {
    Route,
    Routes
} from 'react-router-dom';
import {Home} from '../components/home/home.jsx';
import {SignInForm} from '../components/authentication/signinform.jsx';
import {SignUpForm} from '../components/authentication/signupform.jsx';
import Candidateprofile from '../components/candidate/candidatedashboard.jsx';
import CandidateDashboard from '../components/candidate/candidatedashboard.jsx';
import AdminDashboard from '../components/admin/admindashboard.js';
import ProfDashboard from '../components/prof/profdashboard.js';
import Logout from '../components/authentication/logout.jsx';

export const SIGN_IN = "/authentication/signin"
export const SIGN_UP = "/authentication/signup"
export const CANDIDATE_DASHBOARD = "/candidate/dashboard"
export const ADMIN_DASHBOARD = "/admin/dashboard"
export const PROF_DASHBOARD = "/prof/dashboard"
export const LOGOUT = "/logout"
export const HOME = "/"


export const RoutesPath = () => {
    return (
        <Routes>
            <Route path={HOME} element={<Home/>}></Route>
            <Route path={SIGN_IN} element={<SignInForm/>}></Route>
            <Route path={SIGN_UP} element={<SignUpForm/>}></Route>
            <Route path={CANDIDATE_DASHBOARD} element={<CandidateDashboard  />}></Route>
            <Route path={ADMIN_DASHBOARD} element={<AdminDashboard  />}></Route>
            <Route path={PROF_DASHBOARD} element={<ProfDashboard  />}></Route>
            <Route path={LOGOUT} element={<Logout  />}></Route>
        </Routes>
    );
}

