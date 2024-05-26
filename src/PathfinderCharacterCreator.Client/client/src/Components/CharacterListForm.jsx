import Button from "./UI/Button/Button";
import CharacterList from "./UI/CharacterList/CharacterList";
import './CharacterListForm.css';

export default function CharacterListForm() {
	return (
		<>
			<header>
				<h1>
					Список персонажей
				</h1>
			</header>

			<div className="center-container">
				<Button>Новый персонаж</Button>
			</div>

			<CharacterList />
		</>
	)
}