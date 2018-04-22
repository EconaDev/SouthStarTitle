function CheckIfSelected(list, buttonId) {
    var listbox = document.getElementsByName(list.id);
    var button = document.getElementById('ctl00_Content_' + buttonId);

    if (listbox[0].selectedIndex > -1) {
        for (var i = 0; i < listbox[0].options.length; ++i)
            if (listbox[0].options[i].selected) {
                button.disabled = false;
            }
    }
    else {
        button.disabled = true;
    }
}
