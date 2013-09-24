function homeIndexController($scope, $http) {
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