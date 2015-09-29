var app = angular.module("sooApp", ["ngRoute"]);

app.config([
    "$routeProvider", function($routeProvider) {
        $routeProvider.when("/", {
            templateUrl: "/app/templates/Home.template.html",
            controller: "/controllers/HomeController.js"
        }).otherwise({
                redirectTo: "/"
            });
    }
]);
