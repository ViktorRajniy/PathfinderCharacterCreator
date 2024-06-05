import BrowseGeneralListElement from "../../Components/BrowseGeneralListElement/BrowseGeneralListElement";
import { useState } from 'react'

export default function BrowseGeneral() {
	const BASE_URL = "https://localhost:7160/api/"
	const [responseData, setResponseData] = useState("Hello world")

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

	return (
		<>
			<BrowseGeneralListElement Signature="Имя" Value={responseData.Name} />
			<BrowseGeneralListElement Signature="Родословная" Value="asd" />
			<BrowseGeneralListElement Signature="Наследие" Value="asd" />
			<BrowseGeneralListElement Signature="Предыстория" Value="asd" />
			<BrowseGeneralListElement Signature="Класс" Value="asd" />
			<BrowseGeneralListElement Signature="Размер" Value="asd" />
			<BrowseGeneralListElement Signature="Маровоззрение" Value="asd" />
			<BrowseGeneralListElement Signature="Божество" Value="asd" />
			<button>Повысить уровень</button>
		</>
	)
}