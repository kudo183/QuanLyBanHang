import { Injectable } from '@angular/core';
import { ChiPhiPartial } from './partial/chi-phi-partial';
import { tDonHangPartial } from './partial/tDonHang-partial';
import { Observable } from 'rxjs/Observable';
// import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';

@Injectable()
export class PartialMethodService {

    loadReferenceDataPartial(className, parameters): Observable<any> {
        switch (className) {
            default:
                return of('');
        }
    }

    processItemPartial(className, parameters) {
        switch (className) {
        }
    }

    processItemListPartial(className, parameters): Observable<any> {
        return of('');
    }

    afterLoadPartial(className, parameters) {
        switch (className) {
            case ChiPhiPartial.className:
                ChiPhiPartial.afterLoad(parameters);
        }
    }

    getDisplayText(className, parameters): Observable<string> {
        console.debug('PartialMethodService getDisplayText');
        switch (className) {
            case tDonHangPartial.className:
                return tDonHangPartial.getDisplayText(parameters);
            default:
                return of(parameters[1]);
        }
    }
}