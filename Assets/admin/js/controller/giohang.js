function DeleteAll() {
    $.ajax({
        url: '/GioHang/DeleteAll',
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/GioHang";
            }
        }
    });
}
// truyen id vao trong ham 
function Delete(id) {
    $.ajax({
        data: { id: $(this).data('id') },
        url: '/GioHang/Delete', // POST nen thoi
        dataType: 'json',
        type: 'POST',
        data: {
            id: id
        },
        success: function (res) {
            if (res.status == true) {
                console.log(res);
                window.location.href = "/GioHang";
            }
        }
    });
}
function Update() {
    var listSp = $('.txtsoluong');
    var cartList = [];
    $.each(listSp, function (i, item) {
        cartList.push({
            Soluong: $(item).val(),
            ttsanpham: {
                mamathang: $(item).data('id')
            }
        });
    });
    $.ajax({
        url: '/GioHang/Update',
        data: { cartModel: JSON.stringify(cartList) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                console.log(res);
                window.location.href = "/GioHang";
            }
        }
    });
}

