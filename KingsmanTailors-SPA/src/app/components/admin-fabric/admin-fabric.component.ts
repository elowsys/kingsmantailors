import { Component, OnInit } from '@angular/core';
import { HeaderService } from 'src/app/services/header.service';

@Component({
  selector: 'app-admin-fabric',
  templateUrl: './admin-fabric.component.html',
  styleUrls: ['./admin-fabric.component.css']
})
export class AdminFabricComponent implements OnInit {
  constructor(private _headerService: HeaderService) {}

  ngOnInit() {
    this._headerService.initialize(
      'Fabrics',
      'admin-banner',
      'fab fa-shirtsinbulk fa-1x'
    );
  }
}
