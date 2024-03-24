import icon from '../../assets/calc-icon-white.png';
import './Icon.css'

export function Icon() {
    return (
        <>
            <img src={icon} className='logo' draggable="false" />
        </>
    )
}

export default Icon;