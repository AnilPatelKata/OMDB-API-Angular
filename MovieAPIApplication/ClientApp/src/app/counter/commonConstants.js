"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var CommonConstants = /** @class */ (function () {
    function CommonConstants() {
        this.requestCount = 0;
        if (CommonConstants._instance) {
            throw new Error("Error: Instantiation failed: Use CommonConstants.getInstance() instead of new.");
        }
        CommonConstants._instance = this;
    }
    CommonConstants.getInstance = function () {
        return CommonConstants._instance;
    };
    CommonConstants._instance = new CommonConstants();
    return CommonConstants;
}());
exports.CommonConstants = CommonConstants;
//# sourceMappingURL=commonConstants.js.map