let myApp = angular.module('myApp',['ngRoute']);
myApp.config(['$routeProvider',function($routeProvider){
    $routeProvider
    .when('/home',{
        templateUrl: 'View/home.html',
        controller: HomeController 
    })
    .when('/mentor',{
        templateUrl:'View/mentor.html',
    })
    .when('/khoaHoc',{
        templateUrl:'View/Fullstack.html',
        controller:AddCtrl
    })
    .when('/dataScience',{
        templateUrl:'View/DataScien.html',
        controller:AddCtrl
    })
    .when('/blog',{
        templateUrl:'View/Blog.html',
    })
    .when('/list-customer',{
        templateUrl:'View/CustomerView/listCustomer.html',
        controller:CustomerController
    })
    .when('/detail-customer/:id',{
        templateUrl:'View/CustomerView/DetailCustomer.html',
        controller: DetailController
    })
    .when('/edit-customer/:id',{
        templateUrl:'View/CustomerView/EditCustomer.html',
        controller: EditCtrl
    })
    .otherwise({
        redirectTo:'/home'
    })
}])