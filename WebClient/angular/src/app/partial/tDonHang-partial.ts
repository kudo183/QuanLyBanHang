import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';

export class tDonHangPartial {

    static className = 'tDonHangComponent';

    static afterContentInitPartial(parameters) {
        const comp = parameters[0];
        const buttons = new Array<any>();
        buttons.push({
            content: 'print',
            click: () => {
                this.print(comp);
            }
        });
        buttons.push({
            content: 'print all',
            click: () => {
                this.printAll(comp);
            }
        });
        comp.grid.settings.bottomBarButtons = buttons;
    }


    static print(comp): void {
        if (comp.grid.selectedItem === undefined) {
            return;
        }

        let tenKhachHang = comp.maKhachHangSource.find(p => p.id === comp.grid.selectedItem.maKhachHang).tenKhachHang;

        const qe = new QueryExpression();
        qe.addWhereOption('=', 'maDonHang', comp.grid.selectedItem.id, WhereOptionTypes.Int);
        comp.refDataService.get('tMatHang').subscribe(matHangs => {
            comp.dataService.get('tchitietdonhang', qe).subscribe(ctdhs => {
                comp.dataService.getIntList('tchitietchuyenhangdonhang', 'maChiTietDonHang', ctdhs.items.map(p => p.id)).subscribe(ctchdhs => {
                    let printContents, tenMatHangIn, tongSoLuong, soLuongConLai;
                    printContents = this.toTitleDiv(tenKhachHang);

                    const tableContent = [];
                    ctdhs.items.forEach(p => {
                        tongSoLuong = 0;
                        ctchdhs.items.forEach(ctchdh => {
                            if (ctchdh.maChiTietDonHang === p.id) {
                                tongSoLuong = tongSoLuong + ctchdh.soLuong;
                            }
                        });
                        soLuongConLai = p.soLuong - tongSoLuong;
                        if (soLuongConLai > 0) {
                            tenMatHangIn = matHangs.items.find(mh => mh.id === p.maMatHang).tenMatHangIn;
                            tableContent.push([p.soLuong, tenMatHangIn]);
                        }
                    });
                    printContents = printContents + this.toHtmlTable(tableContent);
                    this.printContent(printContents);
                });
            });
        });
    }

    static printAll(comp): void {
        if (comp.grid.selectedItem === undefined) {
            return;
        }

        let tenKhachHang = comp.maKhachHangSource.find(p => p.id === comp.grid.selectedItem.maKhachHang).tenKhachHang;

        const qe = new QueryExpression();
        qe.addWhereOption('=', 'maDonHang', comp.grid.selectedItem.id, WhereOptionTypes.Int);
        comp.refDataService.get('tMatHang').subscribe(matHangs => {
            comp.dataService.get('tchitietdonhang', qe).subscribe(ctdhs => {
                let printContents, tenMatHangIn;
                printContents = this.toTitleDiv(tenKhachHang);

                const tableContent = [];
                ctdhs.items.forEach(p => {
                    tenMatHangIn = matHangs.items.find(mh => mh.id === p.maMatHang).tenMatHangIn;
                    tableContent.push([p.soLuong, tenMatHangIn]);
                });
                printContents = printContents + this.toHtmlTable(tableContent);
                this.printContent(printContents);
            });
        });
    }

    static toTitleDiv(title: string): string {
        return `<div class="title">${title}</div>`;
    }

    static htmlTableRowSpacer(colCount: number): string {
        return '<tr class="spacer">' + '<td></td>'.repeat(colCount) + '</tr>';
    }

    static toHtmlTable(tableContent: Array<Array<string>>): string {
        let result = '';
        if (tableContent === undefined || tableContent.length === 0) {
            return result;
        }
        result = result + '<table>';
        let spacer = this.htmlTableRowSpacer(tableContent[0].length);
        tableContent.forEach(row => {
            result = result + '<tr>';
            row.forEach((cell, index) => {
                result = result + `<td class="col${index + 1}">${cell}</td>`;
            });
            result = result + '</tr>';
            result = result + spacer;
        });
        result = result + '</table>';
        return result;
    }

    static printContent(content: string): void {
        const style = `
      body {
          margin: 0px;
          width: 48mm;
          font-family: 'Arial'
      }
      
      .title {
          text-align: center;
          font-weight: bold;
          height: 10mm
      }
      
      .spacer {
          height: 2mm;
      }
      
      td {
          vertical-align: top;
      }
      
      .col1 {
          width: 10mm;
      }
      
      .col2 {
          width: 38mm;
      }
    `;
        const printHtml = `<html><head><style>${style}</style></head><body onload="window.print();window.close()">${content}</body></html>`;

        console.log(printHtml);
        let popupWin = window.open('', '_blank', 'top=0,left=0,width=auto');
        popupWin.document.open();
        popupWin.document.write(printHtml);
        popupWin.document.close();
    }

}