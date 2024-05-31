import { useState, useEffect } from 'react'
import CharacterListElement from '../CharacterListElement/CharacterListElement'

export default function CharacterList() {
	const [responseData, setResponseData] = useState()

	const GetCharacterListURL = "https://localhost:7160/api/Character/GetCharacterList"

	useEffect(() => {
		CharacterListFetch(GetCharacterListURL)
	}, []);

	const CharacterListFetch = async (requestUrl) => {
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
				setResponseData(JSON.stringify(jsonData));
			} catch (e) {
				console.log('Exception', e);
			}
		} else {
			console.log('Response Error');
		}
	}

	return (
		<div>

		</div>
	);
}