import { Component, OnInit } from '@angular/core';
import { ValuesService } from './../../services/values.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  values: any;
  constructor(private _service: ValuesService) {}

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    this._service.getAll().subscribe(
      response => {
        this.values = response;
        console.log(this.values);
      },
      err => {
        console.log(err);
      }
    );
  }
}
