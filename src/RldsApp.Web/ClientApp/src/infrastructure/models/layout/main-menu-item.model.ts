
export class MainMenuItem {
  name: string;
  url: string;
  classes: string;
  id: string;
  icon: string;
  active: boolean;
  onClick: () => void;
  displayCondition: () => boolean;

  subItems: Array<MainMenuItem>;

  constructor(opts: (obj: MainMenuItem) => void = (obj) => { }) {
    opts(this);
  }
}
