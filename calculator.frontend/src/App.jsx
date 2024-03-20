import { useState, useEffect } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import axios from 'axios'
import Param from './components/Param/Param.jsx'
import Operation from './components/Operation/Operation.jsx'

function App() {
	const apiURI = 'https://localhost:7160/api';
	const [count, setCount] = useState(0);

	const [param1, setParam1] = useState(0);
	const [param2, setParam2] = useState(0);
	const [operation, setOperation] = useState('');

	useEffect(() => {
		handleGetAllOperationsRequest();
	}, []);

	function handleGetAllOperationsRequest() {
		axios.get(`${apiURI}/Operation`)
			.then(function (response) {
				console.log(response);
			})
			.catch(function (error) {
				console.log(error);
			});
	}

	function handleSumRequest() {
		var body = {
			param1: 1,
			param2: 2
		};

		axios.post(`${apiURI}/Operation`, body)
			.then(function (response) {
				console.log(response);
			})
			.catch(function (error) {
				console.log(error);
			});

	}

	return (
	<>
		<div>
			<a href="https://vitejs.dev" target="_blank">
				<img src={viteLogo} className="logo" alt="Vite logo" />
			</a>
			<a href="https://react.dev" target="_blank">
				<img src={reactLogo} className="logo react" alt="React logo" />
			</a>
		</div>
		<h1>Vite + React</h1>
		<div className="card">
			<button onClick={() => setCount((count) => count + 1)}>
				count is {count}
			</button>
			<p>
				Edit <code>src/App.jsx</code> and save to test HMR
			</p>
		</div>

		<div>
			<Param setParam={setParam1} />
			<Operation setOperation={setOperation} />
			<Param setParam={setParam2} />

			<button onClick={handleSumRequest}>
				Sum
			</button>
		</div>
	</>
  )
}

export default App
