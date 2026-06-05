// ── Thay đổi số lượng ───────────────────────────────────────────────
function changeQty(delta) {
    const input = document.getElementById('qty');
    if (!input) return;
    const max = parseInt(input.max) || 99;
    let val = parseInt(input.value) + delta;
    if (val < 1) val = 1;
    if (val > max) val = max;
    input.value = val;
}

// ── Thêm vào giỏ hàng ───────────────────────────────────────────────
function addToCart(productId) {
    const qty = parseInt(document.getElementById('qty')?.value || 1);

    // Lấy AntiForgeryToken từ hidden input trong form bất kỳ trên trang
    const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value ?? '';

    fetch('/Cart/AddItem', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': token
        },
        body: JSON.stringify({ productId: productId, quantity: qty })
    })
        .then(async res => {
            if (res.ok) {
                showToast('✅ Đã thêm ' + qty + ' sản phẩm vào giỏ!');
                updateCartBadge(qty);
            } else {
                const text = await res.text();
                showToast('❌ ' + (text || 'Có lỗi xảy ra!'));
            }
        })
        .catch(() => showToast('❌ Không thể kết nối, thử lại nhé!'));
}

// ── Cập nhật badge giỏ hàng trên header ────────────────────────────
function updateCartBadge(addedQty) {
    const badge = document.querySelector('.cart-badge');
    if (!badge) return;
    const current = parseInt(badge.textContent) || 0;
    badge.textContent = current + addedQty;
    // Hiệu ứng nhỏ
    badge.style.transform = 'scale(1.4)';
    setTimeout(() => badge.style.transform = 'scale(1)', 250);
}

// ── Toast notification ───────────────────────────────────────────────
function showToast(msg) {
    const t = document.getElementById('toast');
    if (!t) return;
    t.textContent = msg;
    t.classList.add('show');
    clearTimeout(t._timer);
    t._timer = setTimeout(() => t.classList.remove('show'), 2800);
}