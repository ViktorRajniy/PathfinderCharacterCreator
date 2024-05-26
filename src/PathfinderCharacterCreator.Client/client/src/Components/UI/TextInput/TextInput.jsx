/* eslint-disable react/prop-types */
import './TextInput.css';

export default function TextInput({ type, placeholder} ) {
	return (
		<div>
			<input className="textInput" type={type} placeholder={placeholder} ></input>
		</div>
	)
}