const navMenu = document.querySelector('.nav__menu');
const navClose = document.querySelector('.modal__close');
const modal = document.querySelector('.modal');

navMenu.onclick = () => {
    modal.classList.add('active');
}

navClose.onclick = () => {
    modal.classList.remove('active');
}