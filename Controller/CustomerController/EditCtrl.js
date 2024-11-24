window.EditCtrl = function($scope, $http, $location, $routeParams){
    $scope.titleEdit = "Cập nhập thông tin học viên:"
    const apiCustomer = "http://localhost:3000/customer"
     // //get detail
    let id1 = $routeParams.id
    
    $http.get(`${apiCustomer}/${id1}`).then(function (response) {
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
    })
    $scope.editCustomer = function () {
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
        if(flag){
            //create new obj Customer 
        let Customer = {
            id: $scope.inputCustomer.id,
            name: $scope.inputCustomer.name,
            email: $scope.inputCustomer.email,
            cccd: $scope.inputCustomer.cccd,
            phoneNumber: $scope.inputCustomer.phoneNumber,
            gender: $scope.inputCustomer.gender,
            date: $scope.inputCustomer.date,
            course: $scope.inputCustomer.course
        }
        //used method HTTP Post
        $http.put(`${apiCustomer}/${id1}`, Customer).then(function (response) {
            if (response.status == 200) {
                //console.log("Bạn đã sửa dữ liệu thành công")
                $location.path('/list-customer')
            } else {
                console.log("Thêm thất bại!")
            }
        });
        }
    }
}