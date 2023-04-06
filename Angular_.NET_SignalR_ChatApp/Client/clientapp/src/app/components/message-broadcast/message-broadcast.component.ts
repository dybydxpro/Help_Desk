import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpHeaders, HttpUrlEncodingCodec } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { DataService } from './../../services/data.service';

@Component({
  selector: 'app-message-broadcast',
  templateUrl: './message-broadcast.component.html',
  styleUrls: ['./message-broadcast.component.scss']
})
export class MessageBroadcastComponent implements OnInit {
  private hubConnection?: HubConnection;
  public data: any = {};
  public usr: string = "user"+"11";
  public txtBox: string = "";
  private apiURL = "https://jsonplaceholder.typicode.com";
    
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
   
  constructor(private httpClient: HttpClient, public dataService: DataService) { }

  ngOnInit(): void{
    this.hubConnection = new HubConnectionBuilder().withUrl('https://localhost:44325/notify').build();
    this.hubConnection.start()
    .then(()=>
      console.log('connection start'))
    .catch(err=>{
      console.log('Error while establishing the connection')
    });

    this.retreave;
  }

  retreave(){
    this.dataService.get().subscribe((data: any) =>{
      this.data = data;
      console.table(data);
    }, error => {
      console.error(error);
    });
  }

  postData(){

  }
}
