import {RoutesPath} from './Routes/routespath.jsx';
import {Navbar} from './components/general/navbar.jsx';
import {MyApp} from './styles/app-style.js';

function App()
{

    return (
        <MyApp>
            <Navbar/>
            <RoutesPath/>
        </MyApp>);
}

export default App;
