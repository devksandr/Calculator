import './Result.css'

function Result({ result }) {
	return (
		<>
			<div className="calculator-field-container">
				<p className='result-header'>Result</p>
				<p className='calculator-field-data result-block center-element'>{result}</p>
			</div>
		</>
	)
}

export default Result
