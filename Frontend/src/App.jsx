import {RoutesPath} from './Routes/routespath.jsx';
import {NavBar} from './components/general/navbar.jsx';

//bootstrap constant
export const BG = 'dark';
export const DATA_BS_THEME = 'dark';
export const VARIANT = 'primary';

function App()
{

    return (
        <div>
            <NavBar></NavBar>
            <div
                className={`bg-${BG} text-light`} style={{maxWidth: '100%', minHeight: "100vh"}}>
                <RoutesPath/>
            </div>
        </div>
    );
}

export default App;