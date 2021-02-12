import { KeyValue } from "@angular/common";

export class KeyValuePair<TKey, TValue> implements KeyValue<TKey, TValue> {
    key: TKey;
    value: TValue;

    constructor(key: TKey = null, value: TValue = null) {
        this.key = key;
        this.value = value;
    }

}
