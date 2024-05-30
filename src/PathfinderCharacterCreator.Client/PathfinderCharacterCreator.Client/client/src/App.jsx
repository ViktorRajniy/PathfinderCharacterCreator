import { useState } from 'react'
import './App.css'
import { useEffect } from 'react'

const BASE_URL = "https://localhost:7160/api/"

function App() {
	const [url, setUrl] = useState('')
	const [responseData, setResponseData] = useState("Hello world")

	//User/test/get

	//useEffect(() => {
	//    testFetch(BASE_URL + url);
	//}, [url])
	////const response = await fetch("http://localhost:5233/api/User/test/get", {
	//const response = await fetch("https://localhost:7160/api/User/test/get", {
	//	method: 'GET',
	//	mode: 'no-cors',
	//	headers: {
	//		Accept: 'application/json',
	//		'Content-Type': 'application/json',
	//	},
	//});

	//const testFetch = (requestUrl) => {

	//	fetch("https://localhost:7160/api/User/test/get", {
	//		method: 'GET',
	//		cache: 'no-cache',
	//		headers: {
	//			'Content-Type': 'application/json',
	//		},
	//	}).then(response => {
	//		console.log(response.status);
	//		//debugger;
	//		if (response.status === 200) {
	//			debugger;
	//			response.json().then((jsonData) => {
	//				console.log(jsonData);
	//				setResponseData(jsonData);
	//			});

	//			//try {
	//			//	const jsonData = await response.json();
	//			//	console.log('jsonData', jsonData);
	//			//	setResponseData(jsonData);
	//			//} catch (e) {
	//			//	console.log('Exception', e);
	//			//}
	//		} else {
	//			console.log('Response Error');
	//		}
	//	});

	//}
	const testFetch = async (requestUrl) => {
		const response = await fetch(requestUrl, {
			method: 'GET',
			//cache: 'no-cache',
			//mode: 'no-cors',
			headers: {
				'Content-Type': 'application/json',
			},
		});
		if (response.status === 200) {
			try {
				const jsonData = await response.json();
				console.log('jsonData', jsonData);
				setResponseData(jsonData);
			} catch (e) {
				console.log('Exception', e);
			}
		} else {
			console.log('Response Error');
		}
	}


	console.log(responseData);

	return (
		<div>
			<span>{BASE_URL + url}</span>
			<input type="text" value={url} onChange={(e) => setUrl(e.target.value)} />
			<button onClick={() => testFetch(BASE_URL + url)}> test </button>
			{responseData && JSON.stringify(responseData)}
		</div>
	)
}

export default App