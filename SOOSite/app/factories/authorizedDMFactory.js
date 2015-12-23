app.factory('authorizedDMFactory', ['$rootScope', 'Hub', '$q', function ($rootScope, Hub, $q) {
    var hub;
    var factory = this;
    var viewModel;
    var deferred = $q.defer();

    factory.initialize = function(callback) {

        hub = new Hub('AuthorizedDMHub', {
            listeners: {
                'refreshDMList': function (dmList) {
                    var uncommitted = $.grep(viewModel.AuthorizedDMs, function (e) {
                        return e.AuthorizedDMID == 0;
                    })
                    viewModel.AuthorizedDMs = dmList;
                    if (!uncommitted) {
                        alert(JSON.stringify(uncommitted));
                        viewModel.AuthorizedDMs.push(uncommitted);
                    }
                    
                    $rootScope.$apply();
                }
            },

            methods: ['initializeVM', 'saveChanges'],
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
                viewModel = data;
                callback(viewModel);
                deferred.resolve(hub);
            });
        });

        return deferred.promise;
    }

    factory.addNew = function () {
        var existing = viewModel.AuthorizedDMs[viewModel.AuthorizedDMs.length - 1];

        if (!existing.Name || !existing.CDKey) return;

        viewModel.AuthorizedDMs.push({
            AuthorizedDMID: 0,
            Name: '',
            CDKey: '',
            DMRole: 1,
            IsActive: true
        });
    }

    factory.saveChanges = function () {
        hub.saveChanges(viewModel.AuthorizedDMs);
    }

    return factory;
}]);