(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            //Section o1 -Set URL
            var logo = document.getElementsByClassName('link');
            logo[0].href = "https://localhost:7068/swagger/v1/swagger.json/";
            logo[0].target = "_blank";

            //Section 02-Set Logo
            logo[0].children[0].alt = "Implemeting Swagger";
            logo[0].children[0].src = "/swagger-custom/kk.png";

            // Section 03 - Set 32x32 favicon
            var linkIcon32 = document.createElement('link');
            linkIcon32.type = 'image/png';
            linkIcon32.rel = 'icon';
            linkIcon32.href = '/swagger-custom/kk.png';
            linkIcon32.sizes = '32x32';
            document.getElementsByTagName('head')[0].appendChild(linkIcon32);

            // Section 03 - Set 16x16 favicon
            var linkIcon16 = document.createElement('link');
            linkIcon16.type = 'image/png';
            linkIcon16.rel = 'icon';
            linkIcon16.href = '/swagger-custom/kk.png';
            linkIcon16.sizes = '16x16';
            document.getElementsByTagName('head')[0].appendChild(linkIcon16);  
        });
    });
})();

