export class MyURLSearchParams {
    static create() {
        // return new URLSearchParams(); because safari < 10.1 not support
        return new MyURLSearchParams();
    }

    private _data = {};

    set(name, value) {
        this._data[name] = value;
    }

    toString() {
        let result = '';
        for (var key in this._data) {
            if (this._data.hasOwnProperty(key)) {
                result = result + key + '=' + encodeURIComponent(this._data[key]).replace('%20', '+') + '&';
            }
        }
        return result.substr(0, result.length - 1);
    }
}