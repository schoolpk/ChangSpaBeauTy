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