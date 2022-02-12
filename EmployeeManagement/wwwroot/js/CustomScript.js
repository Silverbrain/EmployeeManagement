function confirmDelete(userId, isDeleteSelected)
{
    var deleteSpan = 'deleteSpan_' + userId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + userId;

    if(isDeleteSelected)
    {
        $('#' + confirmDeleteSpan).show();
        $('#' + deleteSpan).hide();
    }
    else
    {
        $('#' + confirmDeleteSpan).hide();
        $('#' + deleteSpan).show();
    }
}