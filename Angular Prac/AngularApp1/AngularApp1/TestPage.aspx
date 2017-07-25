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
    <button ng-click="counter = counter +1">Add one</button>
Current counter: {{ counter }}

    <div id='content' ng-controller='MyController'>
        <h1>{{article}}!!!!</h1>
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
                    <p><b><span ng-bind="item.Name"></span></b> is in our stock.</p>
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
        <form name="bookForm">
        <div style="border: 1px solid blue;">
            <table>
                <tr>
                    <td>ISBN: </td>
                    <td>
                        <input name="txtISBN" type="text" ng-model="item.ISBN" required />
                        <span ng-show="bookForm.txtISBN.$invalid">ISBN is mandatory</span>
                    </td>
                </tr>
                <tr>
                    <td>Name: </td>
                    <td>
                        <input type="text" ng-model="item.Name" />
                    </td>
                </tr>
                 <tr>
                    <td>Type: </td>
                    <td>
                        <select ng-model="item.Type" ng-options="Type for Type in Types"></select>
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
            </form>
        <br />
        <div style="border:double;padding: 5px;display:block;">
            Order by: <select ng-model="orderField">
                            <option>ISBN</option>
                            <option>Name</option>
                            <option>Type</option>
                            <option>Price</option>
                      </select>
            Descending: <input type="checkbox" ng-model="isOrderDescending" />
            Name: <input type="text" ng-model="filterstring" />
        </div>

        <div style="padding-top: 15px;display:block;">
            <table border="1" class="mytable">
                <tr>
                    <td>ISBN</td>
                    <td>Name</td>
                    <td>Type</td>
                    <td>Price</td>
                    <td>Quantity</td>
                    <td>Total Price</td>
                    <td>Action</td>
                </tr>


                <tr ng-repeat="item in items | filter:filterstring | orderBy: GetOrderBy()" >
                    <td>{{item.ISBN}}</td>
                    <td>
                        <span ng-hide="editMode">{{item.Name | uppercase }}</span>
                        <input type="text" ng-show="editMode" ng-model="item.Name" />
                    </td>
                    <td>
                        <span ng-hide="editMode">{{item.Type}}</span>
                        <select ng-show="editMode" ng-model="item.Type" ng-options="Type for Type in Types"
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
        <div>Uppercase model level Filter: {{ modelfilter}}</div>
        </div>
        <br />
        <div style="font-weight: bold">Grand Total: {{totalPrice()}}</div>
        <br />
    </div>

</body>
</html>
