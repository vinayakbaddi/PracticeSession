var model = { user: 'adam', items: [{ action: "Buy flowers", done: false }, { action: "Get shoes", done: false }] };

angular.module('try').controller('tryController', function ($scope) {
    $scope.todo = model;
});