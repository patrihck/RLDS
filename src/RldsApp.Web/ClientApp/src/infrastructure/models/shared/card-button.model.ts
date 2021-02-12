export class CardButton {
  style: string;
  class: string;
  iconClass: string;
  name: string;
  onClick: () => void;

  constructor(init: (opts: CardButton) => void) {
    if (init)
      init(this);
  }
}
