BookmarkApp = function () {
    var isIEmac = false;
    var isMSIE = (-[1, ]) ? false : true;
    var cjTitle = "華邦e停車";
    var cjHref = 'http://202.39.229.116';

    function hotKeys() {
        var ua = navigator.userAgent.toLowerCase();
        var str = '';
        var isWebkit = (ua.indexOf('webkit') != -1);
        var isMac = (ua.indexOf('mac') != -1);

        if (ua.indexOf('konqueror') != -1) {
            str = 'CTRL + B';
        } else if (window.home || isWebkit || isIEmac || isMac) {
            str = (isMac ? '' : 'CTRL') + '+D';
        }
        return ((str) ? 'Press' + str + ' to bookmark this page.' : str);
    }

    function isIE8() {
        var rv = -1;
        if (navigator.appName == 'Microsoft Internet Explorer') {
            var ua = navigator.userAgent;
            var re = new RegExp("MSIE ([0-9]{1,}[.0-9]{0,})");
            if (re.exec(ua) != null) {
                rv = parseFloat(RegExp.$1);
            }
        }
        if (rv > -1) {
            if (rv >= 8.0) {
                return true;
            }
        }
        return false;
    }

    function addBookmark(a) {
        try {
            if (typeof a == "object") {
                if (!a.tagName) {
                    alert('is not tag.');
                    return false;
                }
                if (a.tagName.toLowerCase() != "a") {
                    alert('is not \'a\' tag.');
                    return false;
                }
                a.style.cursor = 'pointer';
                if ((typeof window.sidebar == "object") && (typeof window.sidebar.addPanel == "function")) {
                    window.sidebar.addPanel(cjTitle, cjHref, ""); //Gecko
                    return false;
                } else if (isMSIE && typeof window.external == "object") {
                    if (isIE8()) {
                        window.external.AddToFavoritesBar(cjHref, cjTitle); // IE 8
                    } else {
                        window.external.AddFavorite(cjHref, cjTitle); // IE <=7
                    }
                    return false;
                } else if (window.opera) {
                    a.href = cjHref;
                    a.title = cjTitle;
                    a.rel = 'sidebar'; // Opera 7+
                    return true;
                } else {
                    alert(hotKeys());
                }
            } else {
                throw "Error occured.rnNote, only A tagname is allowed!";
            }
        } catch (e) {
            alert(e);
        }
    }

    return {
        addBookmark : addBookmark
    }
}();
