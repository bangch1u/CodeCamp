window.AddCtrl = function ($scope, $http, $routeParams, $location) {
    $scope.titleAddCus = "Đây là form đăng ký học viên"
    const linkAPi = "http://localhost:3000/customer"
    $scope.AddCustomer = function () {
        let flag = true;//variable test valid
        $scope.notificationTest = {
            name: false,
            email: false,
            cccd: false,
            phoneNumber: false,
            gender: false,
            date: false,
            course: false
        }

        //test null
        if (!$scope.inputCustomer || !$scope.inputCustomer.name) {
            flag = false
            $scope.notificationTest.name = true

        }
        if (!$scope.inputCustomer || !$scope.inputCustomer.email) {
            flag = false
            $scope.notificationTest.email = true
        }
        if (!$scope.inputCustomer || !$scope.inputCustomer.cccd) {
            flag = false
            $scope.notificationTest.cccd = true
        }
        if (!$scope.inputCustomer || !$scope.inputCustomer.phoneNumber) {
            flag = false
            $scope.notificationTest.phoneNumber = true
        }
        if (!$scope.inputCustomer || !$scope.inputCustomer.gender) {
            flag = false
            $scope.notificationTest.gender = true
        }
        if (!$scope.inputCustomer || !$scope.inputCustomer.date) {
            flag = false
            $scope.notificationTest.date = true
        }
        if (!$scope.inputCustomer || !$scope.inputCustomer.course) {
            flag = false
            $scope.notificationTest.course = true
        }
        console.log($scope.notificationTest)
        //check email 
        let emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        let checkEmail = emailRegex.test($scope.inputCustomer.email);
        if (!checkEmail) {
            flag = false;
            $scope.notificationTest.email = true;
        }
        //check số điện thoại 
        let phoneNumberRegex = /(((\+|)84)|0)(3|5|7|8|9)+([0-9]{8})\b/;
        let checkPhone = phoneNumberRegex.test($scope.inputCustomer.phoneNumber);
        if (!checkPhone) {
            flag = false;
            $scope.notificationTest.phoneNumber = true;
        }
        const regexNumber = /^\d*$/;
        let checkCCCD = regexNumber.test($scope.inputCustomer.cccd)
        if (!checkCCCD) {
            flag = false
            $scope.notificationTest.cccd = true
        }

        let date = new Date($scope.inputCustomer.date)
        let currentDate = new Date();
        //reset 
        date.setHours(0, 0, 0, 0);
        currentDate.setHours(0, 0, 0, 0);
        console.log(currentDate)
        console.log(date)
        if (date >= currentDate) {
            flag = false
            $scope.notificationTest.date = true
        }
        //used method HTTP Post
        if (flag) {
            let newCustomer = {
                name: $scope.inputCustomer.name,
                email: $scope.inputCustomer.email,
                cccd: $scope.inputCustomer.cccd,
                phoneNumber: $scope.inputCustomer.phoneNumber,
                gender: $scope.inputCustomer.gender,
                date: $scope.inputCustomer.date,
                course: $scope.inputCustomer.course
            }
            $http.post(linkAPi, newCustomer).then(function(response){
                if(response.status == 201){
                    
                    $location.path('/list-customer')
                }
            })
        }
    }
}