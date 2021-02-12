
export class MainMenuItem {
  name: string;
  url: string;
  classes: string;
  id: string;
  icon: string;
  active: boolean;

  subItems: Array<MainMenuItem>;

  constructor(opts: (obj: MainMenuItem) => void = (obj) => { }) {
    opts(this);
  }
}
