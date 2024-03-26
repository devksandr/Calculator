import { WARNING_MESSAGES } from './const.js'
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