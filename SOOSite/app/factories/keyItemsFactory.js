app.factory('keyItemsFactory',
    ['$rootScope', 'Hub', '$q',
        function ($rootScope, Hub, $q) {
            var hub;
            var factory = this;
            var viewModel;
            var deferred = $q.defer();

            factory.initialize = function (callback) {
                hub = new Hub('KeyItemHub', {
                    listeners: {
                        'refreshModel': function (categories, keyItems, fullRefresh) {

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

            factory.addNewCategory = function () {

            }

            factory.addNewKeyItem = function () {
                if (viewModel.KeyItems.length > 0) {

                    var existing = viewModel.KeyItems[viewModel.KeyItems.length - 1];

                    if (!existing.Name || !existing.Description) return;
                }

                viewModel.KeyItems.push({
                    KeyItemID: 0,
                    Name: '',
                    Description: '',
                    KeyItemCategoryID: viewModel.ActiveKeyItemCategoryID
                })
            }

            factory.saveChanges = function () {
                hub.saveChanges(viewModel.KeyItemCategories, viewModel.KeyItems);
            }

            factory.changeTab = function (keyItemCategoryID) {
                viewModel.ActiveKeyItemCategoryID = keyItemCategoryID;
            }

            return factory;
        }
    ]);