import axios from 'axios';

const getCity = async (search) =>
{
    const searchTerm = search.replace(' ', '%20');
    const response = await axios.get(
        `https://api-adresse.data.gouv.fr/search/?q=${searchTerm}&type=&autocomplete=1`);
    return response.data;
};

export default {
    getCity
};