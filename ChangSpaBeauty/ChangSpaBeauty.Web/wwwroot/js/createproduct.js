
        // --- Image preview ---
    const imageInput = document.getElementById('imageInput');
    const previewWrap = document.getElementById('previewWrap');
    const imgPreview = document.getElementById('imgPreview');
    const uploadArea = document.getElementById('uploadArea');
    const uploadPlaceholder = document.getElementById('uploadPlaceholder');

    imageInput.addEventListener('change', function () {
            const file = this.files[0];
    if (!file) return;

            // Validate size (5MB)
            if (file.size > 5 * 1024 * 1024) {
        alert('Ảnh quá lớn! Vui lòng chọn ảnh dưới 5MB.');
    this.value = '';
    return;
            }

    const reader = new FileReader();
            reader.onload = e => {
        imgPreview.src = e.target.result;
    previewWrap.style.display = 'block';
    uploadPlaceholder.style.display = 'none';
            };
    reader.readAsDataURL(file);
        });

    function removeImage() {
        imageInput.value = '';
    imgPreview.src = '#';
    previewWrap.style.display = 'none';
    uploadPlaceholder.style.display = 'block';
        }

        // --- Drag & Drop ---
        uploadArea.addEventListener('dragover', e => {
        e.preventDefault();
    uploadArea.classList.add('dragover');
        });

        uploadArea.addEventListener('dragleave', () => {
        uploadArea.classList.remove('dragover');
        });

        uploadArea.addEventListener('drop', e => {
        e.preventDefault();
    uploadArea.classList.remove('dragover');
    const file = e.dataTransfer.files[0];
    if (file && file.type.startsWith('image/')) {
                const dt = new DataTransfer();
    dt.items.add(file);
    imageInput.files = dt.files;
    imageInput.dispatchEvent(new Event('change'));
            }
        });

    // --- Loading spinner on submit ---
    document.getElementById('createForm').addEventListener('submit', function () {
            const btn = document.getElementById('submitBtn');
    const spinner = document.getElementById('spinner');
    btn.disabled = true;
    spinner.style.display = 'block';
    btn.querySelector('span:last-child') && (btn.lastChild.textContent = ' Đang lưu...');
        });
