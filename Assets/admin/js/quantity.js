const plusQuantity = document.querySelector('.btn-plus');
const minusQuantity = document.querySelector('.btn-minus');
plusQuantity.onclick = () => {
    let quantity = document.querySelector('.input-quantity');
    quantity.value++;
}

minusQuantity.onclick = () => {
    let quantity = document.querySelector('.input-quantity');
    if (quantity.value >= 2) {
        quantity.value--;
    }
}
