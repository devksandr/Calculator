import './Operation.css'

function Operation({ setOperation }) {

	function handleOperationChange(e) {
		setOperation(e.target.value);
	}

	return (
		<>
			<select></select>
		</>
	)
}

export default Operation
