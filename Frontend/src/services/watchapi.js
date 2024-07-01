import axios from 'axios';

const baseUrl = 'https://localhost:7184/api/';

const apiClient = axios.create({
                                   headers: {
                                       'Content-type': 'application/json'
                                   }
                               });

apiClient.interceptors.request.use(request =>
                                   {
                                       const accessToken = localStorage.getItem(
                                           'accessToken');
                                       if (accessToken)
                                       {
                                           request.headers['Authorization'] = `Bearer ${accessToken}`;
                                       }
                                       return request;
                                   }, error =>
                                   {
                                       return Promise.reject(error);
                                   }
);

apiClient.interceptors.response.use(
    response => response,
    async error =>
    {
        const originalRequest = error.config;
        if (error.response.status === 401 && !originalRequest._retry)
        {
            originalRequest._retry = true;
            try
            {
                const refresh = localStorage.getItem('refreshToken');
                const access = localStorage.getItem('accessToken');
                console.log('refresh', refresh);
                console.log('access', access);
                const response = await axios.post(`${baseUrl}token/refresh`, {
                    accessToken: access,
                    refreshToken: refresh
                });
                const {
                    accessToken,
                    refreshToken
                } = response.data;
                localStorage.setItem('accessToken', accessToken);
                localStorage.setItem('refreshToken', refreshToken);
                apiClient.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;
                return apiClient(originalRequest);
            }
            catch (refreshError)
            {
                console.log('Token refresh failed', refreshError);
                localStorage.removeItem('accessToken');
                localStorage.removeItem('refreshToken');
                return Promise.reject(refreshError);
            }
        }
        return Promise.reject(error);
    }
);

const getDocument = async () =>
{
    return await apiClient.get(`${baseUrl}document`);
};

const getRoles = async () =>
{
    return await apiClient.get(`${baseUrl}user/roles`);
};

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

export const login = async (body) =>
{
    const response = await axios.post(
        `${baseUrl}authentication/login`, body
    );
    console.log('response data', response.data);
    localStorage.setItem('accessToken', response.data.accessToken);
    localStorage.setItem('refreshToken', response.data.refreshToken);
};

export default {
    getAllProfessionalStatus,
    createUser,
    login,
    getDocument
};