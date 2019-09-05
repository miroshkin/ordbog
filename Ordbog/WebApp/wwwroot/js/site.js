// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addSymbolToSearchString(symbol) {
    $('#SearchString').val($('#SearchString').val() + symbol);
    $('#SearchString').focus();
}