export class tChiPhiPartial {

    static className = 'tChiPhiComponent';

    static afterLoadPartial(parameters) {
        const comp = parameters[0];
        let sum = 0;
        comp.entities.forEach(item => {
            sum = sum + item['soTien'];
        });
        comp.grid.settings.msg = 'tong so tien: ' + sum.toLocaleString();
    }
}