import axios from 'axios';

const baseUrl = 'http://localhost:5117/api/';

const getAllProfessionalStatus = async () =>
{
    const response = await axios.get(
        `${baseUrl}professionalstatus`);
    return response.data;
};

export default {
    getAllProfessionalStatus
};