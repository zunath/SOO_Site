var app = angular.module("sooApp", ["ngRoute", "ui.bootstrap"]);

app.config([
    "$routeProvider", function ($routeProvider) {
        $routeProvider.when("/", {
            templateUrl: "/app/views/home.html",
            controller: "homeController"
        })
        .otherwise({
            redirectTo: "/"
        });
    }
]);
