// ChangSpaBeauTy – Main JavaScript

function setTab(el) {
    document.querySelectorAll('.tab').forEach(t => t.classList.remove('active'));
    el.classList.add('active');
}

function setPage(el) {
    document.querySelectorAll('.page-btn').forEach(b => b.classList.remove('active'));
    el.classList.add('active');
}

function toggleFav(el) {
    if (el.classList.contains('liked')) {
        el.classList.remove('liked');
        el.textContent = '♡';
        el.style.color = '';
    } else {
        el.classList.add('liked');
        el.textContent = '♥';
        el.style.color = '#D6336C';
    }
}

function addCart(btn) {
    const badge = document.querySelector('.cart-badge');
    if (badge) {
        let count = parseInt(badge.textContent) + 1;
        badge.textContent = count;
    }
    btn.textContent = '✓ Đã thêm';
    btn.style.background = '#D6336C';
    btn.style.color = 'white';
    btn.style.borderColor = '#D6336C';
    setTimeout(() => {
        btn.textContent = '+ Thêm vào giỏ';
        btn.style.background = '';
        btn.style.color = '';
        btn.style.borderColor = '';
    }, 1500);
}

// Price range filter
document.addEventListener('DOMContentLoaded', function () {
    const rangeInput = document.querySelector('.price-range-input');
    if (rangeInput) {
        rangeInput.addEventListener('input', function () {
            const display = this.nextElementSibling;
            if (display) display.textContent = 'Dưới ' + parseInt(this.value).toLocaleString('vi-VN') + 'đ';
        });
    }
});
