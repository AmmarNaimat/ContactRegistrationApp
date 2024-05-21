

$(document).ready(function () {
    $('#searchInput').on('input', function () {
        var searchQuery = $(this).val().toLowerCase();
        $('#tblContact tr').filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(searchQuery) > -1)
        });
    });
});