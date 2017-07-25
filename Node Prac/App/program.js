Function.prototype.method = function (name, func) {
    this.prototype[name] = func;
    return this;
}

var a = { Fname: 'Siddharth', LName: 'gupta' };

a.mname = '____';

var b = a;
a.Fname = 'aaaa';



var stooge = {
    "first-name": "Jerome",
    "last-name": "Howard",
    number: 10
};
if (typeof Object.create !== 'function') {
    Object.create = function (o) {
        var F = function () { };
        F.prototype = o;
        return new F();
    };
}
var another_stooge = Object.create(stooge);

another_stooge['first-name'] = 'harry';
//alert(stooge['first-name']);

stooge.prof = 'professor';
another_stooge.prof = 'teacher';

/*alert(another_stooge.prof);
alert('typeof---' + typeof stooge.number);
alert('typeof---' + typeof stooge.code);
alert('hasOwnProperty: number---' + stooge.hasOwnProperty('number'));
alert('hasOwnProperty: fname---' + stooge.hasOwnProperty('first-name'));
alert('hasOwnProperty: const---' + stooge.hasOwnProperty('constructor'));
*/

delete another_stooge.prof;
//alert(another_stooge.prof);

//Method invocation
var myObject = {
    value: 0,
    increment: function (inc) {
        this.value += typeof inc === 'number' ? inc : 1;
    }
};
//myObject.increment();
document.writeln(myObject.value);
myObject.increment(2);
document.writeln(myObject.value);

//Function invocation
var add = function (a, b) {
    return a + b;
};
var s = add(3, 4);
myObject.double = function () {
    var that = this; // Workaround.
    var helper = function () {
        that.value = add(that.value, that.value);
    };
    helper(); // Invoke helper as a function.
};
// Invoke double as a method.
myObject.double();
document.writeln(myObject.value);


//The Constructor Invocation Pattern
var Quo = function (string) {
    this.status = string;
};

Quo.prototype.get_status = function () {
    return this.status;
};


var myQuo = new Quo('mixed');
document.writeln(myQuo.get_status());


//The Apply Invocation Pattern
var statusObject = {
    status: 'A-OK'
};

var stat = Quo.prototype.get_status.apply(statusObject);
document.writeln(stat);
