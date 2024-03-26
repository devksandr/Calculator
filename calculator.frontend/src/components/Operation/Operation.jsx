import './Operation.css'

function Operation({ setOperation, operations, onChanged }) {
	return (
		<>
			<div className="calculator-field-container">
				<label htmlFor="operation">Operation</label>
				<select
					onChange={(e) => {
						setOperation(e.target.value);
						onChanged();
					}}
					className="calculator-field-data operation-block"
					name="operation"
				>
					{operations.map((operation, index) => (
						<option key={index} value={operation.alias}>{operation.sign}</option>
					))}
				</select>
			</div>
		</>
	)
}

export default Operation
