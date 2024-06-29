import dayjs from 'dayjs';
import {current} from '@reduxjs/toolkit';

export const isValidUsername = (username) =>
{
    return username.match(
        /^[a-zA-Z0-9]+$/) && username.length >= 2 && username.length <= 50;
};

export const isValidFirstName = (firstName) =>
{
    return firstName.match(
        /^[a-zA-Z]+$/) && firstName.length >= 2 && firstName.length <= 50;
};
export const isValidLastName = (lastName) =>
{
    return lastName.match(
        /^[a-zA-Z]+$/) && lastName.length >= 2 && lastName.length <= 50;
};
export const isValidEmail = (email) =>
{
    const regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,15}$/;
    const test = email.match(regex);
    return !!test;
};

export const isValidPassword = (password) =>
{
    const test = password.match(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/);
    return !!test;
};
export const isValidBirthday = (date) =>
{
    return dayjs(date, 'DD/MM/YYYY')
    .isValid();
};

export const isValidProfessionalStatusId = (list, id) =>
{
    console.log('list', list);
    console.log('id', id);
    return !!(id !== '0' && list.find(pro => pro.id === id));
};

export const isValidFullAddress = (fullAddress) =>
{
    return fullAddress.address.length > 0
        && fullAddress.city.length > 0
        && fullAddress.postcode.length > 0
        && fullAddress.country.length > 0;
};

export const allInputAreValid = (signUp) =>
{
    return (signUp.isValidUsername
        && signUp.isValidEmail
        && signUp.isSameEmail
        && signUp.isValidPassword
        && signUp.isSamePassword
        && signUp.isValidFirstName
        && signUp.isValidLastName
        && signUp.isValidBirthday
        && signUp.isValidFullAddress
        && signUp.isValidProfessionalStatusId
    );
};