import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import {AsyncTypeahead} from 'react-bootstrap-typeahead';
import React, {useState} from 'react';
import {ErrorForm} from './errorform.jsx';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {getIsSubmit} from '../../reducer/signup/signupselectors.js';
import LocalisationService from '../../services/localisation.js';
import {setFullAddress} from '../../reducer/signup/signupreducer.js';

export const FullAddressInput = () =>
{
    const [isLoading, setIsLoading] = useState(false);
    const [options, setOptions] = useState([]);
    const dispatch = useDispatch();

    const handleSearch = (search) =>
    {

        setIsLoading(true);

        LocalisationService.getCity(search)
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

    const handleSelect = (selected) =>
    {
        if (selected.length === 1)
        {
            dispatch(setFullAddress(selected[0]));
        }
    };

    const isSubmit = useSelector(getIsSubmit);
    const filterBy = () => true;

    return (<div>
            <Form.Group
                className={formStyles.formGroup}
                controlId="formBasicMunicipality">
                <Form.Label className={formStyles.formLabel}>Full
                    Address</Form.Label>
                <AsyncTypeahead
                    className={`typeahead-container ${formStyles.formTextInput}`}
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
                />
            </Form.Group>
            <ErrorForm isValid={true} isSubmit={isSubmit}
                       message="This address does not exist or in invalid format"></ErrorForm>
        </div>);
};