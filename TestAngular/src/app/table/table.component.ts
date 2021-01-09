import { Query } from './../config/query.model';
import { ConfigService } from './../config/config.service';
import { Component, ErrorHandler, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  myForm = new FormGroup({});
  message = new FormControl();
  query = new FormControl();
  errors: any = {};

  constructor(private fb: FormBuilder, public httpClient: HttpClient, private erroHandler : ErrorHandler, private configService: ConfigService) {

  }

  ngOnInit(): void {
    this.reactiveForm();
    this.erroHandler.handleError(this.errors);
  }

  reactiveForm() {
    this.myForm = this.fb.group({
      query: ['', [Validators.required]],
      message: ['', [Validators.required]]
    });
  }

  submitForm() {
    let request : Query = {
      query: this.myForm.controls.query.value,
      message: this.myForm.controls.message.value
    };
    let response : Response | undefined;

    this.configService.sendPostRequest(request).subscribe(
      response => response = response
    );


  }

}
