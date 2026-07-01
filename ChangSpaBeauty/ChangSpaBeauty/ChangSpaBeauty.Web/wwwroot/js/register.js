function togglePassword(inputId, iconId) {
    const input = document.getElementById(inputId);
    const icon = document.getElementById(iconId);
    if (input.type === 'password') {
        input.type = 'text';
        icon.classList.replace('fa-eye', 'fa-eye-slash');
    } else {
        input.type = 'password';
        icon.classList.replace('fa-eye-slash', 'fa-eye');
    }
}

document.addEventListener('DOMContentLoaded', function () {
    const pwd = document.getElementById('passwordInput');
    const box = document.getElementById('pwdStrength');
    const fill = document.getElementById('pwdStrengthFill');
    const label = document.getElementById('pwdStrengthLabel');

    if (!pwd || !box || !fill || !label) return;

    pwd.addEventListener('input', function () {
        const val = pwd.value;

        if (!val) {
            box.style.display = 'none';
            return;
        }
        box.style.display = 'block';

        let score = 0;
        if (val.length >= 6) score++;
        if (val.length >= 10) score++;
        if (/[a-z]/.test(val) && /[A-Z]/.test(val)) score++;
        if (/[0-9]/.test(val)) score++;
        if (/[^A-Za-z0-9]/.test(val)) score++;

        if (score <= 2) {
            fill.style.width = '33%';
            fill.style.background = 'var(--pink-dark)';
            label.textContent = 'Mật khẩu yếu';
            label.style.color = 'var(--pink-dark)';
        } else if (score <= 3) {
            fill.style.width = '66%';
            fill.style.background = 'var(--peach)';
            label.textContent = 'Mật khẩu trung bình';
            label.style.color = '#B8762E';
        } else {
            fill.style.width = '100%';
            fill.style.background = 'var(--mint)';
            label.textContent = 'Mật khẩu mạnh';
            label.style.color = '#1F7A52';
        }
    });
});