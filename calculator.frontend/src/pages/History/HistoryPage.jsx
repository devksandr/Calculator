import { useState, useEffect } from 'react'
import { useInterval } from '../../hooks/useInterval'
import axios from 'axios'
import { API_URI } from '../../scripts/const.js'
import HistoryTable from '../../components/HistoryTable/HistoryTable.jsx';
import { useOutletContext } from "react-router-dom";
import { Preloader } from '../../components/Preloader/Preloader.jsx'
import { getConnectionErrorByStatus, WARNING_MESSAGES } from '../../scripts/connectionMessageService.js'
import { pingBackendRequest, PING_TIMER } from '../../scripts/backendPingService'

export function HistoryPage({ header }) {
	const [loading, setLoading] = useOutletContext();

	const [history, setHistory] = useState([]);

	useEffect(() => {
		handleGetHistoryRequest();
	}, []);

	useInterval(() => {
		handlePingRequest();
	}, PING_TIMER);

	const handlePingRequest = async () => {
		let pingResult = await pingBackendRequest();

		if (!pingResult.server) {
			setLoading({
				...loading,
				data: false,
				message: WARNING_MESSAGES.server
			});
		}
		else if (!pingResult.database) {
			setLoading({
				...loading,
				data: false,
				message: WARNING_MESSAGES.database
			});
		}
		else {
			setLoading({
				...loading,
				data: true,
				message: ''
			});
		}
	};

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
					<p>{loading.message}</p> : history.length === 0 ?
					<p>{WARNING_MESSAGES.data}</p> :
					<div>
						<HistoryTable data={history} />
					</div>
			}
			<Preloader state={loading.preloader} />
        </>
    )
}