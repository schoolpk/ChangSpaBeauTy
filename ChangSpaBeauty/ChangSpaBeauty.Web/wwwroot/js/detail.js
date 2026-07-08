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

// ── Kiểm tra đăng nhập trước khi thao tác ───────────────────────────
function requireLogin() {
    if (!IS_AUTHENTICATED) {
        document.getElementById('login-overlay').style.display = 'flex';
        return false; // chưa đăng nhập
    }
    return true; // đã đăng nhập
}

// ── Thêm vào giỏ hàng ───────────────────────────────────────────────
function addToCart(productId) {
    if (!requireLogin()) return; // ← chặn ngay nếu chưa đăng nhập

    const qty = parseInt(document.getElementById('qty')?.value || 1);
    const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value ?? '';

    const formData = new FormData();
    formData.append('productId', productId);
    formData.append('quantity', qty);

    fetch('/Cart/AddToCartAjax', {
        method: 'POST',
        headers: { 'RequestVerificationToken': token },
        body: formData
    })
        .then(async res => {
            if (res.ok) {
                const data = await res.json();
                if (data.success) {
                    showToast('✅ Đã thêm ' + qty + ' sản phẩm vào giỏ!');
                    updateCartBadge(data.cartCount);
                } else {
                    showToast('❌ ' + data.message);
                }
            } else {
                showToast('❌ Có lỗi xảy ra!');
            }
        })
        .catch(() => showToast('❌ Không thể kết nối, thử lại nhé!'));
}

// ── Mua ngay ────────────────────────────────────────────────────────
function buyNow(productId) {
    if (!requireLogin()) return; // ← chặn ngay nếu chưa đăng nhập

    const qty = parseInt(document.getElementById('qty')?.value || 1);
    const formData = new FormData();
    formData.append('productId', productId);
    formData.append('quantity', qty);

    fetch('/Cart/AddToCartAjax', {
        method: 'POST',
        body: formData
    })
        .then(async res => {
            if (res.ok) {
                const data = await res.json();
                if (data.success) {
                    window.location.href = '/Order/Checkout';
                } else {
                    showToast('❌ ' + data.message);
                }
            } else {
                showToast('❌ Có lỗi xảy ra!');
            }
        })
        .catch(() => showToast('❌ Không thể kết nối, thử lại nhé!'));
}

// ── Cập nhật badge giỏ hàng ─────────────────────────────────────────
function updateCartBadge(newCount) {
    const badge = document.querySelector('.cart-badge');
    if (!badge) return;
    badge.textContent = newCount;
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

// ── Đóng overlay khi click ngoài ────────────────────────────────────
document.getElementById('login-overlay')?.addEventListener('click', function (e) {
    if (e.target === this) this.style.display = 'none';
});