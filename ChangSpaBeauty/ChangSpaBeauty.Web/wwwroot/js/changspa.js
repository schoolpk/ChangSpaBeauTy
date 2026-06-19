/* ══════════════════════════════════════════════════════════
   ChangSpaBeauTy – Main JavaScript
   ══════════════════════════════════════════════════════════ */

/* ── SCROLL: progress bar + header shadow + back-to-top ─── */
(function initScroll() {
    const progressBar = document.getElementById('scrollProgress');
    const header      = document.getElementById('site-header');
    const backTop     = document.getElementById('backTop');

    function onScroll() {
        const scrolled = window.scrollY;
        const total    = document.documentElement.scrollHeight - window.innerHeight;

        // Progress bar
        if (progressBar && total > 0) {
            progressBar.style.width = ((scrolled / total) * 100).toFixed(2) + '%';
        }

        // Header shadow
        if (header) {
            header.classList.toggle('scrolled', scrolled > 10);
        }

        // Back to top
        if (backTop) {
            backTop.classList.toggle('visible', scrolled > 300);
        }
    }

    window.addEventListener('scroll', onScroll, { passive: true });
    onScroll(); // run once on load
})();

function scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
}

/* ── NOTIFICATION DROPDOWN ──────────────────────────────── */
function toggleNotif() {
    const dropdown = document.getElementById('notif-dropdown');
    const bell     = document.getElementById('notifBtn');
    if (!dropdown) return;

    const isOpen = dropdown.classList.toggle('open');
    if (bell) bell.classList.toggle('active', isOpen);
}

// Close when clicking outside
document.addEventListener('click', function (e) {
    const wrap = document.querySelector('.notif-wrap');
    if (wrap && !wrap.contains(e.target)) {
        document.getElementById('notif-dropdown')?.classList.remove('open');
        document.getElementById('notifBtn')?.classList.remove('active');
    }
});

/* ── FILTER TABS ─────────────────────────────────────────── */
function setTab(el) {
    el.closest('.filter-tabs')
      ?.querySelectorAll('.tab')
      .forEach(t => t.classList.remove('active'));
    el.classList.add('active');
}

/* ── PAGINATION ──────────────────────────────────────────── */
function setPage(el) {
    el.closest('.pagination')
      ?.querySelectorAll('.page-btn')
      .forEach(b => b.classList.remove('active'));
    el.classList.add('active');
}

/* ── WISHLIST TOGGLE ─────────────────────────────────────── */
function toggleFav(el) {
    const liked = el.classList.toggle('liked');
    el.textContent = liked ? '♥' : '♡';
    el.style.color  = liked ? '#D6336C' : '';
}

/* ── ADD TO CART (UI feedback only) ─────────────────────── */
function addCart(btn) {
    // Update badge
    const badge = document.querySelector('.cart-badge');
    if (badge) {
        const current = parseInt(badge.textContent) || 0;
        const next    = current + 1;
        badge.textContent = next > 9 ? '9+' : next;
    }

    // Button feedback
    const original = btn.textContent;
    btn.textContent = '✓ Đã thêm';
    btn.style.cssText = 'background:#D6336C;color:white;border-color:#D6336C';

    setTimeout(() => {
        btn.textContent   = original;
        btn.style.cssText = '';
    }, 1600);
}

/* ── PRICE RANGE FILTER ──────────────────────────────────── */
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.price-range-input').forEach(function (input) {
        function update() {
            const display = input.nextElementSibling;
            if (display && display.classList.contains('price-current')) {
                display.textContent = 'Dưới ' + parseInt(input.value).toLocaleString('vi-VN') + 'đ';
            }
        }
        input.addEventListener('input', update);
        update(); // init
    });
});

/* ── SEARCH DEBOUNCE (optional enhancement) ──────────────── */
(function initSearch() {
    const input = document.querySelector('.search-wrap input[name="keyword"]');
    if (!input) return;

    // Highlight search box on focus — already handled by CSS :focus-within
    // Could add autocomplete suggestions here in the future
})();
