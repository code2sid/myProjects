app.controller("MyController", function ($scope) {
    $scope.article = "My first application in Angular !!!";
    $scope.myVar = "My first variable in Angular !!!";
});

app.controller("BookStore", function ($scope) {
    $scope.items = [
        { ISBN: 121, Name: "Angular 1.0", Price: 350.12, Quantity: 18 },
        { ISBN: 122, Name: "Angular 1.5", Price: 199.56, Quantity: 20 },
        { ISBN: 123, Name: "Angular 2.0", Price: 155.75, Quantity: 8 },
        { ISBN: 124, Name: "MVC", Price: 500.67, Quantity: 10 },


    ];


    $scope.totalPrice = function () {
        var grandTotal = 0;
        for (var i = 0; i < $scope.items.length; i++) {
            grandTotal += $scope.items[i].Price * $scope.items[i].Quantity;
        }

        return grandTotal;
    };




});