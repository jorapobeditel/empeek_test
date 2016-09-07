import {Injectable} from "angular2/core";
import {Http} from "angular2/http";
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {
    constructor(private _http: Http) { }
    getData(path: string) {
        return this._http.get('/api/directory/'+ path).map(res => res.json());
    }
}