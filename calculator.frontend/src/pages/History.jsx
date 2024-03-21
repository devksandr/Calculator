import { useState, useEffect } from 'react'
import axios from 'axios'
import { useMemo } from 'react'
import { MRT_Table, useMaterialReactTable } from 'material-react-table';
import { API_URI } from '../scripts/const.js'
import HistoryTable from './HistoryTable.jsx';



export function History() {
	const [history, setHistory] = useState([]);

	useEffect(() => {
		handleGetHistoryRequest();
	}, []);

	function handleGetHistoryRequest() {
		axios.get(`${API_URI}/History`)
			.then(function (response) {
				let history = response.data;
				if (Array.isArray(history) && history.length > 0) {
					setHistory(history);
				}
			})
			.catch(function (error) {
				console.log(error);
			});
	}

    return (
        <>
			<h1>History</h1>
			<HistoryTable data={history } />
        </>
    )
}