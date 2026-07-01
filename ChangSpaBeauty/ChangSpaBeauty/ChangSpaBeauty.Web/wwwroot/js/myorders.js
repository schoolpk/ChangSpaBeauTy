/* ===== myorders.js ===== */

// Tab filter
const tabs      = document.querySelectorAll('.mo-tab');
const orderCards = document.querySelectorAll('#orderList .mo-card');

tabs.forEach(tab => {
    tab.addEventListener('click', () => {
        tabs.forEach(t => t.classList.remove('active'));
        tab.classList.add('active');

        const status = tab.dataset.status;
        orderCards.forEach(card => {
            const match = status === 'all' || card.dataset.status === status;
            card.style.display = match ? '' : 'none';
        });
    });
});

// Auto-dismiss alerts
document.querySelectorAll('.mo-alert').forEach(el => {
    setTimeout(() => {
        el.style.transition = 'opacity .5s';
        el.style.opacity = '0';
        setTimeout(() => el.remove(), 500);
    }, 4000);
});
