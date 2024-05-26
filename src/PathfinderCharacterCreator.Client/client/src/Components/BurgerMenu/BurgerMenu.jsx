import './BurgerMenu.css'
export default function BurgerMenu() {
    function OpenMenu() {
        document.querySelector("header").classList.toggle("open")
    }

    return (
        <div>
            <button className="header__burger-btn" id="burger" onClick={OpenMenu}>
                <span></span><span></span><span></span>
            </button>
            <nav className="menu">
                <ul className="menu__list">
                    <li className="menu__item">
                        <a className="menu__link" href="#">
                            Личный кабинет
                        </a>
                    </li>
                    <li className="menu__item">
                        <a className="menu__link" href="#">
                            Персонажи
                        </a>
                    </li>
                    <li className="menu__item">
                        <a className="menu__link" href="#">
                            Выход
                        </a>
                    </li>
                </ul>
            </nav>
        </div>
    );
}