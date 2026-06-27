/* ===== checkout.js ===== */

// Loading state khi submit
const form  = document.getElementById('checkoutForm');
const btn   = document.getElementById('btnOrder');

if (form && btn) {
    form.addEventListener('submit', () => {
        btn.classList.add('loading');
        btn.innerHTML = '<span class="co-btn-icon">⏳</span> Đang xử lý...';
    });
}

// Auto-dismiss alerts
document.querySelectorAll('.co-alert').forEach(el => {
    setTimeout(() => {
        el.style.transition = 'opacity .5s';
        el.style.opacity = '0';
        setTimeout(() => el.remove(), 500);
    }, 5000);
});
