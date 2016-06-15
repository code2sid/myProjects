<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="AngularApp1.TestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="src js/angular.min.js"></script>
    <script src="scripts/app.js" type="text/javascript"></script>
    <script src="scripts/mycontroller.js" type="text/javascript"></script>
</head>
<body ng-app='MyApp'>
    <div id='content' ng-controller='MyController'>
        <h1>{{ article}}!!!!</h1>
        <h3>{{ myVar }}</h3>
    </div>

    <div ng-controller="BookStore" style="display: none;">
        <table class="mytable">
            <tr>
                <td>
                    <span>Below output is produced from AngularJS's <strong>{{}}</strong> directive.</span>
                </td>
            </tr>
            <tr ng-repeat="item in items">
                <td>
                    <p><b>{{item.Name}}</b> is in our stock.</p>
                </td>
            </tr>
        </table>
        <table class="mytable">
            <tr>
                <td>
                    <span>Below output is produced from AngularJS's <strong>ng-bind</strong> directive.</span>
                </td>
            </tr>
            <tr ng-repeat="item in items">
                <td>
                    <p><b><span ng-bind="item.Name"></span></b>is in our stock.</p>
                </td>
            </tr>
        </table>
        <table class="mytable">
            <tr>
                <td>
                    <span>Below output is produced from AngularJS's <strong>ng-non-bindable</strong> directive.</span>
                </td>
            </tr>
            <tr ng-repeat="item in items">
                <td>
                    <div ng-non-bindable>
                        <p><b>{{item.Name}}</b> is in our stock.</p>
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <div ng-controller="BookStore">
        <h2>Add New Book</h2>
        <div style="border: 1px solid blue;">
            <table>
                <tr>
                    <td>ISBN: </td>
                    <td>
                        <input type="text" ng-model="item.ISBN" />
                    </td>
                </tr>
                <tr>
                    <td>Name: </td>
                    <td>
                        <input type="text" ng-model="item.Name" />
                    </td>
                </tr>
                <tr>
                    <td>Price(In Rupee): </td>
                    <td>
                        <input type="number" ng-model="item.Price" />
                    </td>
                </tr>
                <tr>
                    <td>Quantity: </td>
                    <td>
                        <input type="number" ng-model="item.Quantity" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="Button" value="Add to list" ng-click="addItem(item)" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="padding-top: 15px;display:block;">
            <table border="1" class="mytable">
                <tr>
                    <td>ISBN</td>
                    <td>Name</td>
                    <td>Price</td>
                    <td>Quantity</td>
                    <td>Total Price</td>
                    <td>Action</td>
                </tr>


                <tr ng-repeat="item in items">
                    <td>{{item.ISBN}}</td>
                    <td>
                        <span ng-hide="editMode">{{item.Name}}</span>
                        <input type="text" ng-show="editMode" ng-model="item.Name" />
                    </td>
                    <td>
                        <span ng-hide="editMode">{{item.Price}}</span>
                        <input type="number" ng-show="editMode" ng-model="item.Price" />
                    </td>
                    <td>
                        <span ng-hide="editMode">{{item.Quantity}}</span>
                        <input type="number" ng-show="editMode" ng-model="item.Quantity" /></td>
                    <td>{{(item.Quantity) * (item.Price)}}</td>
                    <td>
                        <span>
                            <button type="submit" ng-hide="editMode" ng-click="editMode = true; editItem(item)">Edit</button></span>
                        <span>
                            <button type="submit" ng-show="editMode" ng-click="editMode = false">Save</button></span>
                        <span>
                            <input type="button" value="Delete" ng-click="removeItem($index)" /></span>
                    </td>
                </tr>

            </table>
        </div>
        <br />
        <div style="font-weight: bold">Grand Total: {{totalPrice()}}</div>
        <br />
    </div>

</body>
</html>
