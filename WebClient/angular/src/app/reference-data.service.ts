import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { DataService } from './data.service';

@Injectable()
export class ReferenceDataService {
  private cache = {};

  constructor(private dataService: DataService) {
    const keyProperty = 'id';

    this.cache['rloaihang'] = this.createCacheObject(keyProperty, 'tenLoai', true);
    this.cache['tmathang'] = this.createCacheObject(keyProperty, 'tenMatHang', true);
    this.cache['rkhohang'] = this.createCacheObject(keyProperty, 'tenKho', true);
    this.cache['rkhachhang'] = this.createCacheObject(keyProperty, 'tenKhachHang', true);
    this.cache['rnhanvien'] = this.createCacheObject(keyProperty, 'tenNhanVien', true);
    this.cache['rloaichiphi'] = this.createCacheObject(keyProperty, 'tenLoaiChiPhi', true);
    this.cache['rkhachhangchanh'] = this.createCacheObject(keyProperty, undefined, true);
    this.cache['rchanh'] = this.createCacheObject(keyProperty, 'tenChanh', true);
    this.cache['rcanhbaotonkho'] = this.createCacheObject(keyProperty, undefined, true);    
  }

  private createCacheObject(keyProperty, sortProperty, isAscending) {
    return {
      data: [],
      isLoaded: false,
      keyProperty: keyProperty,
      sortProperty: sortProperty,
      isAscending: isAscending,
      isLoading: false,
      loadSubject: new Subject()
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
