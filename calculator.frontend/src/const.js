import { BACKEND_URI } from './config.js'

export const API_URI = `${BACKEND_URI}/api`; // 'https://localhost:7160/api';

export const MENU = {
    calculator: { address: '/', name: 'Calculator' },
    history: { address: '/history', name: 'History' }
};