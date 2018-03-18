import { Injectable } from '@angular/core';
import { tChiPhiPartial } from './partial/tChiPhi-partial';
import { tDonHangPartial } from './partial/tDonHang-partial';
import { tChuyenHangDonHangPartial } from './partial/tChuyenHangDonHang-partial';
import { tChiTietChuyenHangDonHangPartial } from './partial/tChiTietChuyenHangDonHang-partial';
import { tChiTietDonHangPartial } from './partial/tChiTietDonHang-partial';
import { tChiTietNhapHangPartial } from './partial/tChiTietNhapHang-partial';
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
            case tChiTietNhapHangPartial.className:
                return tChiTietNhapHangPartial.afterContentInitPartial(parameters);
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
            case tChiTietDonHangPartial.className:
                tChiTietDonHangPartial.processItemPartial(parameters);
                break;
            case tChiTietNhapHangPartial.className:
                tChiTietNhapHangPartial.processItemPartial(parameters);
                break;
            case tChuyenHangDonHangPartial.className:
                tChuyenHangDonHangPartial.processItemPartial(parameters);
                break;
            case tChiTietChuyenHangDonHangPartial.className:
                tChiTietChuyenHangDonHangPartial.processItemPartial(parameters);
                break;
        }
    }

    processItemListPartial(className, parameters): Observable<any> {
        switch (className) {
            case tChiTietDonHangPartial.className:
                return tChiTietDonHangPartial.processItemListPartial(parameters);
            case tChiTietNhapHangPartial.className:
                return tChiTietNhapHangPartial.processItemListPartial(parameters);
            case tChuyenHangDonHangPartial.className:
                return tChuyenHangDonHangPartial.processItemListPartial(parameters);
            case tChiTietChuyenHangDonHangPartial.className:
                return tChiTietChuyenHangDonHangPartial.processItemListPartial(parameters);
        }
        return of('');
    }

    afterLoadPartial(className, parameters) {
        switch (className) {
            case tChiPhiPartial.className:
                tChiPhiPartial.afterLoadPartial(parameters);
            case tChiTietChuyenHangDonHangPartial.className:
                tChiTietChuyenHangDonHangPartial.afterLoadPartial(parameters);
        }
    }
}