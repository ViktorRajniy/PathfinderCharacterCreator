/* eslint-disable react/prop-types */
import './CharacterListItem.css'

export default function CharacterListItem({ name, characterClass, level }) {
	return (
		<div className="flex-container">
			<label className="flex-item">{name}</label>
			<label className="flex-item">{characterClass}</label>
			<label className="flex-item-min">{level}</label>
			<button className="flex-item-min">удалить</button>
		</div>
	)
}