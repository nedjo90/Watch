import dayjs from 'dayjs';

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
    return email.match('[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+.[a-zA-Z.]{2,15}');
};

export const isValidPassword = (password) =>
{
    return password.match('/^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{10,}$/;');
};
export const isValidBirthday = (date) =>
{

    return dayjs(date, 'DD/MM/YYYY').isValid();
};