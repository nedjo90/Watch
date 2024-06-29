import {RoutesPath} from './routes/routespath.jsx';
import {NavBar} from './components/general/navbar.jsx';

//bootstrap constant
export const BG = 'dark';
export const DATA_BS_THEME = 'dark';
export const VARIANT = 'primary';

function App()
{

    return (
        <div style={{width: '100vw', minHeight: "100vh"}}>
            <NavBar></NavBar>
            <div
                className={`bg-${BG} text-light`} style={{maxWidth: '100vw', minHeight: "100vh"}}>
                <RoutesPath/>
            </div>
        </div>
    );
}

export default App;
