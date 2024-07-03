import Form from 'react-bootstrap/Form';
import React, {
    useEffect,
    useState
} from 'react';
import {Button} from 'react-bootstrap';
import {VARIANT} from '../../App.jsx';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import formStyles from '../../styles/form-styles.module.css';
import {
    PROFILE,
    HOME,
    SIGN_IN,
    SIGN_UP
} from '../../routes/routespath.jsx';
import {
    setConnectionFailed,
    setLoginPassword,
    setLoginUsername,
    submitLogin
} from '../../reducer/signin/signinreducer.js';
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {
    faEyeSlash,
    faEye
} from '@fortawesome/fontawesome-free-solid';
import {ErrorForm} from '../form/errorform.jsx';
import {useNavigate} from 'react-router-dom';
import Watchapi from '../../services/watchapi.js';
import {setIsConnected} from '../../reducer/session/sessionReducer.js';

export const SignInForm = () =>
{
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const [hidePassword, setHidePassword] = useState(true);
    const data = useSelector((({signIn}) => signIn));

    useEffect(
        () =>
        {
            if (data.isSubmit && data.allInputAreValid)
            {
                const dataForApi = {
                    username: data.username,
                    password: data.password
                };
                Watchapi.login(dataForApi)
                .then(response =>
                      {
                          dispatch(setIsConnected())
                          navigate(HOME);
                          console.log("success",response);
                      })
                .catch(
                    error =>
                    {
                        dispatch(setConnectionFailed());
                        console.log("fail",error);
                    }
                );
            }
        },
        [dispatch, navigate, data.isSubmit, data.allInputAreValid, data.password, data.username, data.isValidUsername, data.isValidPassword]);

    const handleUsername = (event) =>
    {
        event.preventDefault();
        dispatch(setLoginUsername(event.target.value));
    };
    const handlePassword = (event) =>
    {
        event.preventDefault();
        dispatch(setLoginPassword(event.target.value));
    };

    const handleSubmit = () =>
    {
        dispatch(submitLogin());
    };

    return (<div className={formStyles.formSignInContainer}>
        <div className={formStyles.formTitle}>
            <h1>Authentication</h1>
            <div>Don't have an account? <a href={SIGN_UP}>Sign Up</a></div>
        </div>
        <Form className={formStyles.form}>
            <div>
                <Form.Group className={formStyles.formGroup}
                            controlId="formBasicUsername">
                    <Form.Label
                        className={formStyles.formLabel}>Username</Form.Label>
                    <Form.Control onChange={handleUsername}
                                  className={formStyles.formTextInput}
                                  value={data.username}
                                  type="username"
                                  placeholder="Enter Username"/>
                </Form.Group>
                <ErrorForm isValid={data.isValidUsername}
                           isSubmit={data.isSubmit}
                           message={data.errorUsernameMessage}></ErrorForm>
            </div>
            <div>
                <Form.Group className={formStyles.formGroup}
                            controlId="formBasicPassword">
                    <Form.Label
                        className={formStyles.formLabel}>Password</Form.Label>
                    <div
                        style={{position: 'relative'}}
                    >
                        <Form.Control
                            className={formStyles.formTextInput}
                            value={data.password} onChange={handlePassword}
                            placeholder="password"
                            type={hidePassword ? 'password' : 'text'}>
                        </Form.Control>
                        <FontAwesomeIcon className={formStyles.passwordIcon}
                                         onClick={() =>
                                         {
                                             setHidePassword(!hidePassword);
                                         }}
                                         icon={hidePassword ? 'eye-slash' : 'eye'}/>
                    </div>
                </Form.Group>
                <ErrorForm isValid={data.isValidPassword}
                           isSubmit={data.isSubmit}
                           message={data.errorPasswordMessage}></ErrorForm>
            </div>
            <Button className={formStyles.formButton} variant={VARIANT}
                    onClick={handleSubmit}
            >Sign In
            </Button>
            <ErrorForm isValid={data.isConnectionFailed}
                       isSubmit={data.isSubmit}
                       message={data.errorConnectionMessage}></ErrorForm>
        </Form>
    </div>);
};
