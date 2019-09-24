// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addSymbolToSearchString(symbol) {

    var cursorPos = $('#SearchString').prop('selectionStart');
    var v = $('#SearchString').val();
    var textBefore = v.substring(0, cursorPos);
    var textAfter = v.substring(cursorPos, v.length);
    $('#SearchString').val(textBefore + symbol + textAfter);
    $('#SearchString').focus();
}