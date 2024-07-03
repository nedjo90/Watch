import axios from 'axios';

const baseUrl = 'https://localhost:7184/api';

const apiClient = axios.create({
                                   headers: {
                                       'Content-type': 'application/json'
                                   }
                               });

apiClient.interceptors.request.use(request =>
                                   {
                                       const accessToken = localStorage.getItem(
                                           'watchApiAccessToken');
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
                const refresh = localStorage.getItem('watchApiRefreshToken');
                const access = localStorage.getItem('watchApiAccessToken');
                console.log('refresh', refresh);
                console.log('access', access);
                const response = await axios.post(`${baseUrl}/token/refresh`, {
                    accessToken: access,
                    refreshToken: refresh
                });
                const {
                    accessToken,
                    refreshToken
                } = response.data;
                localStorage.setItem('watchApiAccessToken', accessToken);
                localStorage.setItem('watchApiRefreshToken', refreshToken);
                apiClient.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;
                originalRequest.headers['Authorization'] = `Bearer ${accessToken}`;
                return apiClient(originalRequest);
            }
            catch (refreshError)
            {
                console.log('Token refresh failed', refreshError);
                localStorage.removeItem('watchApiAccessToken');
                localStorage.removeItem('watchApiRefreshToken');
                return Promise.reject(refreshError);
            }
        }
        return Promise.reject(error);
    }
);

const getRoot = async () =>{
    return await apiClient.get(baseUrl);
}

const optionRoot = async () =>{
    return await apiClient.options(`${baseUrl}`);
}

const getDocument = async () =>
{
    return await apiClient.get(`${baseUrl}/document`);
};

const getRoles = async () =>
{
    return await apiClient.get(`${baseUrl}/user/roles`);
};

const getUserInfo = async () =>
{
    return await apiClient.get(`${baseUrl}/user`);
};

const getAllProfessionalStatus = async () =>
{
    const response = await axios.get(
        `${baseUrl}/professionalstatus`);
    return response.data;
};

export const createUser = async (body) =>
{
    return await axios.post(`${baseUrl}/authentication`, body);
};

export const login = async (body) =>
{
    const response = await axios.post(
        `${baseUrl}/authentication/login`, body
    );
    console.log('response data', response.data);
    localStorage.setItem('watchApiAccessToken', response.data.accessToken);
    localStorage.setItem('watchApiRefreshToken', response.data.refreshToken);
};

export default {
    getAllProfessionalStatus,
    createUser,
    login,
    getDocument,
    getRoles,
    getUserInfo,
    optionRoot
};