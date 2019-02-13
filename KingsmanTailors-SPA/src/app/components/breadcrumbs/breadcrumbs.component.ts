import { Component, OnInit } from '@angular/core';
import { Breadcrumbs } from 'src/app/models/breadcrumbs';

@Component({
  selector: 'app-breadcrumbs',
  templateUrl: './breadcrumbs.component.html',
  styleUrls: ['./breadcrumbs.component.css']
})
export class BreadcrumbsComponent implements OnInit {
  breadcrumbs: Breadcrumbs[];

  constructor() {
    this.breadcrumbs = [];
  }

  ngOnInit() {}
}
