import styles from '../../styles/profile-style.module.css';

const ItemProfile = ({name, keyName, value, updateValue, isUpdate, handleChange}) =>
{
    return (
        <div className={styles.item}>
        <label htmlFor={name}>{keyName}:</label>
        {!isUpdate ? <p>{value}</p> :
            <input type="text" value={updateValue} onChange={(event) => handleChange(event.target.value)}/>}
    </div>
    );
};

export default ItemProfile;