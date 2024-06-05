import  './BrowseGeneralListElement.css'

export default function BrowseGeneralListElement(props) {
	return (
		<div className="divBorder">
			<text>{props.Signature}</text>
			<text>{props.Value}</text>
		</div>
	)
}