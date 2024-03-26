import './Param.css'

function Param({ param, setParam, onChanged, index }) {
	const inputClasses = param.isValid ? 'calculator-field-data' : 'calculator-field-data invalid';

	return (
		<>
			<div className="calculator-field-container">
				<label htmlFor="param">Parameter {index}</label>
				<input
					onChange={(e) => {
						setParam({
							data: e.target.value,
							isValid: true
						});
						onChanged();
					}}
					className={inputClasses}
					name="param"
					autoComplete="off"
				/>
			</div>
		</>
	)
}

export default Param
