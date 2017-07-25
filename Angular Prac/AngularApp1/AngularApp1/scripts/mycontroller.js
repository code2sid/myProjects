(function () {
    app.controller("MyController", function ($scope) {
        $scope.article = "IIFE - First App";
        $scope.myVar = "IIFE - First variable";
    });
    var bookStore = function ($scope,$filter) {

        $scope.orderField = "ISBN";
        $scope.isOrderDescending = true;
        $scope.modelfilter = $filter("uppercase")("Test msg");

        $scope.Types = ["Fiction", "Sci-Fi", "Action", "Comedy", "Love", "Educational"];
        $scope.items = [
            { ISBN: 121, Name: "Angular 1.0", Price: 350.12, Quantity: 18, Type: "Educational" },
            { ISBN: 122, Name: "Angular 1.5", Price: 199.56, Quantity: 20, Type: "Educational" },
            { ISBN: 123, Name: "Angular 2.0", Price: 155.75, Quantity: 8, Type: "Educational" },
            { ISBN: 124, Name: "MVC", Price: 500.67, Quantity: 10, Type: "Educational" },

        ];


        $scope.totalPrice = function () {
            var grandTotal = 0;
            for (var i = 0; i < $scope.items.length; i++) {
                grandTotal += $scope.items[i].Price * $scope.items[i].Quantity;
            }

            return grandTotal;
        };

        $scope.chkvalidation = function () {
            if (bookForm.txtISBN.$invalid)
                return true;

        };

        $scope.addItem = function (item) {
            $scope.items.splice(0, 0, item);
            $scope.item = {};

        };

        $scope.removeItem = function (index) {
            $scope.items.splice(index, 1);

        };

        $scope.GetOrderBy = function () {
            if ($scope.isOrderDescending)
                return "-" + $scope.orderField;
            else
                return "" + $scope.orderField;
        }

    }


    app.controller("BookStore", ["$scope","$filter",bookStore]);

}());



