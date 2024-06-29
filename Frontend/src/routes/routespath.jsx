import {
    Route,
    Routes
} from 'react-router-dom';
import {Home} from '../components/home/home.jsx';
import {SignInForm} from '../components/authentication/signinform.jsx';
import {SignUpForm} from '../components/authentication/signupform.jsx';

export const SIGN_IN = "/authentication/signin"
export const SIGN_UP = "/authentication/signup"
export const HOME = "/"


export const RoutesPath = () => {
    return (
        <Routes>
            <Route path={HOME} element={<Home/>}></Route>
            <Route path={SIGN_IN} element={<SignInForm/>}></Route>
            <Route path={SIGN_UP} element={<SignUpForm/>}></Route>
        </Routes>
    );
}

