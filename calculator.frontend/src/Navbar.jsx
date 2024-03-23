import { Link } from 'react-router-dom'
import { MENU } from './scripts/const.js'

export function Navbar() {
    return (
        <>
            <Link
                to={MENU.calculator.address}
                state={{ pageName: MENU.calculator.name }}
            >
                <button>{MENU.calculator.name}</button>
            </Link>
            <Link
                to={MENU.history.address}
                state={{ pageName: MENU.history.name }}
            >
                <button>{MENU.history.name}</button>
            </Link>
        </>
    )
}