import { Component, OnInit } from '@angular/core';
import { IClientsDetails } from '../Iclient';
import { ClientDetailsService } from '../client-details.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {
result = new IClientsDetails();
searchResult=[];

  constructor(private  clientservice:ClientDetailsService) { }

  ngOnInit() {
  }

 Search( ){
   this.clientservice.Search(this.result)
   .subscribe(v=> {
    this.searchResult=v;
   })
  }
}
