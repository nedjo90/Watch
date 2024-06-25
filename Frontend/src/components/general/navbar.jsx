import {
    AUTHENTICATION,
    HOME
} from '../../Routes/routespath.jsx';
import {
    MyLink,
    NavBar,
    NavBarLinks
} from '../../styles/navbar-style.js';
import {Link} from 'react-router-dom';
import {Logo} from './logo.jsx';

export const Navbar = () =>
{
    return (
        <NavBar>
            <Link to={HOME}>
                <Logo/>
            </Link>
            <NavBarLinks>
                <MyLink to={HOME}>
                    Home
                </MyLink>
                <MyLink to={AUTHENTICATION}>Login</MyLink>
            </NavBarLinks>
        </NavBar>
    );
};