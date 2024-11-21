import React from 'react';
import Routes from './routes';
import { AuthProvider } from './context/AuthContext';

const App = () => (
    <AuthProvider>
        <Routes />
    </AuthProvider>
);

export default App;