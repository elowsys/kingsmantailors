import { Component, OnInit } from '@angular/core';
import { HeaderService } from 'src/app/services/header.service';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit {
  constructor(private _headerService: HeaderService) {}

  ngOnInit() {
    this._headerService.initialize('Not found...', 'notfound-banner');
  }
}
