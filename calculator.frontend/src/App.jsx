import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import axios from 'axios'


function App() {
	const [count, setCount] = useState(0)

	function handleSumRequest() {

		/*
		axios.get('https://localhost:7160/api/Calculator/')
			.then(function (response) {
				console.log(response);
			})
			.catch(function (error) {
				console.log(error);
			});
		*/

		var body = {
			a: 1,
			b: 2
		};

		axios.post('https://localhost:7160/api/Calculator', body)
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


		<button onClick={handleSumRequest}>
			Sum
		</button>
	</>
  )
}

export default App
