var module = angular.module("homeIndex", []);

module.config(function($routeProvider) {
    $routeProvider.when("/", {
        controller: "topicsController",
        templateUrl: "templates/topicsView.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });

    $routeProvider.when("/newmessage", {
        controller: "newTopicController",
        templateUrl: "templates/newTopicView.html"
    });

});

function topicsController($scope, $http) {
    $scope.data = [];
    $scope.isBusy = true;

    $http.get("/api/v1/topics?includeReplies=true")
        .then(function(result) {
            // Successful
            angular.copy(result.data, $scope.data);
        },
            function() {
                // Error
                alert('Error loading data');
            })
        .then(function() {
            $scope.isBusy = false;
        });
}

function newTopicController($scope, $http, $window) {
    
}