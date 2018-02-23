import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/forkJoin';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption, PagingResult } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-ton-kho',
  templateUrl: './ton-kho.component.html',
  styleUrls: ['./ton-kho.component.css']
})
export class TonKhoComponent implements OnInit {

  simpleGridSetting = new HSimpleGridSetting.GridSetting();

  entities: Array<any>;

  private _ngay = '2018-01-09';
  get ngay() {
    return this._ngay;
  }
  set ngay(value) {
    this._ngay = value;
    this.load();
  }

  khoHangs = [];

  private _maKhoHang;
  get maKhoHang() {
    return this._maKhoHang;
  }
  set maKhoHang(value) {
    this._maKhoHang = value;
    this.load();
  }

  loaiHangs = [];

  private _maLoaiHang;
  get maLoaiHang() {
    return this._maLoaiHang;
  }
  set maLoaiHang(value) {
    this._maLoaiHang = value;
    this.load();
  }

  canhBaoTonKhos = {};
  matHangs = {};

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) {
    this.initGridSetting();
  }

  ngOnInit() {
    this.refDataService.gets(['rloaihang', 'rkhohang', 'tmathang', 'rcanhbaotonkho'])
      .subscribe((data) => {
        const itemsLoaiHang = <PagingResult>data[0];
        const itemsKhoHang = <PagingResult>data[1];
        const itemsMatHang = <PagingResult>data[2];
        const itemsCBTK = <PagingResult>data[3];

        this.loaiHangs = itemsLoaiHang.items;
        this._maLoaiHang = this._maLoaiHang || 1;

        this.khoHangs = itemsKhoHang.items;
        this._maKhoHang = this._maKhoHang || 1;

        let temp = {};
        itemsMatHang.items.forEach(p => {
          temp[p.id] = p.tenMatHangDayDu;
        });
        this.matHangs = temp;

        temp = {};
        itemsCBTK.items.forEach(p => {
          temp[p.maKhoHang] = temp[p.maKhoHang] || {};
          temp[p.maKhoHang][p.maMatHang] = {
            tonCaoNhat: p.tonCaoNhat,
            tonThapNhat: p.tonThapNhat
          };
        });
        this.canhBaoTonKhos = temp;

        this.load();
      });
  }

  initGridSetting() {
    const DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
    const EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
    const FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

    this.simpleGridSetting.hasHeader = false;
    this.simpleGridSetting.hasDeleteButtonColumn = false;
    this.simpleGridSetting.isReadOnly = true;
    this.simpleGridSetting.pagingSetting.pageSize = 50;

    let cs = new HSimpleGridSetting.ColumnSetting();
    cs.cellValueProperty = 'tenMatHang';
    cs.cellValueType = DataTypeEnum.String;
    cs.type = EditorTypeEnum.Span;
    cs.width = 300;
    this.simpleGridSetting.columnSettings.push(cs);

    cs = new HSimpleGridSetting.ColumnSetting();
    cs.cellValueProperty = 'soLuong';
    cs.cellValueType = DataTypeEnum.Int;
    cs.type = EditorTypeEnum.Span;
    cs.width = 100;
    this.simpleGridSetting.columnSettings.push(cs);
  }

  load() {
    const qe = new QueryExpression();
    qe.pageIndex = this.simpleGridSetting.pagingSetting.currentPageIndex;
    qe.pageSize = this.simpleGridSetting.pagingSetting.pageSize;

    let we = new WhereOption();

    we.$type = WhereOptionTypes.Date;
    we.predicate = '=';
    we.propertyPath = 'Ngay';
    we.value = this.ngay;
    qe.whereOptions.push(we);

    we = new WhereOption();
    we.$type = WhereOptionTypes.Int;
    we.predicate = '=';
    we.propertyPath = 'MaKhoHang';
    we.value = this.maKhoHang;
    qe.whereOptions.push(we);

    we = new WhereOption();
    we.$type = WhereOptionTypes.Int;
    we.predicate = '=';
    we.propertyPath = 'MaMatHangNavigation.MaLoai';
    we.value = this.maLoaiHang;
    qe.whereOptions.push(we);

    const or = new OrderOption();
    or.isAscending = true;
    or.propertyPath = 'MaMatHangNavigation.TenMatHangDayDu';
    qe.orderOptions.push(or);

    this.dataService.get('ttonkho', qe).subscribe(data => {
      const gridItems = [];
      data.items.forEach(p => {
        let skip = false;
        let rowClass = '';
        const t1 = this.canhBaoTonKhos[p.maKhoHang];
        if (t1) {
          const t2 = t1[p.maMatHang];
          if (t2) {
            if (t2.tonCaoNhat === t2.tonThapNhat) {
              skip = true;
            } else if (p.soLuong < t2.tonThapNhat) {
              rowClass = 'warningLow';
            } else if (p.soLuong > t2.tonCaoNhat) {
              rowClass = 'warningHigh';
            }
          }
        }
        if (skip === false) {
          gridItems.push({
            tenMatHang: this.matHangs[p.maMatHang],
            soLuong: p.soLuong,
            rowClass: rowClass,
            cellClasses: {
              soLuong: rowClass
            }
          });
        }
      });

      this.entities = gridItems;
      this.simpleGridSetting.pagingSetting.pageCount = data.pageCount;
      this.simpleGridSetting.pagingSetting.rowCount = data.items.length;
    });
  }

  onLoad(event) {
    this.load();
  }
}
