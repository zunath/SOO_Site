app.factory('moduleEditorFactory',
    ['$rootScope', 'Hub', '$q',
        function($rootScope, Hub, $q) {
            var hub;
            var factory = this;
            var viewModel;
            var deferred = $q.defer();

            factory.initialize = function(callback) {
                hub = new Hub('ModuleEditorHub', {
                    listeners: {
                        
                    },
                    methods: ['initializeVM'],
                    hubDisconnected: function() {
                        if (hub.connection.lastError) {
                            hub.connection.start();
                        }
                    }
                });

                hub.promise.done(function() {
                    hub.initializeVM().done(function(data) {
                        viewModel = data;
                        callback(viewModel);
                        deferred.resolve(hub);
                    });
                });

                return deferred.promise;
            }

            return factory;
        }
    ]);