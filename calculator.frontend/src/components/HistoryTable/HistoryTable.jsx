import { useMemo } from 'react'
import { MRT_Table, useMaterialReactTable } from 'material-react-table';

export function HistoryTable({ data }) {
	const columns = useMemo(() => [
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
		data,

		enableColumnActions: false,
		enableColumnFilters: false,
		enablePagination: false,
		enableSorting: false,

		muiTableHeadRowProps: {
			sx: {
				boxShadow: 'none'
			},
		},
		muiTableHeadCellProps: {
			sx: {
				textAlign: 'center',
				backgroundColor: '#242424',
				color: 'white',
				'& .Mui-TableHeadCell-Content': {
					justifyContent: 'center',
				},
			},
		},
		muiTableBodyCellProps: {
			sx: {
				backgroundColor: '#242424',
				textAlign: 'center',
				color: '#919191',
				borderBottom: 'none',
			},
		}
	});

	return (
		<>
			<MRT_Table table={table} />
		</>
	)
}

export default HistoryTable