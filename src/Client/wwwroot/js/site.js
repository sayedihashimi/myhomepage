window.MySetFocus = (ctrl) => {
    console.log("trying to get focus");
    document.getElementById(ctrl).focus();
    return true;
};

