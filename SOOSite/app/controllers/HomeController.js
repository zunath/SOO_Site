app.controller("homeController", [
    '$scope', 'playerListService', function ($scope, playerListService) {
        $scope.dataTest = "it's a test";

        $scope.sendMessage = function (message) {
            playerListService.sendMessage(message);
        }

    }
]);