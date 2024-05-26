import Button from './UI/Button/Button.jsx'
import LinkButton from './UI/LinkButton/LinkButton.jsx';
import TextInput from './UI/TextInput/TextInput.jsx';

export default function Registration() {
    return (
        <div className="container">
            <h2>Регистрация</h2>
            <TextInput type="email" placeholder="Почта" />
            <TextInput type="password" placeholder="Пароль" />
            <TextInput type="password" placeholder="Повторите пароль" />
            <Button>Зарегистрироваться</Button>
            <LinkButton>Есть аккаунт</LinkButton>
        </div>
    );
}