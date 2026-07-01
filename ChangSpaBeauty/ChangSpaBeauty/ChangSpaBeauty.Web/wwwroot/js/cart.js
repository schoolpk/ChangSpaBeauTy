function changeQty(btn, delta) {
    const form = btn.closest('.qty-form');
    const input = form.querySelector('.qty-input');
    const stock = parseInt(input.dataset.stock) || 99; // ✅ lấy stock thực
    let val = parseInt(input.value) + delta;
    if (val < 1) val = 1;
    if (val > stock) {                                  // ✅ giới hạn theo stock
        val = stock;
        alert(`Chỉ còn ${stock} sản phẩm trong kho!`);
    }
    input.value = val;
    form.submit();
}