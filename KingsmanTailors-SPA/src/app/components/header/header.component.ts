import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  title: string;
  bannerStyle: string;
  showButton: boolean;
  constructor() {}

  ngOnInit() {
    this.title = 'Welcome to Kingsman Tailors';
    this.bannerStyle = 'page-banner text-center';
    this.showButton = false;
  }

  getFontAwesomeIc() {
    return '';
  }

  getModelTitle() {
    return this.title;
  }

  getHeaderTitle() {
    return this.title;
  }

  getBannerStyle() {
    return this.bannerStyle;
  }

  getShowButton() {
    return this.showButton;
  }
}
