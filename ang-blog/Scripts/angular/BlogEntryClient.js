var BlogEntryApp = angular.module('BlogEntryApp', [])
 
BlogEntryApp.controller('BlogEntryController', function ($scope, BlogEntryService) {

    $scope.message = "hello controller";

    getBlogEntries();
    function getBlogEntries() {
        BlogEntryService.getBlogEntries()
            .success(function (studs) {
                $scope.blogEntries = studs;
                console.log($scope.blogEntries);
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }
});

BlogEntryApp.factory('BlogEntryService', ['$http', function ($http) {

    var BlogEntryService = {};
    BlogEntryService.getBlogEntries = function () {
        return $http.get('/BlogEntry/GetBlogEntries');
    };

    return BlogEntryService;

}]);