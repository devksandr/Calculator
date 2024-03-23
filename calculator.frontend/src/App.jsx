import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { Home } from './pages/Home.jsx'
import { History } from './pages/History.jsx'
import { Layout } from './Layout'
import { MENU } from './scripts/const.js'

function App() {
	return (
		<BrowserRouter>
			<Routes>
				<Route element={ <Layout/> }>
					<Route path={MENU.calculator.address} element={<Home header={MENU.calculator.name} />}/>
					<Route path={MENU.history.address} element={<History header={MENU.history.name} />} />
				</Route>
			</Routes>
		</BrowserRouter>
	)
}

export default App
