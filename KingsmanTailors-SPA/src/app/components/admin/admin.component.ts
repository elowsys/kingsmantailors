import { Component, OnInit } from '@angular/core';
import { HeaderService } from './../../services/header.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  adminLinks: any[];
  constructor(private _headerService: HeaderService, private _router: Router) {}

  ngOnInit() {
    this._headerService.initialize(
      'Administration',
      'admin-banner text-center',
      'fa fa-cogs',
      null,
      false,
      'Administration',
      null
    );

    this.getAdminLinks();
  }

  getAdminLinks() {
    this.adminLinks = [];
    this._router.config.forEach(parent => {
      // only ones with children
      if (parent.children) {
        // all children that do not have /:id
        parent.children.forEach(child => {
          if (child.path.indexOf(':') <= 0) {
            this.adminLinks.push(child);
          }
        });
      }
      // console.log('Links', this.adminLinks);
    });
  }
}
