import { Component, OnInit } from '@angular/core';
import { Palindromes } from '../config/palindromes.model';

@Component({
  selector: 'app-response',
  templateUrl: './response.component.html',
  styleUrls: ['./response.component.css']
})
export class ResponseComponent implements OnInit {

  constructor() { }

  palindromes: Palindromes | undefined;
  //palindromes : string[] | undefined;
  count : number | undefined;

  ngOnInit(): void {
    this.palindromes = window.history.state.palindromes;
  }

}
