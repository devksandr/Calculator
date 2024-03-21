import './Param.css'

function Param({ setParam }) {

	const mystyle = {
		float: "left",
		marginRight : "20px"
	};

	return (
		<>
			<div style={mystyle}>
				<label htmlFor="param">Param</label>
				<input
					onChange={(e) => setParam(e.target.value)}
					className="param"
					name="param"
				/>
			</div>
		</>
	)
}

export default Param
