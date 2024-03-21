import { useState, useEffect } from 'react'
import axios from 'axios'
import Param from '../components/Param/Param.jsx'
import Operation from '../components/Operation/Operation.jsx'

export function Home() {
	const apiURI = 'https://localhost:7160/api';

	const [param1, setParam1] = useState(0);
	const [param2, setParam2] = useState(0);
	const [operation, setOperation] = useState('');
	const [operations, setOperations] = useState([]);

	useEffect(() => {
		handleGetAllOperationsRequest();
	}, []);

	function handleGetAllOperationsRequest() {
		axios.get(`${apiURI}/Operation`)
			.then(function (response) {
				let operations = response.data;
				if (Array.isArray(operations) && operations.length > 0) {
					setOperation(operations[0].alias)
					setOperations(operations);
				}
				console.log(operations);
			})
			.catch(function (error) {
				console.log(error);
			});
	}

	function handleCalculatorRequest() {
		var body = {
			param1: param1,
			param2: param2,
			operationType: operation
		};

		axios.post(`${apiURI}/Operation`, body)
			.then(function (response) {
				console.log(response);
			})
			.catch(function (error) {
				console.log(error);
			});

	}

	return (
		<>
			<h1>Calculator</h1>
			<div>
				<Param setParam={setParam1} />
				<Operation setOperation={setOperation} operations={operations} />
				<Param setParam={setParam2} />

				<button onClick={handleCalculatorRequest}>
					Calculate
				</button>
			</div>
		</>
	)
}