app.controller("authorizedDMsController", [
    '$scope', 'authorizedDMFactory', function ($scope, authorizedDMFactory) {
        authorizedDMFactory.Initialize(function (data) {
            $scope.viewModel = data;
            $scope.$apply();
        });
    }
]);


