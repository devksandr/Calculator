import './Param.css'

function Param({ setParam }) {
	return (
		<>
			<input onChange={(e) => setParam(e.target.value)} />
		</>
	)
}

export default Param
