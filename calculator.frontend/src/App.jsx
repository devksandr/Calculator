import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { Home } from './pages/Home.jsx'
import { History } from './pages/History.jsx'
import { Layout } from './Layout'

function App() {
	return (
		<BrowserRouter>
			<Routes>
				<Route element={ <Layout/> }>
					<Route path='/' element={<Home />} />
					<Route path='/history' element={<History />} />
				</Route>
			</Routes>
		</BrowserRouter>
	)
}

export default App
