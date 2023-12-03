import apiClient from './client';

export const getUsers = (page: number) => apiClient({
    path: `users?page=${page}`,
    method: 'GET'
})