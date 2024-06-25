import {
    Route,
    Routes
} from 'react-router-dom';
import {Home} from '../components/home/home.jsx';
import {Login} from '../components/authentication/login.jsx';

export const AUTHENTICATION = "/authentication"
export const HOME = "/home"


export const RoutesPath = () => {
    return (
        <Routes>
            <Route path={HOME} element={<Home/>}></Route>
            <Route path={AUTHENTICATION} element={<Login/>}></Route>
        </Routes>
    );
}

