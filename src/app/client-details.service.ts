import { Injectable } from '@angular/core';
import{ HttpClient } from '@angular/common/Http';
import { Observable } from 'rxjs';
import { IClientsDetails } from './Iclient';

@Injectable({
  providedIn: 'root'
})
export class ClientDetailsService {
private Url='https://localhost:44394/';
  constructor(private http: HttpClient) { }
  
  Search(result:IClientsDetails) : Observable<IClientsDetails[]>
  {
let NameUrl=`${this.Url}DefaultResult/`;
if(result.FirstName != undefined){
  NameUrl = `${NameUrl}${result.FirstName}`
}
if(result.LastName !=undefined){
  NameUrl=`${NameUrl}${result.LastName}`
}
return this.http.get<IClientsDetails[]>(NameUrl);
  }
  }

