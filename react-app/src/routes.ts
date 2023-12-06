import Home from './pages/Home';
import Users from './pages/Users';
import Resources from './pages/Resources';
import Login from './pages/Login';
import Registration from './pages/Registration';



import {FC} from 'react';

interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<{}>
}

export const routes: Array<Route> = [
    {
        key: 'home-route',
        title: 'Home',
        path: '/',
        enabled: true,
        component: Home
    },
    {
        key: 'users-route',
        title: 'Users',
        path: '/Users',
        enabled: true,
        component: Users
    },
    {
        key: 'resources-route',
        title: 'Resources',
        path: '/Resources',
        enabled: true,
        component: Resources
    },
    {
        key: 'login-route',
        title: 'Login',
        path: '/Login',
        enabled: true,
        component: Login
    },
    {
        key: 'register-route',
        title: 'Registration',
        path: '/Registration',
        enabled: true,
        component: Registration
    }
]
   