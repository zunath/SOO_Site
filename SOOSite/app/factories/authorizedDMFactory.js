app.factory('authorizedDMFactory', ['$rootScope', 'Hub', '$q', function ($rootScope, Hub, $q) {
    var factory = this;
    var hub;
    var deferred = $q.defer();

    factory.Initialize = function(callback) {

        hub = new Hub('AuthorizedDMHub', {

            methods: ['initializeVM'],
            errorHandler: function (error) {
                alert('error: ' + error);
            },
            hubDisconnected: function () {
                if (hub.connection.lastError) {
                    hub.connection.start();
                }
            }
        });

        hub.promise.done(function () {
            hub.initializeVM().done(function (data) {
                callback(data);
                deferred.resolve(hub);
            });
        });

        return deferred.promise;
    }

    return factory;
}]);