app.controller("authorizedDMsController", [
    '$scope', 'authorizedDMFactory', function ($scope, authorizedDMFactory) {
        authorizedDMFactory.initialize(function (data) {
            $scope.viewModel = data;
            $scope.$apply();
        });

        $scope.addNew = function () {
            authorizedDMFactory.addNew();
        }

    }
]);


