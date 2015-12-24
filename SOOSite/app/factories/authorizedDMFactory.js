app.factory('authorizedDMFactory',
    ['$rootScope', 'Hub', '$q',
        function ($rootScope, Hub, $q) {
            var hub;
            var factory = this;
            var viewModel;
            var deferred = $q.defer();

            factory.initialize = function(callback) {
                hub = new Hub('AuthorizedDMHub', {
                    listeners: {
                        'refreshDMList': function (dmList, totalRefresh) {
                            var uncommitted = [];

                            if (!totalRefresh) {
                                $(viewModel.AuthorizedDMs).each(function (index, value) {
                                    if (value.AuthorizedDMID == 0) {
                                        uncommitted.push(value);
                                    }
                                });
                            }

                            viewModel.AuthorizedDMs = dmList;

                            $(uncommitted).each(function (index, value) {
                                viewModel.AuthorizedDMs.push(value);
                            });
                                        
                            $rootScope.$apply();
                        }
                    },
                    methods: ['initializeVM', 'saveChanges'],
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

                if (viewModel.AuthorizedDMs.length > 0) {
                    var existing = viewModel.AuthorizedDMs[viewModel.AuthorizedDMs.length - 1];

                    if (!existing.Name || !existing.CDKey) return;
                }
        
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
        }
    ]);