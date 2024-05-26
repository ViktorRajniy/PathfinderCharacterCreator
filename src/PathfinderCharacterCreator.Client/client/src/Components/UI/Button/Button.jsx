/* eslint-disable react/prop-types */
import './Button.css';

export default function Button({ children }) {
	return (
		<div>
			<button className="button" type="submit">{children}</button>
		</div>
	);
}