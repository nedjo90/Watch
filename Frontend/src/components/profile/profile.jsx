import {
    useEffect,
    useState
} from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {useNavigate} from 'react-router-dom';
import {
    initializeSession,
    setNewAddress,
    setNewFirstName,
    setNewLastName
} from '../../reducer/session/sessionReducer.js';
import styles from '../../styles/profile-style.module.css';
import {Button} from 'react-bootstrap';
import ItemProfile from './item.jsx';
import ItemAddress from './itemaddress.jsx';
import ItemProfessionalStatus from './itemprofessionalstatus.jsx';

const Profile = () =>
{
    const [updateMode, setUpdateMode] = useState(false);
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const session = useSelector(({session}) => session);

    useEffect(() =>
              {
                  dispatch(initializeSession());
              }, []);

    const handleUpdate = () =>
    {
        setUpdateMode(true);
    };

    const handleCancel = () =>
    {
        setUpdateMode(false);
    };

    const handleAddressChange = (select) =>
    {
        if (select.length === 1)
            dispatch(setNewAddress(select[0]));
    };

    const handleFirstnameChange = (newFirstname) =>
    {
        dispatch(setNewFirstName(newFirstname));
    };

    const handleLastnameChange = (newLastname) =>
    {
        dispatch(setNewLastName(newLastname));
    };

    const handleProfessionalStatusChange = (newProfessionalStatusId) =>
    {
        dispatch(setNewFirstName(newProfessionalStatusId.target.value));
    };

    return <div className={styles.main}>
        <h1 className={styles.title}>Welcome {session.user.username}</h1>
        <ul className={styles.list}>
            <ItemProfile name="firstname" keyName="Firstname"
                         value={session.user.firstName} updateValue={session.userForUpdate.firstName} isUpdate={updateMode} handleChange={handleFirstnameChange}/>
            <ItemProfile name="lastname" keyName="Lastname"
                         value={session.user.lastName} updateValue={session.userForUpdate.lastName} isUpdate={updateMode} handleChange={handleLastnameChange}/>
            <ItemAddress name="address" keyName="Address"
                         value={`${session.user.address} ${session.user.city} ${session.user.country}`}
                         updateValue={`${session.userForUpdate.address} ${session.userForUpdate.city} ${session.userForUpdate.country}`}
                         isUpdate={updateMode}
                         handleSelect={handleAddressChange}/>
            <ItemProfessionalStatus name="professionalStatus"
                                    keyName="Professional Status"
                                    value={session.user.professionalStatus}
                                    updateValue={session.userForUpdate.professionalStatusId}
                                    isUpdate={updateMode}
                                    handleSelect={handleProfessionalStatusChange}
            />
        </ul>
        {!updateMode ?
            <div className={styles.buttonContainer}>
                <Button className={styles.button}
                        onClick={handleUpdate}>Update</Button>

            </div>
            :
            <div className={styles.buttonContainer}>
                <Button className={styles.button}>Save</Button>
                <Button className={styles.button}
                        onClick={handleCancel}>Cancel</Button>
            </div>
        }
    </div>;
};

export default Profile;