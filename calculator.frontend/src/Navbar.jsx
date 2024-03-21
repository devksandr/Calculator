import { Link } from 'react-router-dom'

export function Navbar() {
    return (
        <>
            <Link to='/'>
                <button>Calculator</button>
            </Link>
            <Link to='/history'>
                <button>History</button>
            </Link>
        </>
    )
}