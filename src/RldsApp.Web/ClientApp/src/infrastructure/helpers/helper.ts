import { AuthenticatedData, User } from "../services-api/rlds-api";

export class Helper {
  static SetUserData(authData: AuthenticatedData, user: User) {
    Helper.SetSessionValueOfType<number>('userId', authData.userId);
    Helper.SetSessionValue('token', authData.token);
    Helper.SetSessionValue('userFirstName', user.firstname);
    Helper.SetSessionValue('userLastName', user.lastname);
    Helper.SetSessionValueOfType<Array<string>>('roles', user.roles.map(role => role.roleName));
  }
  static RemoveUserData() {
    Helper.RemoveSession('userId');
    Helper.RemoveSession('token');
    Helper.RemoveSession('roles');
    Helper.RemoveSession('userFirstName');
    Helper.RemoveSession('userLastName');
  }

  static GetCurrentUser() {
    return {
      id: Helper.GetSessionValueOfType<number>('userId'),
      token: Helper.GetSessionValue('token'),
      userFirstName: Helper.GetSessionValue('userFirstName'),
      userLastName: Helper.GetSessionValue('userLastName'),
      roles: Helper.GetSessionValueOfType<Array<string>>('roles'),
    };
  }
  static IsUserLogedIn() {
    return !Helper.IsNullOrEmpty(Helper.GetSessionValue('token'))
  }

  // STRING
  static IsNullOrEmpty(text: string): boolean {
    return text == null || text == "";
  }

  static Includes(searchString: string, text: string): boolean {

    return searchString != null && text != null && searchString.toLowerCase().includes(text.toLowerCase());
  }

  static ToString<Type>(json: Type): string {
    return JSON.stringify(json);
  }

  static ToJson<Type>(json: string): Type {
    return JSON.parse(json) as Type
  }

  // SESSION
  static GetSessionValue(sessionKey: string): string {
    sessionStorage.getItem(sessionKey);
    return localStorage.getItem(sessionKey);
  }

  static GetSessionValueOfType<Type>(sessionKey: string): Type {
    return Helper.ToJson<Type>(Helper.GetSessionValue(sessionKey));
  }

  static SetSessionValue(sessionKey: string, sessionValue: string): void {
    sessionStorage.setItem(sessionKey, sessionValue);
    localStorage.setItem(sessionKey, sessionValue);
  }

  static SetSessionValueOfType<Type>(sessionKey: string, sessionValue: Type): void {
    Helper.SetSessionValue(sessionKey, Helper.ToString<Type>(sessionValue));
  }

  static RemoveSession(sessionKey: string) {
    sessionStorage.removeItem(sessionKey);
    localStorage.removeItem(sessionKey);
  }

  static ClearSession() {
    sessionStorage.clear();
    localStorage.clear();
  }

  // ARRAY
  static Contains<Type>(array: Array<Type>, element: Type): boolean {
    if (!Helper.isNullOrEmpty(array))
      return (array as any).includes(element);
    return false;
  }

  /**
   * Checks if sourceArray contains all elements from targetArray
   * @param sourceArray Array with values to compare
   * @param targetArray Array with required values 
   */
  static HasAll<Type>(sourceArray: Array<Type>, targetArray: Array<Type>): boolean {
    return targetArray.every(sa => sourceArray.some(ta => ta == sa));
  }
  /**
   * Checks if sourceArray contains any element from targetArray
   * @param sourceArray Array with values to compare
   * @param targetArray Array with required values 
   */
  static HasAny<Type>(sourceArray: Array<Type>, targetArray: Array<Type>): boolean {
    return targetArray.some(sa => sourceArray.some(ta => ta == sa));
  }

  static IndexOf<Type>(array: Array<Type>, element: Type): number {
    if (!Helper.isNullOrEmpty(array))
      return array.indexOf(element);
    return -1;
  }

  static RemoveElement<Type>(array: Array<Type>, element: Type): Array<Type> {
    array.splice(Helper.IndexOf(array, element), 1);
    return array;
  }

  static RemoveElementByIndex<Type>(array: Array<Type>, index: number): Array<Type> {
    array.splice(index, 1);
    return array;
  }

