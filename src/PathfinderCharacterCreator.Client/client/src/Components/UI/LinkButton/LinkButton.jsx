/* eslint-disable react/prop-types */
import './LinkButton.css';

export default function LinkButton({ children }) {
	return (
		<div>
			<button className="linkButton">{children}</button>
		</div>
	)
}