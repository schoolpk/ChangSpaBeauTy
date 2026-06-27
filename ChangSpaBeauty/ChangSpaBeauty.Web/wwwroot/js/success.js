/* ===== success.js ===== */

// Mini confetti burst on page load
(function () {
    const canvas = document.getElementById('confetti');
    if (!canvas) return;
    const ctx = canvas.getContext('2d');

    canvas.width  = window.innerWidth;
    canvas.height = window.innerHeight;

    const colors = ['#D6336C','#e85d8a','#fce4ec','#ff8fab','#ffb3c6','#fff'];
    const pieces = Array.from({ length: 120 }, () => ({
        x:  Math.random() * canvas.width,
        y:  Math.random() * canvas.height - canvas.height,
        w:  6 + Math.random() * 8,
        h:  10 + Math.random() * 6,
        color: colors[Math.floor(Math.random() * colors.length)],
        r:  Math.random() * Math.PI * 2,
        rv: (Math.random() - .5) * .12,
        vy: 2 + Math.random() * 3,
        vx: (Math.random() - .5) * 1.5,
        opacity: 1,
    }));

    let frame = 0;
    function draw() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        pieces.forEach(p => {
            ctx.save();
            ctx.globalAlpha = p.opacity;
            ctx.translate(p.x + p.w / 2, p.y + p.h / 2);
            ctx.rotate(p.r);
            ctx.fillStyle = p.color;
            ctx.fillRect(-p.w / 2, -p.h / 2, p.w, p.h);
            ctx.restore();

            p.x  += p.vx;
            p.y  += p.vy;
            p.r  += p.rv;
            p.vy += .05; // gravity
            if (frame > 80) p.opacity -= .015;
        });
        frame++;
        if (frame < 160) requestAnimationFrame(draw);
        else ctx.clearRect(0, 0, canvas.width, canvas.height);
    }
    draw();
})();
