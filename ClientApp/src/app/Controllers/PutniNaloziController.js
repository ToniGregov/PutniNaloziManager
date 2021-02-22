"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PutniNaloziController = void 0;
var PutniNaloziController = /** @class */ (function () {
    function PutniNaloziController(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    PutniNaloziController.prototype.GetAllAutomobili = function () {
        return this.http.get(this.baseUrl + 'api/PutniNalozi/Automobili');
    };
    PutniNaloziController.prototype.GetAutoById = function (id) {
        this.http.get(this.baseUrl + 'api/PutniNalozi/Automobili/Details/' + id).subscribe(function (result) {
            return result;
        }, function (error) { return console.error(error); });
    };
    return PutniNaloziController;
}());
exports.PutniNaloziController = PutniNaloziController;
//# sourceMappingURL=PutniNaloziController.js.map