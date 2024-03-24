import './Param.css'

function Param({ param, setParam, index }) {

	const mystyle = {
		float: "left",
	};

	const inputClasses = param.isValid ? 'param block-params' : 'param block-params invalid';

	return (
		<>
			<div style={mystyle}>
				<label htmlFor="param">Parameter {index}</label>
				<input
					onChange={(e) => setParam({
						data: e.target.value,
						isValid: true
					})}
					className={inputClasses}
					name="param"
					autoComplete="off"
				/>
			</div>
		</>
	)
}

export default Param
