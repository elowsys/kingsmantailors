import { Params } from '@angular/router';

export interface Breadcrumbs {
  label: string;
  params: Params;
  url: string;
}
