import { Ripple } from 'react-preloaders';

export function Preloader({ state }) {
    return (
        <>
            <Ripple
                customLoading={state}
                color="white"
                background="#242424"
			/>
        </>
    )
}

export default Preloader;