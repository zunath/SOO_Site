app.controller("moduleEditorController", [
    '$scope', 'moduleEditorFactory', function ($scope, moduleEditorFactory) {
        moduleEditorFactory.initialize(function(viewModel) {
            $scope.viewModel = viewModel;
            $scope.$apply();
        });

        $scope.openModule = function () {
            moduleEditorFactory.openModule();
        }

    }
]);