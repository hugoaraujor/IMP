   
//define(['application-configuration', 'kendo', 'kendMXCulture', 'CargadorService', 'PlantillaService', 'jszip', 'Plotly'], function (app) {

    //app.register.controller('Surface_chartController', ['$scope', '$localStorage', '$rootScope', '$state', 'UploadURL', controladorManitor]);


  //  function controladorManitor($scope, $localStorage, $rootScope, $state, UploadURL) {

    
      //  window.JSZip = require("jszip");

        var vm = this;
        var gridresumen;
      //  const Plotly = require("./Plotly");
        

        /////////////////// javascript.js file contents begin here //////////////////

        function registerNameSpace(ns) {
            var nsParts = ns.split(".");
            var root = window;
            var n = nsParts.length;
            for (var i = 0; i < n; i++) {
                if (typeof root[nsParts[i]] === "undefined") root[nsParts[i]] = new Object();
                root = root[nsParts[i]];
            }
        }

        
        /**************************************************************  Servicios*********************************************************************************************/
        $(window).resize(function () {
         

        });

        $("#btn_surface_1").click(function () {
            createSurface_ploty();
        });


        var datossurface = [
                         { x: 1, y: 1, z: 3.05345338902965 },
                         { x: 1, y: 2, z: 6.1069067780593 },
                         { x: 1, y: 3, z: 9.16036016708895 },
                         { x: 1, y: 4, z: 12.2138135561186 },
                         { x: 1, y: 5, z: 15.2672669451482 },
                         { x: 2, y: 1, z: 4.66178879948832 },
                         { x: 2, y: 2, z: 9.32357759897665 },
                         { x: 2, y: 3, z: 13.985366398465 },
                         { x: 2, y: 4, z: 18.6471551979533 },
                         { x: 2, y: 5, z: 23.3089439974416 },
                         { x: 3, y: 1, z: 4.7448516029127 },
                         { x: 3, y: 2, z: 9.48970320582539 },
                         { x: 3, y: 3, z: 14.2345548087381 },
                         { x: 3, y: 4, z: 18.9794064116508 },
                         { x: 3, y: 5, z: 23.7242580145635 },
                         { x: 4, y: 1, z: 3.62204580183913 },
                         { x: 4, y: 2, z: 7.24409160367827 },
                         { x: 4, y: 3, z: 10.8661374055174 },
                         { x: 4, y: 4, z: 14.4881832073565 },
                         { x: 4, y: 5, z: 18.1102290091957 },
                         { x: 5, y: 1, z: 2.21194960576926 },
                         { x: 5, y: 2, z: 4.42389921153853 },
                         { x: 5, y: 3, z: 6.63584881730779 },
                         { x: 5, y: 4, z: 8.84779842307705 },
                         { x: 5, y: 5, z: 11.0597480288463 },
        ];



        function getMaxX(data) {
            
            return Math.max.apply(Math, data.map(function (o) { return o.x; }));
        }
        function getMinX(data) {
            return Math.min.apply(Math, data.map(function (o) { return o.x; }));
        }


        function getMaxY(data) {
            return Math.max.apply(Math, data.map(function (o) { return o.y; }));
        }
        function getMinY(data) {

            return Math.min.apply(Math, data.map(function (o) { return o.y; }));
        }

        function getMaxZ(data) {
            return Math.max.apply(Math, data.map(function (o) { return o.z; }));
        }
        function getMinZ(data) {

            return Math.min.apply(Math, data.map(function (o) { return o.z; }));
        }

function creaSurface(datos) {
 
            var cant_datos = datos.length;
            var min_puntos_Eje_X = getMinX(datos);
            var max_puntos_Eje_X = getMaxX(datos);

            var min_puntos_Eje_Y = getMinY(datos);
            var max_puntos_Eje_Y = getMaxY(datos);

            var puntos_Eje_X = 1000; (max_puntos_Eje_X - min_puntos_Eje_X) + 1;
            var puntos_Eje_Y = 1000; (max_puntos_Eje_Y - min_puntos_Eje_Y) + 1;

  
            var index_x = min_puntos_Eje_X;
            var index_y = min_puntos_Eje_Y;
            var idx = 0;
            var index_array = 0;
            var tooltipStrings = new Array();
            var datos_surface = [];
    for (var i = 0; i < puntos_Eje_X; i++) {
     
                datos_surface.push([]);
                index_y = min_puntos_Eje_Y
                for (var j = 0; j < puntos_Eje_Y; j++) {
                    for (var z = 0; z < cant_datos; z++) {
                        var elemento = datos[z];
                        var valor_x = elemento.x;
                        var valor_y = elemento.y;
                        var valor_z = elemento.z;
                        if (index_x === valor_x && index_y === valor_y) {
                            datos_surface[index_array].push(valor_z);
                            tooltipStrings[idx] = "x:" + valor_x + ", y:" + valor_y + " , Z:" + valor_z;
                            idx++;
                        }
                        if (valor_x > index_x) {
                            z = cant_datos + 1;
                        }
                    }
                    index_y++;
                }
                index_x++;
                index_array++;
            }

            var layout = {
                title: '',
                scene: { camera: { eye: { x: 1.87, y: 0.88, z: -0.64 } } },
                autosize: false,
                width: 500,
                height: 500,
                margin: {
                    l: 65,
                    r: 50,
                    b: 65,
                    t: 90,
                }
            };



            var data_z1 = {
                z: datos_surface,
                type: 'surface',
                contours: {
                    z: {
                        show: true,
                        usecolormap: true,
                        highlightcolor: "#42f462",
                        project: { z: true }
                    }
                }
    };

           Plotly.newPlot('surfacePlotDiv_Splot1', [data_z1], layout, { showSendToCloud: true, responsive: true });
 
        }
      
///////////////////////////////////////////////////////////////////////////////////////////////////////

//        $(document).ready(function () {
            
//            if ($rootScope.authentication.userName == '' || $rootScope.authentication.userName == ""
//                  || $rootScope.authentication.isAuth == false
//              ) {
//                authService.logOut();
//                window.location = ngAuthSettings.apiServiceBaseUriWeb;
//            }
//            creaSurface(datossurface);
//        });



   // }
//});


