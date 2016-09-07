System.register(['angular2/core', './data.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, data_service_1;
    var AppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (data_service_1_1) {
                data_service_1 = data_service_1_1;
            }],
        execute: function() {
            AppComponent = (function () {
                function AppComponent(_dataservice) {
                    this._dataservice = _dataservice;
                    this.updateData('');
                }
                AppComponent.prototype.folderClick = function (folderName) {
                    this.updateData(this.dirPath + "/" + folderName);
                };
                AppComponent.prototype.parent = function () {
                    this.updateData(this.parentUrl);
                };
                AppComponent.prototype.updateData = function (path) {
                    var _this = this;
                    this._dataservice.getData(path).subscribe(function (data) {
                        _this.files = data.files,
                            _this.folders = data.folders,
                            _this.dirPath = data.path,
                            _this.parentUrl = data.parentUrl,
                            _this.fileSizes = data.filesInfo;
                    }, function (error) { return console.log(error); }, function () { return console.log("finished"); });
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Array)
                ], AppComponent.prototype, "files", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Array)
                ], AppComponent.prototype, "folders", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], AppComponent.prototype, "dirPath", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], AppComponent.prototype, "parentUrl", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Array)
                ], AppComponent.prototype, "fileSizes", void 0);
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'app',
                        templateUrl: '/app/template.html?v1.1',
                        providers: [data_service_1.DataService]
                    }), 
                    __metadata('design:paramtypes', [data_service_1.DataService])
                ], AppComponent);
                return AppComponent;
            }());
            exports_1("AppComponent", AppComponent);
        }
    }
});
