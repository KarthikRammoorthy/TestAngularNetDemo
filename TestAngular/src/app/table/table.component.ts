import { Query } from './../config/query.model';
import { ConfigService } from './../config/config.service';
import { Component, ErrorHandler, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { state } from '@angular/animations';
import { Palindromes } from './../config/palindromes.model';

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

  constructor(private fb: FormBuilder, public httpClient: HttpClient, private erroHandler : ErrorHandler, private configService: ConfigService, private router: Router) {

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

    this.configService.sendPostRequest(request).subscribe(
      palindromes => {
        this.router.navigate(['response'], { state: { palindromes: palindromes} });
    });


  }

}
