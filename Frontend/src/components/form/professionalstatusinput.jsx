import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import {
    AsyncTypeahead,
    Typeahead
} from 'react-bootstrap-typeahead';
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
    getIsSubmit,
    getIsValidFullAddress,
    getListOfProfessionalStatus
} from '../../reducer/signup/signupselectors.js';
import LocalisationService from '../../services/localisation.js';
import {
    initializeProfessionalStatus,
    loadProfessionalStatus,
    setFullAddress,
    setProfessionalStatusId
} from '../../reducer/signup/signupreducer.js';
import WatchApiServices from '../../services/watchapi.js';
import {Dropdown} from 'react-bootstrap';

export const ProfessionalStatusInput = () =>
{
    const [isLoading, setIsLoading] = useState(false);
    const listOfProfessionalStatus = useSelector(getListOfProfessionalStatus);
    const dispatch = useDispatch();

    useEffect(() =>
              {
                  dispatch(initializeProfessionalStatus());
              }, []);

    const isSubmit = useSelector(getIsSubmit);
    return (<div>
        <Form.Group
            className={formStyles.formGroup}
            controlId="formBasicMunicipality">
            <Form.Label className={formStyles.formLabel}>Professional
                Status</Form.Label>
            <Form.Select className={formStyles.formTextInput}>
                {listOfProfessionalStatus.map((item) =>
                                              {
                                                  return (<option
                                                      key={item.id}
                                                      value={item.id}
                                                  >
                                                      {item.label}
                                                  </option>);
                                              })}
            </Form.Select>
        </Form.Group>
        <ErrorForm isValid={true} isSubmit={isSubmit}
                   message="Please select a professional status"></ErrorForm>
    </div>);
};