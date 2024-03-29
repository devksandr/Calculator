export const WARNING_MESSAGES = {
	database: 'Database is unavailable',
	server: 'Server is unavailable',
	data: 'No data',
	defaultData: 'No default data in database',
	unexpected: 'Unexpected error'
}

export function getConnectionErrorByStatus(status) {
	let errMessage;
	switch (status) {
		case 'ERR_NETWORK':
			errMessage = WARNING_MESSAGES.server;
			break;
		case 'ERR_BAD_RESPONSE':
			errMessage = WARNING_MESSAGES.database;
			break;
		default:
			errMessage = WARNING_MESSAGES.unexpected;
	}
	return errMessage;
}