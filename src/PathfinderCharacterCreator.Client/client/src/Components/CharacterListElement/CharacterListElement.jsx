import './CharacterListElement.css'
import {PropTypes } from 'prop-types'

export default function CharacterListElement({ name, characterClass, level }) {
	return (
		<div className="flex-container">
			<label className="flex-item">{name}</label>
			<label className="flex-item">{characterClass}</label>
			<label className="flex-item-min">{level}</label>
			<button className="flex-item-min">удалить</button>
		</div>
	)
}

CharacterListElement.propTypes = {
	name: PropTypes.string,
	characterClass: PropTypes.string,
	level: PropTypes.string,
};