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
/* ══════════════════════════════════════════════════════════
   K-BEAUTY EFFECTS — hiệu ứng bổ sung cho giao diện mới
   Dán đoạn này vào CUỐI file wwwroot/js/changspa.js hiện có.
   Toàn bộ code nằm trong 1 IIFE riêng, dùng tên hàm/biến có
   tiền tố "kb" để KHÔNG đụng tới toggleFav / addToCart /
   setPage / switchTab / filterTable / toggleNotif đã có sẵn.
   An toàn chạy trên mọi trang — tự bỏ qua nếu không có
   phần tử tương ứng.
   ══════════════════════════════════════════════════════════ */
(function () {
    "use strict";

    document.addEventListener("DOMContentLoaded", function () {
        kbInitNavPill();
        kbInitBannerSparkles();
        kbInitFavoriteBurst();
        kbInitScrollReveal();
    });

    /* 1) NAV — pill pastel trượt theo item đang hover, fallback
          về vị trí item .active khi rời chuột (chỉ chạy nếu có
          #site-nav .nav-inner trên trang) */
    function kbInitNavPill() {
        var navInner = document.querySelector("#site-nav .nav-inner");
        if (!navInner) return;

        var pill = document.createElement("div");
        pill.className = "kb-nav-pill";
        navInner.insertBefore(pill, navInner.firstChild);

        function moveTo(el) {
            if (!el) { pill.style.opacity = "0"; return; }
            var navRect = navInner.getBoundingClientRect();
            var elRect = el.getBoundingClientRect();
            pill.style.left = (elRect.left - navRect.left) + "px";
            pill.style.width = elRect.width + "px";
            pill.style.opacity = "1";
        }

        var items = navInner.querySelectorAll(".nav-item");
        items.forEach(function (item) {
            item.addEventListener("mouseenter", function () { moveTo(item); });
        });
        navInner.addEventListener("mouseleave", function () {
            var active = navInner.querySelector(".nav-item.active");
            moveTo(active);
        });
        // Vị trí khởi tạo theo item active (nếu có)
        var initialActive = navInner.querySelector(".nav-item.active");
        if (initialActive) moveTo(initialActive);
    }

    /* 2) BANNER — rải vài sticker (✨ 💕 🫧) trôi nhẹ trong khu
          vực .banner, chỉ chạy nếu có .banner trên trang */
    function kbInitBannerSparkles() {
        var banner = document.querySelector(".banner");
        if (!banner) return;

        var stickers = ["✨", "💕", "🫧", "🌸"];
        var count = window.innerWidth < 700 ? 3 : 6;

        for (var i = 0; i < count; i++) {
            var span = document.createElement("span");
            span.className = "kb-sparkle";
            span.textContent = stickers[i % stickers.length];
            span.style.left = (8 + Math.random() * 84) + "%";
            span.style.top = (10 + Math.random() * 70) + "%";
            span.style.animationDuration = (3 + Math.random() * 3) + "s";
            span.style.animationDelay = (Math.random() * 2) + "s";
            span.style.fontSize = (14 + Math.random() * 10) + "px";
            banner.appendChild(span);
        }
    }

    /* 3) PRODUCT FAVORITE — khi bấm .product-fav, bắn vài icon
          tim nhỏ bay lên rồi biến mất. Không thay thế onclick
          toggleFav() đã gán trong HTML — chỉ lắng nghe thêm. */
    function kbInitFavoriteBurst() {
        document.addEventListener("click", function (e) {
            var btn = e.target.closest && e.target.closest(".product-fav");
            if (!btn) return;

            var rect = btn.getBoundingClientRect();
            var n = 4;
            for (var i = 0; i < n; i++) {
                var heart = document.createElement("span");
                heart.className = "kb-heart-particle";
                heart.textContent = "💗";
                heart.style.left = (rect.left + rect.width / 2 - 7 + (Math.random() * 24 - 12)) + "px";
                heart.style.top = (rect.top) + "px";
                document.body.appendChild(heart);
                (function (el) {
                    setTimeout(function () { el.remove(); }, 950);
                })(heart);
            }
        });
    }

    /* 4) SCROLL REVEAL — thẻ sản phẩm hiện dần khi cuộn tới.
          Mặc định mọi thẻ vẫn HIỂN THỊ bình thường (opacity:1)
          nếu IntersectionObserver không khả dụng — không phá
          giao diện khi JS lỗi hoặc bị tắt. */
    function kbInitScrollReveal() {
        var cards = document.querySelectorAll(".product-card");
        if (!cards.length || !("IntersectionObserver" in window)) return;

        cards.forEach(function (card) {
            card.style.opacity = "0";
            card.style.transform = "translateY(16px)";
            card.style.transition = "opacity .5s ease, transform .5s cubic-bezier(.34,1.56,.64,1)";
        });

        var observer = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) {
                    entry.target.style.opacity = "1";
                    entry.target.style.transform = "translateY(0)";
                    observer.unobserve(entry.target);
                }
            });
        }, { threshold: 0.1, rootMargin: "0px 0px -40px 0px" });

        cards.forEach(function (card) { observer.observe(card); });
    }
})();
