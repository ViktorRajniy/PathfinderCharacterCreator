import Button from './UI/Button/Button.jsx'
import LinkButton from './UI/LinkButton/LinkButton.jsx';
import TextInput from './UI/TextInput/TextInput.jsx';

export default function Authorization() {
    return (
        <div className="container">
            <h2>Авторизация</h2>
            <TextInput type="email" placeholder="Почта"/>
            <TextInput type="password" placeholder="Пароль"/>
            <Button>Войти</Button>
            <LinkButton>Нет аккаунта</LinkButton>
            <LinkButton>Забыл пароль</LinkButton>
        </div>
    );
}