import './Operation.css'

function Operation({ setOperation, operations }) {

	function handleOperationChange(e) {
		setOperation(e.target.value);
	}

	const mystyle = {
		float: "left",
	};

	return (
		<>
			<div style={mystyle}>
				<label htmlFor="operation">Operation</label>
				<select
					onChange={(e) => setOperation(e.target.value)}
					className="operation block-params"
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
