import { Injectable } from '@angular/core';
import { ChiPhiPartial } from './partial/chi-phi-partial';
import { tDonHangPartial } from './partial/tDonHang-partial';
import { tChuyenHangDonHangPartial } from './partial/tChuyenHangDonHang-partial';
import { tChiTietChuyenHangDonHangPartial } from './partial/tChiTietChuyenHangDonHang-partial';
import { tChiTietDonHangPartial } from './partial/tChiTietDonHang-partial';
import { Observable } from 'rxjs/Observable';
// import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';

@Injectable()
export class PartialMethodService {
    afterContentInitPartial(className, parameters) {
        switch (className) {
            case tDonHangPartial.className:
                return tDonHangPartial.afterContentInitPartial(parameters);
            case tChiTietDonHangPartial.className:
                return tChiTietDonHangPartial.afterContentInitPartial(parameters);
        }
    }

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
        switch (className) {
            case tChiTietDonHangPartial.className:
                return tChiTietDonHangPartial.processItemListPartial(parameters);
            case tChuyenHangDonHangPartial.className:
                return tChuyenHangDonHangPartial.processItemListPartial(parameters);
            case tChiTietChuyenHangDonHangPartial.className:
                return tChiTietChuyenHangDonHangPartial.processItemListPartial(parameters);
        }
        return of('');
    }

    afterLoadPartial(className, parameters) {
        switch (className) {
            case ChiPhiPartial.className:
                ChiPhiPartial.afterLoad(parameters);
        }
    }
}