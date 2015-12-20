app.service("playerListService",['$rootScope', 'Hub', function($rootScope, Hub) {
    var hub = new Hub('ChatHub', {
        
        methods: ['sendMessage'],
        errorHandler: function(error) {
            alert('error: ' + error);
        }

    });

    var sendMessage = function(message) {
        hub.sendMessage(message);
    }

    return {
        sendMessage: sendMessage
    };
}]);