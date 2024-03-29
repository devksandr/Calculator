import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { HomePage } from './pages/Home/HomePage'
import { HistoryPage } from './pages/History/HistoryPage'
import { Layout } from './Layout'
import { MENU } from './scripts/const.js'

function App() {
	return (
		<BrowserRouter>
			<Routes>
				<Route element={ <Layout/> }>
					<Route path={MENU.calculator.address} element={<HomePage header={MENU.calculator.name} />}/>
					<Route path={MENU.history.address} element={<HistoryPage header={MENU.history.name} />} />
				</Route>
			</Routes>
		</BrowserRouter>
	)
}

export default App
