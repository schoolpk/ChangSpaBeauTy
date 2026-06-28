
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
// Preview trademark tags realtime
const tmInput = document.querySelector('input[name="TradeMark"]');
const tmPreview = document.getElementById('tm-preview');

function renderTmTags() {
    const val = tmInput?.value ?? '';
    const tags = val.split(',').map(t => t.trim()).filter(t => t.length > 0);
    tmPreview.innerHTML = tags.map(t =>
        `<span style="display:inline-block;background:#FFF0F5;color:#D6336C;
                      border:1px solid #FFB6C1;border-radius:20px;
                      padding:3px 12px;font-size:.78rem;font-weight:600;">
            💄 ${t}
        </span>`
    ).join('');
}

tmInput?.addEventListener('input', renderTmTags);
renderTmTags(); // render ngay khi load