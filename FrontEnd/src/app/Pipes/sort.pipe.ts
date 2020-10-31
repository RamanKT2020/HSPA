import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sort'
})
export class SortPipe implements PipeTransform {

  // Using args instead of passing arguments explicitly
  transform(value: Array<string>, args: any[]): any {

    const sortFieldName  = args[0];
    const sortDirectionString  = args[1];
    let sortDirection = 1;

    if (sortDirectionString === 'desc') {
      sortDirection = -1;
    }

    if (value) {
      value.sort((a: any, b: any) => {
        if (a[sortFieldName] < b[sortFieldName]) {
          return -1 * sortDirection;
        } else if (a[sortFieldName] > b[sortFieldName]) {
          return 1 * sortDirection;
        } else {
          return 0;
        }
      });
    }

    return value;
  }

}
