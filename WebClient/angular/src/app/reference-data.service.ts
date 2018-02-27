import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { map, tap } from 'rxjs/operators';
import { DataService } from './data.service';

@Injectable()
export class ReferenceDataService {
  private cache = {};

  keyProperty = 'id';
  sortProperty = 'displayText';

  constructor(private dataService: DataService) {
    this.cache['rloaihang'] = this.createCacheObject(true, item => { return item.tenLoai; });
    this.cache['tmathang'] = this.createCacheObject(true, item => { return item.tenMatHang; });
    this.cache['rkhohang'] = this.createCacheObject(true, item => { return item.tenKho; });
    this.cache['rkhachhang'] = this.createCacheObject(true, item => { return item.tenKhachHang; });
    this.cache['rnhanvien'] = this.createCacheObject(true, item => { return item.tenNhanVien; });
    this.cache['rloaichiphi'] = this.createCacheObject(true, item => { return item.tenLoaiChiPhi; });
    this.cache['rkhachhangchanh'] = this.createCacheObject(true, undefined);
    this.cache['rchanh'] = this.createCacheObject(true, item => { return item.tenChanh; });
    this.cache['rcanhbaotonkho'] = this.createCacheObject(true, undefined);
    this.cache['rphuongtien'] = this.createCacheObject(true, item => { return item.tenPhuongTien; });
    this.cache['rnhacungcap'] = this.createCacheObject(true, item => { return item.tenNhaCungCap; });
    this.cache['rnguyenlieu'] = this.createCacheObject(true, undefined);
    this.cache['rbaixe'] = this.createCacheObject(true, item => { return item.diaDiemBaiXe; });
    this.cache['rdiadiem'] = this.createCacheObject(true, item => { return item.tenNuoc; });
    this.cache['rloainguyenlieu'] = this.createCacheObject(true, item => { return item.tenLoai; });
  }

  private createCacheObject(isAscending, displayTextFunc) {
    return {
      data: [],
      isLoaded: false,
      keyProperty: this.keyProperty,
      sortProperty: this.sortProperty,
      isAscending: isAscending,
      isLoading: false,
      loadSubject: new Subject(),
      displayTextFunc: displayTextFunc || (item => { return item[this.keyProperty] + ''; })
    }
  }

  get(controller: string) {
    controller = controller.toLowerCase();
    const cache = this.cache[controller];
    if (cache.isLoaded === false) {
      if (cache.isLoading === false) {
        cache.isLoading = true;
        return this.dataService.getAll(controller).pipe(
          tap(data => {
            cache.isLoaded = true;
            data.items.forEach(item => {
              item.displayText = cache.displayTextFunc(item);
            });
            cache.data = data;
            if (cache.sortProperty !== undefined) {
              this.sort(cache.data.items, cache.sortProperty, cache.isAscending);
            }
            cache.isLoading = false;
            cache.loadSubject.next(cache.data);
          }));
      } else {
        return cache.loadSubject;
      }
    }
    return of(cache.data);
  }

  gets(controllers: Array<string>): Observable<any> {
    return Observable.forkJoin(controllers.map(p => this.get(p)));
  }

  getOrUpdate(controller: string) {

  }

  sort(arr, sortProperty, isAscending) {
    arr.sort(function (a, b) {
      const nameA = a[sortProperty].toUpperCase(); // ignore upper and lowercase
      const nameB = b[sortProperty].toUpperCase(); // ignore upper and lowercase
      if (isAscending === true) {
        return nameA.localeCompare(nameB);
      } else {
        return nameB.localeCompare(nameA);
      }
    });
  }
}
