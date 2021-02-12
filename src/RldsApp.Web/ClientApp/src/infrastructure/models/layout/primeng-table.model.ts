import { Helper } from "../../helpers/helper";

export class PrimengTableColumn {
  header: string;
  style: string;
  isEditable: boolean;
  field: string;
  class: string;
  isDateField: boolean;
  isDateTimeField: boolean;
  hidden: boolean;
  options: Array<PrimengTableOption>;

  filterLabel: string;
  filterType: FieldType;
  fieldType: FieldType;
  compersionType: CompersionType;
  filterable: boolean;
  orderIndex: number;
  columnOrderDirection?: OrderDirection
  columnFilter: string | boolean | number;

  constructor(init: (opts: PrimengTableColumn) => void) {
    this.filterable = true;
    this.columnOrderDirection = null;
    this.fieldType = FieldType.String;
    this.compersionType = CompersionType.Contains;
    this.options = new Array<PrimengTableOption>();
    if (init)
      init(this);
  }

  get getFilterLabel() {
    return Helper.IsNullOrEmpty(this.filterLabel) ? this.header : this.filterLabel;
  }

  // Check for options column 
  isOptionsColumn() {
    return this.options && this.options.length > 0;
  }

  isDateColumn() {
    return this.isDateField;
  }

  isDateTimeColumn() {
    return this.isDateTimeField;
  }

  changeOrderDirection(columns: Array<PrimengTableColumn>) {
    if (this.columnOrderDirection == null)
      this.columnOrderDirection = OrderDirection.Asc;
    else if (this.columnOrderDirection == OrderDirection.Asc)
      this.columnOrderDirection = OrderDirection.Desc;
    else if (this.columnOrderDirection == OrderDirection.Desc)
      this.columnOrderDirection = null;

    if (this.columnOrderDirection == null) {
      columns.forEach(col => {
        if (col.orderIndex > this.orderIndex)
          col.orderIndex--;
      });

      this.orderIndex = null;

    } else if (this.columnOrderDirection != null && this.orderIndex == null) {
      let list = columns.map(a => a.orderIndex).filter(a => a >= 0);
      list.push(-1);
      this.orderIndex = Math.max(...list) + 1;
    }
  }

  get getOrderIcon() {
    if (this.columnOrderDirection == OrderDirection.Asc)
      return "fa-sort-up";
    if (this.columnOrderDirection == OrderDirection.Desc)
      return "fa-sort-down";
    return "fa-sort"
  }

  getFilterOperationSign() {

    if (this.fieldType == FieldType.Number) {

      if (this.compersionType == CompersionType.Equal)
        return `=`;
      else if (this.compersionType == CompersionType.LessThan)
        return `<`;
      else if (this.compersionType == CompersionType.GreaterThan)
        return `>`;

    } else if (this.fieldType == FieldType.String) {

      if (this.compersionType == CompersionType.Contains)
        return `contains`;
    } else if (this.fieldType == FieldType.Boolean) {

      if (this.compersionType == CompersionType.Contains)
        return `=`;
    }

    return '';
  }
}

export class PrimengTableOption {
  icon: string;
  address: string;
  tooltip: string;
  class: string;
  canBeHidden: boolean;
  displayCondition: (item: object) => void
  event: ($event: object, data: object) => void;

  constructor(init: (opts: PrimengTableOption) => void) {
    this.displayCondition = (item) => true;
    if (init)
      init(this);
  }
}

export enum OrderDirection {
  Asc, Desc
}

export enum FieldType {
  String, Number, Boolean
}

export enum CompersionType {
  /** Only for string! */
  Contains,
  /** Only for numbers! */
  LessThan,
  /** Only for numbers! */
  GreaterThan,
  /** Only for numbers! */
  Equal
}
