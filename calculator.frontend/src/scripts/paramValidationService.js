const NUMBER_LIMITS = {
	integerMax: 9,
	fractionMax: 3
};

const isNumeric = (value) => !isNaN(value) && !isNaN(parseFloat(value));

export function isParamValid(param) {
	if (isNumeric(param)) {
		let numberPartsArr = param.split(".");
		let numberParts = {
			integer: Math.abs(numberPartsArr[0]).toString(),
			fraction: numberPartsArr[1]
		};

		let numberPartsValidation = {
			integerStatus: numberParts.integer.length > 0 && numberParts.integer.length <= NUMBER_LIMITS.integerMax,
			fractionStatus: numberParts.fraction === undefined || numberParts.fraction.length > 0 && numberParts.fraction.length <= NUMBER_LIMITS.fractionMax
		}

		if (numberPartsValidation.integerStatus && numberPartsValidation.fractionStatus) {
			return true;
		}
	}
	return false;
}