var iCoach = window.iCoach || {};

iCoach.Lang = (function ($) {
    "use strict";

    var init = function () {
        iCoach.Lang.SwitchLanguage = function (lang) {
            $.cookie('language', lang, { expires: 365, path: '/' });
            window.location.reload();
        };

        $("#setRus").click(function () {
            iCoach.SwitchLanguage('ru');
        });
        $("#setEng").click(function () {
            iCoach.SwitchLanguage('en');
        });
    };

    return { init: init };
}($));

iCoach.GlobalLogic = (function ($) {
    "use strict";

    var ready = $(function () {
        iCoach.Lang.init();
    });
}($));