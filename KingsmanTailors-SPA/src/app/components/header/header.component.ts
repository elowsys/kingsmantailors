import { Component, OnInit, Input } from '@angular/core';
import { HeaderService } from './../../services/header.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  constructor(private _service: HeaderService) {}

  ngOnInit() {
    this._service.initialize();
  }

  bannerStyle() {
    return this._service.getBannerStyle();
  }

  buttonText() {
    return this._service.getButtonText();
  }

  fontAwesomeIcon() {
    return this._service.getFontAwesomeIcon();
  }

  headerTitle() {
    return this._service.getHeaderTitle();
  }

  modelTitle() {
    return this._service.getModelTitle();
  }

  showButton() {
    return this._service.getShowButton();
  }

  buttonClick() {
    this._service.getButtonClick();
  }
}
