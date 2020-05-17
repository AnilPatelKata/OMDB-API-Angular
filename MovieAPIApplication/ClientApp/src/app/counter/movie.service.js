"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("rxjs/add/operator/map");
var MovieService = /** @class */ (function () {
    function MovieService(http) {
        this.http = http;
    }
    MovieService.prototype.SearchMovie = function (searchKey, searchType) {
        var url = 'https://www.omdbapi.com/?{type}=';
        url = url.replace('{type}', searchType);
        return this.http.get(url + searchKey)
            .map(function (result) { return result.json(); });
    };
    return MovieService;
}());
exports.MovieService = MovieService;
//# sourceMappingURL=movie.service.js.map