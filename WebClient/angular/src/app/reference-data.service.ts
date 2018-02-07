import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { DataService } from './data.service';

@Injectable()
export class ReferenceDataService {
  private cache = {};
  constructor(private dataService: DataService) {
    const keyProperty = 'id';
    this.cache['rloaihang'] = {
      data: [],
      isLoaded: false,
      keyProperty: keyProperty,
      sortProperty: 'tenLoai',
      isAscending: true
    };

    this.cache['tmathang'] = {
      data: [],
      isLoaded: false,
      keyProperty: keyProperty,
      sortProperty: 'tenMatHang',
      isAscending: true
    };

    this.cache['rkhohang'] = {
      data: [],
      isLoaded: false,
      keyProperty: keyProperty,
      sortProperty: 'tenKho',
      isAscending: true
    };

    this.cache['rkhachhang'] = {
      data: [],
      isLoaded: false,
      keyProperty: keyProperty,
      sortProperty: 'tenKhachHang',
      isAscending: true
    };

    this.cache['rnhanvien'] = {
      data: [],
      isLoaded: false,
      keyProperty: keyProperty,
      sortProperty: 'tenNhanVien',
      isAscending: true
    };
  }

  get(controller: string) {
    const cache = this.cache[controller];
    if (cache.isLoaded === false) {
      return this.dataService.getAll(controller).pipe(
        tap(data => {
          cache.isLoaded = true;
          cache.data = data;
          if (cache.sortProperty !== undefined) {
            this.sort(cache.data.items, cache.sortProperty, cache.isAscending);
          }
        }));
    }
    return of(cache.data);
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
