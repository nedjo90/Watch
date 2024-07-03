import styles from '../../styles/profile-style.module.css';
import {
    useEffect,
    useState
} from 'react';
import WatchApiServices from '../../services/watchapi.js';

const ItemProfessionalStatus = ({
                                    name,
                                    keyName,
                                    value,
                                    updateValue,
                                    isUpdate,
                                    handleSelect
                                }) =>
{
    const [options, setOptions] = useState([]);
    useEffect(() =>
              {
                  WatchApiServices.getAllProfessionalStatus()
                  .then(data =>
                        {
                            setOptions(data);
                            console.log(options);
                        }
                  );
              }, []);

    return (
        <div className={styles.item}>
            <label htmlFor={name}>{keyName}:</label>
            {!isUpdate ? <p>{value}</p> :
                <select name={name} id="" onChange={handleSelect} value={updateValue}>
                    <option value="" disabled>Please select a professional
                        status
                    </option>
                    {
                        options.map(opt =>
                                        <option key={opt.id}
                                                value={opt.id}>{opt.label}</option>
                        )
                    }
                </select>}
        </div>
    );
};

export default ItemProfessionalStatus;