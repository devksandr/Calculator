import { CONNECTION_ERROR_MESSAGES } from './const.js'
export function getConnectionErrorByStatus(status) {
	let errMessage;
	switch (status) {
		case 'ERR_NETWORK':
			errMessage = CONNECTION_ERROR_MESSAGES.server;
			break;
		case 'ERR_BAD_RESPONSE':
			errMessage = CONNECTION_ERROR_MESSAGES.database;
			break;
		default:
			errMessage = CONNECTION_ERROR_MESSAGES.unexpected;
	}
	return errMessage;
}