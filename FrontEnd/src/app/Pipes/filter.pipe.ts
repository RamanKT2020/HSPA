import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  //Studymash recommends 'unknown' instead of 'any' as Angular started using 'unknown' instead of 'any'
  // The code here still uses 'any'
  // 'unknown' typ is more retsrictive and needs to be checked before operating on it
  // In contrast, you can operate on 'any' type without any checks

  //value: whatever need sto be filtered
  //filterString: teh value of the filter string
  //propName: name of the property that needs to be filtered upon
  transform(value: any[], filterString: string, propName: string): any[] {
    const resultArray = [];

    if (value) {
      if (value.length === 0 || filterString === '' || propName  === '') {
        return value;
      }



      for (const item of value) {
        if (item[propName] === filterString) {
          resultArray.push(item);
        }
      }

      return resultArray;
    }
  }

}
