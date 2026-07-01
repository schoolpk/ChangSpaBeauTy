// Tăng/giảm số lượng
function changeQty(idx, delta) {
    const input = document.getElementById(`qty-${idx}`);
    const val = parseInt(input.value) || 1;
    input.value = Math.max(1, val + delta);
}

// Xóa sản phẩm khỏi đơn — ẩn row + disable inputs để không submit
function removeItem(idx) {
    const row = document.getElementById(`item-row-${idx}`);
    if (!row) return;

    const remaining = document.querySelectorAll('.co-item:not([style*="display: none"])').length;
    if (remaining <= 1) {
        alert('Đơn hàng phải có ít nhất 1 sản phẩm. Nếu muốn hủy toàn bộ, hãy dùng nút Hủy đơn hàng.');
        return;
    }

    row.style.display = 'none';
    // Disable tất cả input trong row để không submit lên server
    row.querySelectorAll('input').forEach(inp => inp.disabled = true);
}

// Xác nhận hủy đơn
function confirmCancel(orderId) {
    if (confirm(`Bạn chắc chắn muốn hủy đơn hàng #${orderId}?`)) {
        document.getElementById('cancel-form').submit();
    }
}