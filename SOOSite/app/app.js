var app = angular.module("sooApp", ["ngRoute", "ui.bootstrap"]);

app.config([
    "$routeProvider", function ($routeProvider) {
        $routeProvider.when("/", {
            templateUrl: "/app/views/home.html",
            controller: "homeController"
        })
        .when("/factions", {
            templateUrl: "/app/views/factions.html",
            controller: "factionsController"
        })
        .when("/authorizeddms", {
            templateUrl: "/app/views/authorizeddms.html",
            controller: "authorizedDMsController"
        })
        .when("/keyitems", {
            templateUrl: "/app/views/keyitems.html",
            controller: "keyItemsController"
        })
        .otherwise({
            redirectTo: "/"
        });
    }
]);
