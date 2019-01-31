import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {
  private _bannerStyle: string;
  private _buttonClick: any;
  private _buttonText: string;
  private _fontAwesomeIcon: string;
  private _headerTitle: string;
  private _modelTitle: string;
  private _showButton: boolean;

  constructor() {}

  getBannerStyle() {
    return 'py-2 mb-3 bg-secondary text-white text-center ' + this._bannerStyle;
  }

  getButtonClick() {
    return this._buttonClick;
  }

  getButtonText() {
    return this._buttonText;
  }

  getFontAwesomeIcon() {
    return this._fontAwesomeIcon;
  }

  getHeaderTitle() {
    return this._headerTitle;
  }

  getModelTitle() {
    return this._modelTitle;
  }

  getShowButton() {
    return this._showButton;
  }

  set BannerStyle(style) {
    this._bannerStyle = style;
  }

  initialize(
    modelTitle = 'Welcome to Kingsman Tailors',
    bannerStyle = 'page-banner',
    fontAwesomeIcon?: string,
    buttonText?: string,
    showButton?: boolean,
    headerTitle?: string,
    buttonClick?: any
  ) {
    this._modelTitle = modelTitle;
    this._bannerStyle = bannerStyle;
    this._buttonText = buttonText;
    this._showButton = showButton;
    this._headerTitle = headerTitle;
    this._fontAwesomeIcon = fontAwesomeIcon;
  }
}
