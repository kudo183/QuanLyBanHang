
import { HSimpleGridSetting } from './shared';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from './data.service';

export class Converter {
    static FromHSimpleGridSettingToQueryExpression(setting: HSimpleGridSetting.GridSetting): QueryExpression {
        const qe = new QueryExpression;
        setting.columnSettings.forEach(columnSetting => {
            if (columnSetting.headerSetting.isEnableFilter === true) {
                const we = new WhereOption();
                we.predicate = columnSetting.headerSetting.filterOperator;
                we.propertyPath = columnSetting.cellValueProperty;
                we.value = columnSetting.headerSetting.filterValue;

                switch (columnSetting.cellValueType) {
                    case HSimpleGridSetting.DataTypeEnum.Int:
                        we.$type = WhereOptionTypes.Int;
                        break;
                    case HSimpleGridSetting.DataTypeEnum.Bool:
                        we.$type = WhereOptionTypes.Bool;
                        break;
                    case HSimpleGridSetting.DataTypeEnum.String:
                        we.$type = WhereOptionTypes.String;
                        break;
                    case HSimpleGridSetting.DataTypeEnum.Date:
                        we.$type = WhereOptionTypes.Date;
                        break;
                }

                qe.whereOptions.push(we);
            }
            if (columnSetting.headerSetting.order === HSimpleGridSetting.OrderTypeEnum.Asc) {
                const or = new OrderOption();
                or.isAscending = true;
                or.propertyPath = columnSetting.cellValueProperty;
                qe.orderOptions.push(or);
            } else if (columnSetting.headerSetting.order === HSimpleGridSetting.OrderTypeEnum.Dec) {
                const or = new OrderOption();
                or.isAscending = false;
                or.propertyPath = columnSetting.cellValueProperty;
                qe.orderOptions.push(or);
            }
        });

        qe.pageIndex = setting.pagingSetting.currentPageIndex;
        qe.pageSize = setting.pagingSetting.pageSize;
        return qe;
    }
}
