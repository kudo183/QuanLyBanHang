import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable()
export class DataService {

  private RootUri: string;

  constructor(private http: HttpClient, private authService: AuthService) {
    this.RootUri = authService.RootUri;
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  get(controller: string, filter: QueryExpression) {
    return this.http.post<PagingResult>(this.getFullUri(controller, 'get'), filter, {
      headers: this.tokenHeader()
    }).pipe(
      tap(result => this.log(result)),
      catchError(this.handleError<PagingResult>('get', new PagingResult())));
  }

  getAll(controller: string): Observable<PagingResult> {
    return this.http.get<PagingResult>(this.getFullUri(controller, 'getall'), {
      headers: this.tokenHeader()
    }).pipe(
      tap(result => this.log(result)),
      catchError(this.handleError<PagingResult>('getAll', new PagingResult())));
  }

  save(controller: string, addedItems: Array<any>, deletedItems: Array<any>, changedItems: Array<any>) {
    const changes = new Array<any>();
    addedItems.forEach(p => { p.state = 1; changes.push(p); });
    deletedItems.forEach(p => { p.state = 2; changes.push(p); });
    changedItems.forEach(p => { p.state = 3; changes.push(p); });
    return this.http.post<PagingResult>(this.getFullUri(controller, 'save'), changes, {
      headers: this.tokenHeader()
    }).pipe(
      tap(result => this.log(result)),
      catchError(this.handleError<PagingResult>('save', new PagingResult())));
  }

  private tokenHeader(): HttpHeaders {
    return new HttpHeaders().set('token', this.authService.getToken());
  }

  private getFullUri(controller: string, action: string) {
    return this.RootUri + controller + '/' + action;
  }

  private log(message: any) {
    console.log('DataService: ');
    console.log(message);
  }
}

export class PagingResult {
  totalItemCount: number;
  pageIndex: number;
  pageCount: number;
  lastUpdateTime: number;
  items: Array<any>;
}

export class WhereOptionTypes {
  static Int = 'huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder';
  static Date = 'huypq.QueryBuilder.WhereExpression+WhereOptionDate, huypq.QueryBuilder';
  static String = 'huypq.QueryBuilder.WhereExpression+WhereOptionString, huypq.QueryBuilder';
  static Bool = 'huypq.QueryBuilder.WhereExpression+WhereOptionBool, huypq.QueryBuilder';
}

export class WhereOption {
  $type: string;
  predicate: string;
  propertyPath: string;
  value: any;

  toJSON() {
    return { $type: this.$type, predicate: this.predicate, propertyPath: this.propertyPath, value: this.value };
  }
}

export class OrderOption {
  propertyPath: string;
  isAscending: boolean;
}

export class QueryExpression {
  whereOptions = new Array<WhereOption>();
  orderOptions = new Array<OrderOption>();
  pageIndex = 1;
  pageSize = 30;
}
