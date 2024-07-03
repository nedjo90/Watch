import styles from '../../styles/profile-style.module.css';
import formStyles from '../../styles/form-styles.module.css';
import {AsyncTypeahead} from 'react-bootstrap-typeahead';
import React, {useState} from 'react';
import LocalisationService from '../../services/localisation.js';

const ItemAddress = ({name, keyName, value, updateValue, isUpdate, handleSelect}) =>
{
    const [isLoading, setIsLoading] = useState(false);
    const [options, setOptions] = useState([]);

    const handleSearch = (search) =>
    {

        setIsLoading(true);

        LocalisationService.getFullAddress(search)
        .then((data) =>
              {
                  console.log(data);
                  const arr = data.features.map(city =>
                                                {
                                                    return {
                                                        label: city.properties.label,
                                                        city: city.properties.city,
                                                        address: city.properties.name,
                                                        postcode: city.properties.postcode
                                                    };
                                                });
                  setOptions(arr);
                  setIsLoading(false);
              })
        .catch((error) =>
               {
                   console.error('Error fetching data:', error);
                   setIsLoading(false);
               });
    };

    const filterBy = () => true;
    return (
        <div className={styles.item}>
            <label htmlFor={name}>{keyName}:</label>
            {!isUpdate ? <p>{value}</p> :
                <AsyncTypeahead
                    className={`typeahead-container ${styles.address}`}
                    defaultInputValue={updateValue}
                    filterBy={filterBy}
                    onChange={handleSelect}
                    id="async-search"
                    isLoading={isLoading}
                    labelKey="label"
                    minLength={3}
                    onSearch={handleSearch}
                    options={options}
                    placeholder="Start to type your full address..."
                    renderMenuItemChildren={(option) => (<>
                        <div>
                            <span>{option.label}</span>
                        </div>
                    </>)}
                />}
        </div>
    );
};

export default ItemAddress;