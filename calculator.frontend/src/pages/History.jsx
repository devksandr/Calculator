import { useMemo } from 'react'
import { MRT_Table, useMaterialReactTable } from 'material-react-table';

export function History() {

	const data = [
		{
			param1: 11,
			operation: '+',
			param2: 2,
			calculate: '',
			result: 3,
		}
	];

	const columns = useMemo(

		() => [
			{
				accessorKey: 'param1',
				header: 'Parameter 1',
			},
			{
				accessorKey: 'operation',
				header: 'Operation',
			},
			{
				accessorKey: 'param2',
				header: 'Parameter 2',
			},
			{
				accessorKey: 'calculate',
				header: 'Calculate',
			},
			{
				accessorKey: 'result',
				header: 'Result',
			},
			{
				accessorKey: 'asd',
				header: 'zxc',
				title: 'Client',
				field: 'id',
				render: () => <p>asdzxc</p>,
				editComponent: () => (
					<p>try</p>
				)
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
		mrtTheme: (theme) => ({
			baseBackgroundColor: theme.palette.background.default, //change default background color
		}),
		muiTableBodyRowProps: { hover: false },
		muiTableProps: {
			sx: {
				border: '1px solid rgba(81, 81, 81, .5)',
				caption: {
					captionSide: 'top',
				},
			},
		},
		muiTableHeadCellProps: {
			sx: {
				border: '1px solid rgba(81, 81, 81, .5)',
				fontStyle: 'italic',
				fontWeight: 'normal',
			},
		},
		muiTableBodyCellProps: {
			sx: {
				border: '1px solid rgba(81, 81, 81, .5)',
			},
		},
	});

    return (
        <>
			<h1>History</h1>
			<MRT_Table table={table} />
        </>
    )
}