import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

export class tDonHangPartial {

    static className = 'tDonHangComponent';

    static getDisplayText(parameters): Observable<string> {
        const comp = parameters[0];
        const itemID = parameters[1];

        let displayText = itemID + '|partial';

        return of(displayText);
    }
}