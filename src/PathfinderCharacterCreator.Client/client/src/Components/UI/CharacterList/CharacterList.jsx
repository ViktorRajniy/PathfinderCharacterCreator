import CharacterListItem from '../CharacterListItem/CharacterListItem'
import './CharacterList.css'
import { Characters } from './Characters'

export default function CharacterList() {
	return (
		<>
			<h2>Созданные персонажи</h2>

			{Characters.map((character) => {
				return (
					<CharacterListItem key={ character.name} name={character.name} charClass={character.charClass} level={character.level} />)
			})}
		</>
	)
}