window.DetailController = function($scope, $http, $location, $routeParams) {
    $scope.titleDetail = "Đây là trang chi tiết học viên";
    const apiCustomer = "http://localhost:3000/customer";
    
    // Get detail
    let id1 = $routeParams.id;
    $http.get(`${apiCustomer}/${id1}`).then(function(response) {
        if (response.status == 200) {
            $scope.inputCustomer = {
                id: response.data.id,
                name: response.data.name,
                email: response.data.email,
                cccd: response.data.cccd,
                phoneNumber: response.data.phoneNumber,
                gender: response.data.gender,
                date: new Date(response.data.date),
                course: response.data.course
            }
        }
    });
   

    
};
