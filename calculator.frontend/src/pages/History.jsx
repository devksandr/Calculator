import { useState, useEffect } from 'react'
import axios from 'axios'
import { MRT_Table, useMaterialReactTable } from 'material-react-table';
import { API_URI, CONNECTION_ERROR_MESSAGES } from '../scripts/const.js'
import HistoryTable from './HistoryTable.jsx';
import { useOutletContext } from "react-router-dom";
import { Preloader } from '../components/Preloader/Preloader.jsx'
import { getConnectionErrorByStatus } from '../scripts/func.js'

export function History({ header }) {
	const [loading, setLoading] = useOutletContext();

	const [history, setHistory] = useState([]);

	useEffect(() => {
		handleGetHistoryRequest();
	}, []);

	function handleGetHistoryRequest() {
		axios.get(`${API_URI}/History`)
			.then(function (response) {
				let history = response.data;
				if (Array.isArray(history)) {
					setHistory(history);
				}

				setLoading({
					preloader: false,
					data: true,
					message: ''
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

    return (
		<>
			<h1>{header}</h1>
			{
				!loading.data || loading.message ?
					<p>{loading.message}</p> :
					<HistoryTable data={history} />
			}
			<Preloader state={loading.preloader} />
        </>
    )
}