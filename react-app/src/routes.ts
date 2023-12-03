import Home from './pages/Home';
import Users from './pages/Users';
import Resources from './pages/Resources';

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
]
   