app.controller("keyItemsController", [
    '$scope', 'keyItemsFactory', function ($scope, keyItemsFactory) {
        keyItemsFactory.initialize(function (viewModel) {
            $scope.viewModel = viewModel;
            $scope.$apply();
        });

        $scope.addNewKeyItem = function () {
            keyItemsFactory.addNewKeyItem();
        }

        $scope.saveChanges = function () {
            keyItemsFactory.saveChanges();
        }

        $scope.changeTab = function (keyItemCategoryID) {
            keyItemsFactory.changeTab(keyItemCategoryID);
        }
    }
]);