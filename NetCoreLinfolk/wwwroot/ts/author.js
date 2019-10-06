var Author = /** @class */ (function () {
    function Author() {
        this.visits = 0;
    }
    Author.prototype.showName = function (name) {
        alert(name);
        return true;
    };
    return Author;
}());
var author = new Author();
author.visits = 10;
//# sourceMappingURL=author.js.map