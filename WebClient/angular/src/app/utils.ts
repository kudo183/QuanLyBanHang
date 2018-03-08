export class Utils {
    static toObservableObj(obj, callback) {
        let result: any = {};

        for (var prop in obj) {
            const p = prop;
            const _p = '_' + p;

            Object.defineProperty(result, _p, {
                value: obj[p],
                writable: true
            });

            Object.defineProperty(result, p, {
                enumerable: true,
                get() { return result[_p]; },
                set(newValue) {
                    if (result[_p] === newValue) {
                        return;
                    }
                    result[_p] = newValue;
                    result.callback(result, p);
                },
            });
        }

        Object.defineProperty(result, 'callback', {
            value: callback,
            writable: true
        });

        return result;
    }

    static addCallback(obj, callback) {
        for (var prop in obj) {
            const p = prop;
            const _p = '_' + p;

            Object.defineProperty(obj, _p, {
                value: obj[p],
                writable: true
            });

            Object.defineProperty(obj, p, {
                get() { return obj[_p]; },
                set(newValue) {
                    if (obj[_p] === newValue) {
                        return;
                    }
                    obj[_p] = newValue;
                    obj.callback(obj, p);
                },
            });
        }

        Object.defineProperty(obj, 'callback', {
            value: callback,
            writable: true
        });
    }
}