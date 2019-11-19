import { Component, OnInit, Input } from '@angular/core';
import { ClientDetailsService } from '../client-details.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {
 // public client=[];
  ClientDetails: any;
  @Input() searchResult;
  constructor(private clientservice:ClientDetailsService) { }

  ngOnInit() {
    //this.clientservice.getClient().subscribe(data=>{this.client=data;});
  }

}
