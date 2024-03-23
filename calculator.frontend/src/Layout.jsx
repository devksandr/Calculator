import { useState, useEffect } from 'react'
import { Navbar } from './Navbar'
import { Outlet } from 'react-router-dom'
import { Icon } from './components/Icon/Icon.jsx'

export function Layout() {

    const [loading, setLoading] = useState({
        preloader: true,
        data: false,
        message: ''
    });

    return (
        <>
            <div className=''>
                <Icon />
                <Navbar />
            </div>

            <main>
                <Outlet context={[loading, setLoading]} />
            </main>
        </>
    )
}