  static isNullOrEmpty<Type>(array: Array<Type>): boolean {
    return array == null || array.length == 0
  }

  static toArray<Type>(list: Type[]): Array<Type> {
    if (list) {
      return <Array<Type>>list as Array<Type>;
    } else {
      return new Array<Type>();
    }
  }

  static StringJoin(array: string[], separator: string = "<br>", elementTransform: (item: string) => string = (item) => { return item; }): string {
    let text = "";
    let addSeparator = false;

    for (let value of array) {

      if (addSeparator)
        text += `${separator} `;

      text += elementTransform(value);
      addSeparator = true;
    }

    return text;
  }

  // DATE
  static IsValidDate(date: Date): boolean {
    return date != null && !isNaN(date.getTime()) && date instanceof Date;
  }

  static IsDateBetween(dateStart: Date, dateEnd: Date, date: Date): boolean {
    return date > dateStart && date < dateEnd;
  }

  static AddDays(date: Date, days: number) {
    var date = new Date(date.valueOf());
    date.setDate(date.getDate() + days);
    return date;
  }

  // NUMBER


  static GetRandomInt(min: number, max: number) {
    return Math.floor(Math.random() * (max - min)) + min;
  }

  // DEBUG
  static Log(message?: any, ...optionalParams: any[]): void {
    console.log(message, optionalParams);
  }

  static Error(message?: any, ...optionalParams: any[]): void {
    console.error(message, optionalParams);
  }

  static Info(message?: any, ...optionalParams: any[]): void {
    console.info(message, optionalParams);
  }

  static Warm(message?: any, ...optionalParams: any[]): void {
    console.warn(message, optionalParams);
  }

  // OBJECT
  static CopyObject<Type>(object: Type): Type {
    return (Object as any).assign({}, object);
  }

  static CopyArray<Type>(object: Array<Type>): Type {
    return (Object as any).assign(new Array<Type>(), object);
  }

  static CopyTable<Type>(object: Type[]): Type {
    return (Object as any).assign([], object);
  }

  static Serialize<Type>(object: Type): string {
    return JSON.stringify(object);
  }

  static Deserialize<Type>(objectJson: string): Type {
    return JSON.parse(JSON.stringify(objectJson)) as Type;
  }

  static IsNullOrUndefined(object: any): boolean {
    return object == null || object == undefined;
  }

  static EnumToList<Type>(enumType): Array<Type> {
    var result = new Array<Type>();

    for (var n in enumType) {
      if (typeof enumType[n] !== 'number') {
        result.push(enumType[n] as Type);
      }
    }

    return result;
  }

  // GUID
  static newGuid(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, c => {
      const r = Math.random() * 16 | 0;
      const v = (c == 'x') ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }

  // URL
  static openUrlInNewTab(url: string): void {
    window.open(url, "_blank");
  }

  // HTML HELPERS
  static afterDomElementInit(id: string, elementAction: (element: HTMLElement) => void, intervalTimeout: number = 50) {
    let interval = setInterval(() => {
      let domElement = document.getElementById(id);
      if (domElement) {
        elementAction(domElement);
        clearInterval(interval);
      }
    }, intervalTimeout);
  }

  static getFloatValueFromString(value: any): number {
    if (!value || value == null || value.length == 0) {
      return 0;
    } else {
      return parseFloat(value.toString().trim().replace(",", ".").replaceAll(" ", ""));
    }
  };

  static replaceDotWithComma(value: any): string {
    if (value == null)
      value = "";
    return value.toString().replace(".", ",");
  }

  static replaceCommaWithDot(value: any): string {
    if (value == null)
      value = "";
    return value.toString().replaceAll(" ", "").replace(",", ".");
  }

  static isPressedKeyNumpadDecimalSeparator(evt) {
    if (evt.key !== undefined && evt.key === "Decimal") { // IE / Edge
      return true;
    }
    if (evt.code !== undefined && evt.code == "NumpadDecimal") { // Chrome / FF / Opera
      return true;
    }

    return evt.keyCode === 110; // Compatibiliy with old browser
  }

}
