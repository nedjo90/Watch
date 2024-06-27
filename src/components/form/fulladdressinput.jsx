import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import {AsyncTypeahead} from 'react-bootstrap-typeahead';
import React from 'react';

export const FullAddressInput = ({options, isLoading, handleSearch, handleChange}) =>{

    const filterBy = () => true;

    return(
        <Form.Group
            className={formStyles.formGroup}
            controlId="formBasicMunicipality">
            <Form.Label className={formStyles.formLabel}>Full
                Address</Form.Label>
            <AsyncTypeahead
                className={`typeahead-container ${formStyles.formTextInput}`}
                filterBy={filterBy}
                onChange={handleChange}
                id="async-search"
                isLoading={isLoading}
                labelKey="postcode"
                minLength={3}
                onSearch={handleSearch}
                options={options}
                placeholder="Start to type your full address..."
                renderMenuItemChildren={(option) => (<>
                    <div>
                        <span>{option.city}</span>
                        <span> {option.postcode}</span>
                    </div>
                </>)}
            />
        </Form.Group>
    );
}