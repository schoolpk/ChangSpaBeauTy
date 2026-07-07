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

    const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value ?? '';

    // Gửi FormData để controller bind được
    const formData = new FormData();
    formData.append('productId', productId);
    formData.append('quantity', qty);

    fetch('/Cart/AddToCartAjax', {   // ✅ đúng tên action
        method: 'POST',
        headers: {
            'RequestVerificationToken': token   // AddToCartAjax không có [ValidateAntiForgeryToken] nên OK
        },
        body: formData              // ✅ FormData thay vì JSON
    })
        .then(async res => {
            if (res.ok) {
                const data = await res.json();
                if (data.success) {
                    showToast('✅ Đã thêm ' + qty + ' sản phẩm vào giỏ!');
                    updateCartBadge(data.cartCount);  // ✅ dùng số thực từ server
                } else {
                    showToast('❌ Có lỗi xảy ra!');
                }
            } else if (res.status === 401) {
                // Chưa đăng nhập → redirect login
                window.location.href = '/Account/Login';
            } else {
                showToast('❌ Có lỗi xảy ra!');
            }
        })
        .catch(() => showToast('Bạn cần đăng nhập hoặc đăng ký!'));
}

// ── Cập nhật badge giỏ hàng trên header ────────────────────────────
function updateCartBadge(newCount) {
    const badge = document.querySelector('.cart-badge');
    if (!badge) return;
    badge.textContent = newCount;   // ✅ dùng count thực từ server thay vì cộng dồn
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
// ── Mua ngay ────────────────────────────────────────────────────────
function buyNow(productId) {
    const qty = parseInt(document.getElementById('qty')?.value || 1);

    const formData = new FormData();
    formData.append('productId', productId);
    formData.append('quantity', qty);

    fetch('/Cart/AddToCartAjax', {
        method: 'POST',
        body: formData
    })
        .then(async res => {
            if (res.status === 401) {
                window.location.href = '/Account/Login';
                return;
            }
            if (res.ok) {
                const data = await res.json();
                if (data.success) {
                    // ✅ Redirect thẳng sang Checkout
                    window.location.href = '/Order/Checkout';
                } else {
                    showToast('❌ ' + data.message);
                }
            } else {
                showToast('❌ Có lỗi xảy ra!');
            }
        })
        .catch(() => showToast('Bạn cần đăng nhập hoặc đăng ký!'));
}

// --Stock error---------------------------------
fetch('/Cart/AddToCartAjax', {
    method: 'POST',
    headers: { 'RequestVerificationToken': token },
    body: formData
})
    .then(async res => {
        if (res.status === 401) {
            window.location.href = '/Account/Login';
            return;
        }
        if (res.ok) {
            const data = await res.json();
            if (data.success) {
                showToast('✅ Đã thêm ' + qty + ' sản phẩm vào giỏ!');
                updateCartBadge(data.cartCount);
            } else {
                showToast('❌ ' + data.message); // ✅ hiện lỗi stock
            }
        } else {
            showToast('❌ Có lỗi xảy ra!');
        }
    })
    .catch(() => showToast('❌ Không thể kết nối, thử lại nhé!'));