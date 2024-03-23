import { useState, useEffect } from 'react'
import axios from 'axios'
import { useOutletContext } from "react-router-dom";
import Param from '../components/Param/Param.jsx'
import Operation from '../components/Operation/Operation.jsx'
import { API_URI, CONNECTION_ERROR_MESSAGES } from '../scripts/const.js'
import { Preloader } from '../components/Preloader/Preloader.jsx'
import { getConnectionErrorByStatus } from '../scripts/func.js'

export function Home({ header }) {
	const [loading, setLoading] = useOutletContext();

	const [param1, setParam1] = useState(0);
	const [param2, setParam2] = useState(0);
	const [operation, setOperation] = useState('');
	const [operations, setOperations] = useState([]);

	useEffect(() => {
		handleGetAllOperationsRequest();
	}, []);

	function handleGetAllOperationsRequest() {
		axios.get(`${API_URI}/Operation`)
			.then(function (response) {
				let operations = response.data;
				if (Array.isArray(operations) && operations.length > 0) {
					setOperation(operations[0].alias)
					setOperations(operations);
				}

				setLoading({
					preloader: false,
					data: true,
					message: operations.length > 0 ? '' : CONNECTION_ERROR_MESSAGES.defaultData
				});
			})
			.catch(function (error) {
				setLoading({
					preloader: false,
					data: false,
					message: getConnectionErrorByStatus(error.code)
				});
			});
	}

	function handleCalculatorRequest() {
		var body = {
			param1: param1,
			param2: param2,
			operationType: operation
		};

		axios.post(`${API_URI}/Operation`, body)
			.then(function (response) {
				console.log(response);
			})
			.catch(function (error) {
				console.log(error);
			});

	}

	return (
		<>
			<h1>{header}</h1>
			{
				!loading.data || loading.message ?
					<p>{loading.message}</p> :
					<div>
						<Param setParam={setParam1} />
						<Operation setOperation={setOperation} operations={operations} />
						<Param setParam={setParam2} />

						<button onClick={handleCalculatorRequest}>
							Calculate
						</button>
					</div>
			}
			
			<Preloader state={loading.preloader} />
		</>
	)
}