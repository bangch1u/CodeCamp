window.CustomerController = function ($scope, $http, $location, $routeParams) {
    $scope.title = "Danh sách học viên"

    //link api
    //const apiCustomer = 'https://localhost:7224/api/sinhvien'
    const apiCustomer = 'https://localhost:7026/api/Book'
    //method getAll data in list Customers
    function getAll() {

        //call API to get data in list Customer 
        //used method HTTP Get
        $http.get(apiCustomer).then(function (response) {
            if (response.status == 200) {
                $scope.listCustomer = response.data
                console.log(response)
            } else {
                console.log("Không thể truy cập dữ liệu!")
            }
        });
    }
    getAll();
    //-------------------------------------------------------------
    //method create Customer
    // $scope.createCustomer = function () {
    //     //create new obj Customer 
    //     let newCustomer = {
    //         name: $scope.inputCustomer.name,
    //         email: $scope.inputCustomer.email,
    //         cccd: $scope.inputCustomer.cccd,
    //         phoneNumber: $scope.inputCustomer.phoneNumber,
    //         gender: $scope.inputCustomer.gender,
    //         date: $scope.inputCustomer.date,
    //         course: $scope.inputCustomer.course
    //     }
    //     //used method HTTP Post
    //     $http.post(apiCustomer, newCustomer).then(function (response) {
    //         if (response.status == 201) {
    //             console.log("Bạn đã thêm dữ liệu thành công")
    //             $location.path('/list-customer')
    //         } else {
    //             console.log("Thêm thất bại!")
    //         }
    //     });
    // }
    //----------------------------------------------------------------------
    $scope.deleteCustomer = function (id) {
        let confirm = window.confirm("Bạn có muốn xóa không")
        if (confirm) {
            $http.delete(`${apiCustomer}/${id}`).then(function (response) {
                if (response.status == 200) {
                    alert("Bạn đã xóa thành công");
                    getAll();
                }
            })
        }
    }
    // //--------------------------------------------------------------------------
    // $scope.getCustomerByID = function (id) {
    //     console.log(id)
    //     $http.get(`${apiCustomer}/${id}`).then(function (response) {
    //         if (response.status == 200) {
    //             $scope.selectCustomer = response.data
    //             $scope.selectDate = {}; // Khởi tạo selectDate trước khi gán giá trị
    //             $scope.selectDate = new Date(response.data.date);

    //             console.log(response)
    //         } else {
    //             console.log("Không thể truy cập dữ liệu!")
    //         }
    //     });
    // }
    //--------------------------------------------------------------------------------
    // $scope.editCustomer = function (id) {
    //     let updateCustomer = {
    //         id: $scope.selectCustomer.id,
    //         name: $scope.selectCustomer.name,
    //         email: $scope.selectCustomer.email,
    //         cccd: $scope.selectCustomer.cccd,
    //         phoneNumber: $scope.selectCustomer.phoneNumber,
    //         gender: $scope.selectCustomer.gender,
    //         date: $scope.selectDate,
    //         course: $scope.selectCustomer.course
    //     }
    //     $http.put(`${apiCustomer}/${id}`, updateCustomer).then(function (response) {
    //         if (response.status == 200) {
    //             alert("Cập nhập thành công")

    //         }

    //     })
    //     console.log(updateCustomer)
    // }
    //---------------------------------------------------
    // //get detail
    // let id1 = $routeParams.id
    
    // $http.get(`${apiCustomer}/${id1}`).then(function (response) {
    //     if (response.status == 200) {
    //         $scope.inputCustomer = {
    //             name: response.data.name,
    //             email: response.data.email,
    //             cccd: response.data.cccd,
    //             phoneNumber: response.data.phoneNumber,
    //             gender: response.data.gender,
    //             date: new Date(response.data.date),
    //             //course: response.data.course
    //         }
    //     }
    // })

    $scope.customFilter = function(cus) {
        if (!$scope.timKiem) {
            return true; 
        }
        
        var search = $scope.timKiem.toLowerCase();
        var genderText = cus.gender == 0 ? "nam" : (cus.gender == 1 ? "nữ" : "chưa biết");

        return (
            cus.name.toLowerCase().includes(search) ||
            cus.email.toLowerCase().includes(search) ||
            cus.phoneNumber.toLowerCase().includes(search) ||
            genderText.includes(search) ||
            new Date(cus.date).toLocaleDateString("en-GB").includes(search) ||
            cus.course.toLowerCase().includes(search)
        );
    };
}
const express = require('express');
const axios = require('axios');

const app = express();
const port = 3000;

// Route để gọi API từ Web API C# 
app.get('/api/data', async (req, res) => {
    try {
        // Gọi đến Web API C# (đảm bảo URL đúng)
        const response = await axios.get('https://localhost:7224/api/sinhvien');
        res.json(response.data);
    } catch (error) {
        console.error('Error fetching data from Web API:', error);
        res.status(500).send('Error fetching data');
    }
});

app.listen(port, () => {
    console.log(`Node.js server is running on http://localhost:${port}`);
});
