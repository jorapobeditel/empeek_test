import {Component, Input } from 'angular2/core';
import {DataService} from './data.service';
@Component({
    selector: 'app',
    templateUrl: '/app/template.html?v1.1',
    providers: [DataService]
})

export class AppComponent  {
    @Input() files: string[];
    @Input() folders: string[];
    @Input() dirPath: string;
    @Input() parentUrl: string;
    @Input() fileSizes: number[];
    constructor(private _dataservice: DataService) {
        this.updateData('');
    }
    folderClick(folderName) {
        this.updateData(this.dirPath+"/"+folderName);
    }
    parent() {
        this.updateData(this.parentUrl);
    }
    updateData(path) {
        this._dataservice.getData(path).subscribe(data => {
                this.files = data.files,
                this.folders = data.folders,
                this.dirPath = data.path,
                this.parentUrl = data.parentUrl,
                this.fileSizes = data.filesInfo
        },
            error => console.log(error),
            () => console.log("finished")
        ); }

}  