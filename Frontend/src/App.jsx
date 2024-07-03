import {RoutesPath} from './routes/routespath.jsx';
import {NavBar} from './components/general/navbar.jsx';
import {useEffect} from 'react';
import {
    checkConnection,
    initializeConnexion
} from './reducer/session/sessionReducer.js';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {
    getIsConnected,
    getIsNotConnected
} from './reducer/session/sessionselector.js';

export const BG = 'dark';
export const DATA_BS_THEME = 'dark';
export const VARIANT = 'primary';

function App()
{
    const isConnected = useSelector(getIsConnected);
    const isNotConnected = useSelector(getIsNotConnected);

    const dispatch = useDispatch();
    useEffect(() =>
              {
                  dispatch(initializeConnexion());
              }, [isConnected, isNotConnected]);

    return (<div style={{
        width: '100vw',
        minHeight: '100vh'
    }}>
        <NavBar></NavBar>
        <div
            className={`bg-${BG} text-light`} style={{
            maxWidth: '100vw',
            minHeight: '100vh'
        }}>
            <RoutesPath isConnected={isConnected}/>
        </div>
    </div>);
}

export default App;
