import './Operation.css'

function Operation({ setOperation, operations }) {

	function handleOperationChange(e) {
		setOperation(e.target.value);
	}

	return (
		<>
			<select
				onChange={(e) => setOperation(e.target.value)}
			>
				{operations.map((operation, index) => (
					<option key={index} value={operation.alias}>{operation.sign}</option>
				))}
			</select>
		</>
	)
}

export default Operation
