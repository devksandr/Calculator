import { Navbar } from './Navbar'
import { Outlet } from 'react-router-dom'
import { Icon } from './components/Icon/Icon.jsx'
export function Layout() {
    return (
        <>
            <div className=''>
                <Icon />
                <Navbar />
            </div>

            <main>
                <Outlet/>
            </main>
        </>
    )
}