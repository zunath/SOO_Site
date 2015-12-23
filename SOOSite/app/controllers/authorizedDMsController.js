app.controller("authorizedDMsController", [
    '$scope', 'authorizedDMFactory', function ($scope, authorizedDMFactory) {
        authorizedDMFactory.initialize(function (viewModel) {
            $scope.viewModel = viewModel;
            $scope.$apply();
        });

        $scope.addNew = function () {
            authorizedDMFactory.addNew();
        }

        $scope.saveChanges = function () {
            authorizedDMFactory.saveChanges();
        }

    }
]);


