import { useState, useEffect } from 'react'
import axios from 'axios'
import { useMemo } from 'react'
import { MRT_Table, useMaterialReactTable } from 'material-react-table';
import { API_URI } from '../scripts/const.js'

export function HistoryTable({ data }) {
	const columns = useMemo(

		() => [
			{
				accessorKey: 'param1',
				header: 'Parameter 1',
			},
			{
				accessorKey: 'operationName',
				header: 'Operation',
			},
			{
				accessorKey: 'param2',
				header: 'Parameter 2',
			},
			{
				accessorKey: 'result',
				header: 'Result',
			}
		],
		[],
	);

	const table = useMaterialReactTable({
		columns,
		data, //data must be memoized or stable (useState, useMemo, defined outside of this component, etc.)
		enableColumnActions: false,
		enableColumnFilters: false,
		enablePagination: false,
		enableSorting: false,

	});

	return (
		<>
			<MRT_Table table={table} />
		</>
	)
}

export default HistoryTable