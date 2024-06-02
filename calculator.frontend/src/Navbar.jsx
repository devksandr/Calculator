import './Navbar.css'
import { NavLink } from 'react-router-dom'
import { MENU } from './const.js'

export function Navbar() {
    return (
        <>
            <NavLink
                to={MENU.calculator.address}
                state={{ pageName: MENU.calculator.name }}
                className={({ isActive }) => isActive ? "active-navbar-item" : ""}
                draggable="false"
            >
                <button>{MENU.calculator.name}</button>
            </NavLink>
            <NavLink
                to={MENU.history.address}
                state={{ pageName: MENU.history.name }}
                className={({ isActive }) => isActive ? "active-navbar-item" : ""}
                draggable="false"
            >
                <button>{MENU.history.name}</button>
            </NavLink>
        </>
    )
}