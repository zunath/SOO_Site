var app = angular.module("sooApp", ["ngRoute", "ui.bootstrap", "SignalR"]);

app.config([
    "$routeProvider", function ($routeProvider) {
        $routeProvider.when("/", {
            templateUrl: "/app/views/home.html",
            controller: "homeController"
        })
        .when("/:name", {
            templateUrl: function (params) {
                return "/app/views/" + params.name + ".html";
            },
            controller: ["$scope", "$routeParams", "$controller", function ($scope, $routeParams, $controller) {
                return $controller($routeParams.name + "Controller", { $scope: $scope });
            }]
        })
        .otherwise({
            redirectTo: "/"
        });
    }
]);
