import {TestDiv} from '../../styles/test-style.js';
import {
    H1,
    P
} from '../../styles/generic-style.js';
import {HomePage} from '../../styles/home-style.js';
import {Link} from 'react-router-dom';
import {HOME} from '../../Routes/routespath.jsx';
import {MyLink} from '../../styles/navbar-style.js';

export const Home = () => {
    return (
        <HomePage>
            <MyLink to={HOME}>
                <H1>Watch</H1>
            </MyLink>
            <P>Gérer facilement votre centre de formation</P>
        </HomePage>
    );
}