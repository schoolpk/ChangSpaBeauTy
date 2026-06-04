
    const nameInput = document.getElementById('nameInput');
    const descInput = document.getElementById('descInput');
        nameInput.addEventListener('input', () => document.getElementById('nameCount').textContent = nameInput.value.length);
        descInput.addEventListener('input', () => document.getElementById('descCount').textContent = descInput.value.length);
    document.getElementById('nameCount').textContent = nameInput.value.length;
    document.getElementById('descCount').textContent = descInput.value.length;

    document.getElementById('editForm').addEventListener('submit', function () {
            const btn = document.getElementById('saveBtn');
    btn.disabled = true;
    document.getElementById('spinner').style.display = 'inline-block';
    document.getElementById('saveLabel').textContent = 'Đang lưu...';
        });
