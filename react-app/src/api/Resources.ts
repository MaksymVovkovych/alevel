import apiClient from './client';

export const getResources = (page: number) => apiClient({
    path: `unknown?page=${page}`,
    method: 'GET'
})