function switchTab(name, btn) {
    document.querySelectorAll('.admin-tab-nav .tab').forEach(b => b.classList.remove('active'));
    document.querySelectorAll('.admin-panel').forEach(p => p.classList.remove('active'));
    btn.classList.add('active');
    document.getElementById('panel-' + name).classList.add('active');
}

function filterTable(tableId, query) {
    var q = query.toLowerCase();
    document.querySelectorAll('#' + tableId + ' tbody tr').forEach(function (row) {
        row.style.display = row.textContent.toLowerCase().includes(q) ? '' : 'none';
    });
}
// Filter rows trong bảng orders theo status
function filterOrders(status, btn) {
    // Highlight tab active
    document.querySelectorAll('.order-filter-tab').forEach(b => b.classList.remove('active'));
    btn.classList.add('active');

    // Show/hide rows
    const rows = document.querySelectorAll('#tbl-orders tbody tr[data-status]');
    rows.forEach(row => {
        if (status === 'all' || row.dataset.status === status) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
}