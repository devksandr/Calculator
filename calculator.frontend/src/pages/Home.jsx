import { useState, useEffect } from 'react'
import './Home.css'
import axios from 'axios'
import { useOutletContext } from "react-router-dom";
import Param from '../components/Param/Param.jsx'
import Operation from '../components/Operation/Operation.jsx'
import { API_URI, CONNECTION_ERROR_MESSAGES } from '../scripts/const.js'
import { Preloader } from '../components/Preloader/Preloader.jsx'
import { getConnectionErrorByStatus, isNumeric } from '../scripts/func.js'

export function Home({ header }) {

	const [loading, setLoading] = useOutletContext();

	const [param1, setParam1] = useState({ data: '', isValid: true });
	const [param2, setParam2] = useState({ data: '', isValid: true });
	const [operation, setOperation] = useState('');
	const [operations, setOperations] = useState([]);

	useEffect(() => {
		handleGetAllOperationsRequest();

		//setInterval(() => console.log(new Date()), 10000); // check server ping
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

		if (!paramsValidation()) {
			return;
		}

		var body = {
			param1: param1.data,
			param2: param2.data,
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

	function paramsValidation() {
		let validationStatus = true;

		if (!isNumeric(param1.data)) {
			validationStatus = false;
			setParam1({
				...param1,
				isValid: false
			});
		}

		if (!isNumeric(param2.data)) {
			validationStatus = false;
			setParam2({
				...param2,
				isValid: false
			});
		}

		return validationStatus;
	}

	const isParamsValid = () => isNumeric(param1.data) && isNumeric(param2.data);

	return (
		<>
			<h1>{header}</h1>
			{
				!loading.data || loading.message ?
					<p>{loading.message}</p> :
					<div className="container-params">
						<Param param={param1} setParam={setParam1} index={1} />
						<Operation setOperation={setOperation} operations={operations} />
						<Param param={param2} setParam={setParam2} index={2} />

						<button onClick={handleCalculatorRequest}>
							Calculate
						</button>
					</div>
			}
			
			<Preloader state={loading.preloader} />
		</>
	)
}