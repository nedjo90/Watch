import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Offcanvas from 'react-bootstrap/Offcanvas';
import {
    ADMIN_DASHBOARD,
    PROFILE,
    HOME,
    LOGOUT,
    PROF_DASHBOARD,
    SIGN_IN,
    SIGN_UP
} from '../../routes/routespath.jsx';
import {DATA_BS_THEME} from '../../App.jsx';
import {useSelector} from 'react-redux';
import {getIsConnected} from '../../reducer/session/sessionselector.js';

export const NavBar = () =>
{
    const session = useSelector(({session}) => session);

    return (
        <Navbar expand="xxl" data-bs-theme={DATA_BS_THEME}
                className="bg-body-tertiary  sticky-top">
            <Container fluid>
                <Navbar.Brand href={HOME}>Watch</Navbar.Brand>
                <Navbar.Toggle
                    aria-controls={`offcanvasNavbar-expand-xxl`}/>
                <Navbar.Offcanvas
                    id="offcanvasNavbar-expand-xxl"
                    aria-labelledby="offcanvasNavbarLabel-expand-xxl"
                    placement="end"
                    data-bs-theme={DATA_BS_THEME}
                >
                    <Offcanvas.Header closeButton>
                        <Offcanvas.Title
                            id="offcanvasNavbarLabel-expand-xxl">
                            Watch Menu
                        </Offcanvas.Title>
                    </Offcanvas.Header>
                    <Offcanvas.Body>
                        {
                            session.isConnected ?
                                <Nav
                                    className="justify-content-end flex-grow-1 pe-3">
                                    {session.user.roles.includes('Candidate') ?
                                        <Nav.Link href={PROFILE}>Profile
                                        </Nav.Link> : <></>}
                                    {session.user.roles.includes('Professor') ?
                                        <Nav.Link href={PROF_DASHBOARD}>Professor
                                        </Nav.Link> : <></>}
                                    {session.user.roles.includes('Administrator') ?
                                        <Nav.Link href={ADMIN_DASHBOARD}>Administrator
                                        </Nav.Link> : <></>}
                                    <Nav.Link href={LOGOUT}>Logout
                                    </Nav.Link>
                                </Nav>
                                :
                                <Nav
                                    className="justify-content-end flex-grow-1 pe-3">
                                    <Nav.Link href={SIGN_IN}>Sign
                                        In</Nav.Link>
                                    <Nav.Link href={SIGN_UP}>Sign
                                        Up</Nav.Link>
                                </Nav>
                        }
                    </Offcanvas.Body>
                </Navbar.Offcanvas>
            </Container>
        </Navbar>);
};