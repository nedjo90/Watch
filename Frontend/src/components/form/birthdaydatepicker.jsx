import formStyles from '../../styles/form-styles.module.css';
import Form from 'react-bootstrap/Form';
import {ThemeProvider} from '@mui/material';
import {theme} from '../../styles/themedatepicker.js';
import {
    DatePicker,
    LocalizationProvider
} from '@mui/x-date-pickers';
import {AdapterDayjs} from '@mui/x-date-pickers/AdapterDayjs';
import dayjs from 'dayjs';
import React from 'react';
import {
    useDispatch,
    useSelector
} from 'react-redux';
import {
    setBirthday,
    dateNow
} from '../../reducer/signup/signupreducer.js';
import {ErrorForm} from './errorform.jsx';
import {
    getBirthday,
    getIsSubmit,
    getIsValidBirthday
} from '../../reducer/signup/signupselectors.js';

export const Birthdaydatepicker = () =>
{
    const dispatch = useDispatch();
    const isValidBirthday = useSelector(getIsValidBirthday);
    const isSubmit = useSelector(getIsSubmit);
    return (
        <div>
            <Form.Group className={formStyles.formGroup}>
                <Form.Label className={formStyles.formLabel}>
                    Birthday</Form.Label>
                <div>
                    <ThemeProvider theme={theme}>
                        <LocalizationProvider
                            dateAdapter={AdapterDayjs}>
                            <DatePicker
                                format="DD/MM/YYYY"
                                value={dayjs("01/01/2024", 'DD/MM/YYYY')}
                                onChange={(date) =>
                                {
                                    if (date && date.isValid())
                                    {
                                        dispatch(setBirthday(
                                            date.format('DD/MM/YYYY')));
                                    }
                                }}
                            />
                        </LocalizationProvider>
                    </ThemeProvider>
                </div>

            </Form.Group>
            <ErrorForm isValid={isValidBirthday}
                       isSubmit={isSubmit}
                       message="Please choose a valid date"></ErrorForm>
        </div>
    );
};