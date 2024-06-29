import axios from 'axios';

const baseUrl = 'http://localhost:5117/api/';

const getAllProfessionalStatus = async () =>
{
    const response = await axios.get(
        `${baseUrl}professionalstatus`);
    return response.data;
};

export const createUser = async (body) =>
{
    return await axios.post(`${baseUrl}authentication`, body);
};

export const login = async (body) =>{
    return await axios.post(
        `${baseUrl}authentication/login`, body
    )
}

export default {
    getAllProfessionalStatus,
    createUser,
    login
};