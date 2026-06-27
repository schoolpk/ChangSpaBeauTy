
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
// Preview ảnh mới trước khi upload
function previewImage(input) {
    if (input.files && input.files[0]) {
        const reader = new FileReader();
        reader.onload = e => {
            const wrap = document.getElementById('img-preview-wrap');
            wrap.innerHTML = `<img src="${e.target.result}"
                        style="width:100%;height:100%;object-fit:cover;border-radius:10px;" />`;
        };
        reader.readAsDataURL(input.files[0]);
    }
}