import './Calculation.css'

function Calculation({ handleCalculatorRequest }) {
	return (
		<>
			<div className="calculator-field-container">
				<button
					className='calculator-field-data calculation-block center-element'
					onClick={handleCalculatorRequest}
				>
					=
				</button>
			</div>
		</>
	)
}

export default Calculation
