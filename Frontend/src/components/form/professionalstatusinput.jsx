import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import React, {
    useEffect,
    useState
} from 'react';
import {ErrorForm} from './errorform.jsx';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {
    getProfessionalStatusId,
    getIsSubmit,
    getIsValidProfessionalStatusId,
    getListOfProfessionalStatus
} from '../../reducer/signup/signupselectors.js';
import {
    initializeProfessionalStatus,
    setProfessionalStatusId
} from '../../reducer/signup/signupreducer.js';

export const ProfessionalStatusInput = () =>
{
    const listOfProfessionalStatus = useSelector(getListOfProfessionalStatus);
    const isValidProfessionalStatusId = useSelector(
        getIsValidProfessionalStatusId);
    const isSubmit = useSelector(getIsSubmit);
    const professionalStatusId = useSelector(getProfessionalStatusId)
    const dispatch = useDispatch();

    useEffect(() =>
              {
                  dispatch(initializeProfessionalStatus());
              }, []);
    const handleSelect = (selected) => {
        dispatch(setProfessionalStatusId(selected.target.value))
    }

    return (<div>
        <Form.Group
            className={formStyles.formGroup}
            controlId="formBasicMunicipality">
            <Form.Label className={formStyles.formLabel}>Professional
                Status</Form.Label>
            <Form.Select className={formStyles.formTextInput}
                         onChange={handleSelect} value={professionalStatusId}
                         defaultValue={professionalStatusId}
            >
                {listOfProfessionalStatus.map((item) => item.id === '0' ?
                    <option
                        key={item.id}
                        value={item.id}
                    >
                        {item.label}
                    </option>
                    : <option
                        key={item.id}
                        value={item.id}
                    >
                        {item.label}
                    </option>
                )}
            </Form.Select>
        </Form.Group>
        <ErrorForm isValid={isValidProfessionalStatusId} isSubmit={isSubmit}
                   message="Please select a professional status"></ErrorForm>
    </div>);
};