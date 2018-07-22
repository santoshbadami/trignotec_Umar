function successfull(tit, msg) {
    $.notify({
        title: tit,
        message: msg,
        icon: 'fa fa-check'
    }, {
        type: "success"
    });
}

function failed(tit, msg) {
    $.notify({
        title: tit,
        message: msg,
        icon: 'fa fa-check'
    }, {
        type: "danger"
    });
}

function information(tit, msg) {
    $.notify({
        title: tit,
        message: msg,
        icon: 'fa fa-check'
    }, {
        type: "info"
    });
}

function warning(tit, msg) {
    $.notify({
        title: tit,
        message: msg,
        icon: 'fa fa-check'
    }, {
        type: "warning"
    });
}