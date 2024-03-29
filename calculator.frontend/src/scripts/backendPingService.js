import axios from 'axios'

const PING_URI = 'https://localhost:7160/ping';
export const PING_TIMER = 10 * 1000;
export async function pingBackendRequest() {
	let result = {
		server: false,
		database: false
	};

	try {
		let response = await axios.get(`${PING_URI}`);
		const databaseStatus = response.data.npgsql;
		const databaseResult = String(databaseStatus).toLowerCase() === 'true' ? true : false;
		result = {
			server: true,
			database: databaseResult
		};
	} catch (error) {
		if (error.code === "ERR_NETWORK") {
			result = {
				server: false,
				database: false
			};
		}
		else if (error.code === "ERR_BAD_RESPONSE") {
			result = {
				server: true,
				database: false
			};
		}
	}

	return result;
}