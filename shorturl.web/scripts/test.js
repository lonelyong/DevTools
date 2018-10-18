var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var A = /** @class */ (function () {
    function A(iname) {
        /**
         * print hello world
         */
        this.hi = function () {
            console.log(name + " hi");
        };
        this.name = iname;
    }
    A.prototype.say = function () {
        console.log("i am " + this.name);
    };
    return A;
}());
var B = /** @class */ (function (_super) {
    __extends(B, _super);
    function B(iname) {
        var _this = _super.call(this, iname) || this;
        _this.hi = function () {
            _super.prototype.say.call(_this);
        };
        return _this;
    }
    return B;
}(A));
var b = new B("tom");
b.hi();
