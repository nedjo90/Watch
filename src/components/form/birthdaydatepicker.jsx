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

export const Birthdaydatepicker = () =>{
    return(
        <Form.Group className={formStyles.formGroup}>
            <Form.Label className={formStyles.formLabel}>
                Birthday</Form.Label>
            <div>
                <ThemeProvider theme={theme}>
                    <LocalizationProvider
                        dateAdapter={AdapterDayjs}>
                        <DatePicker
                            value={dayjs('2022-04-17')}
                            onChange={() => {}}
                        />
                    </LocalizationProvider>
                </ThemeProvider>
            </div>
        </Form.Group>
    );
}