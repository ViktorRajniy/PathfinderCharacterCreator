import { useEffect, useState } from "react";
import BrowseGeneralListElement from "../../Components/BrowseGeneralListElement/BrowseGeneralListElement";

export default function BrowseGeneral({ characterID }) {

	const BASE_URL = "https://localhost:7160/api/BrowseGeneral/Get?characterID="

	const [responseData, setResponseData] = useState("Hello world")

	useEffect(() => {
		testFetch(BASE_URL + characterID)
	}, [])

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
			<BrowseGeneralListElement Signature="Имя" Value={responseData.name} />
			<BrowseGeneralListElement Signature="Родословная" Value={responseData.ancestryName} />
			<BrowseGeneralListElement Signature="Наследие" Value={responseData.haritageName} />
			<BrowseGeneralListElement Signature="Предыстория" Value={responseData.backgroundName} />
			<BrowseGeneralListElement Signature="Класс" Value={responseData.subClassName} />
			<BrowseGeneralListElement Signature="Размер" Value={responseData.size} />
			<BrowseGeneralListElement Signature="Маровоззрение" Value={responseData.aligment} />
			<BrowseGeneralListElement Signature="Божество" Value={responseData.deityName} />
			<button>Повысить уровень</button>
		</>
	)
}