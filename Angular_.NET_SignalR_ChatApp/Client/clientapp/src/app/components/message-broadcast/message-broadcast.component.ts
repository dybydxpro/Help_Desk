import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

import { DataService } from './../../services/data.service';
import { Message } from 'src/app/models/message';

@Component({
  selector: 'app-message-broadcast',
  templateUrl: './message-broadcast.component.html',
  styleUrls: ['./message-broadcast.component.scss']
})

export class MessageBroadcastComponent implements OnInit {
  private hubConnection?: HubConnection;
  mainDataSet: any[] = [];
  public usr: string = "user"+Math.floor(Math.random() * 100);
  public txtBox: string = "";
   
  constructor(public dataService: DataService) {}

  ngOnInit(): void{
    this.hubConnection = new HubConnectionBuilder().withUrl('https://localhost:44325/notify').build();
    this.hubConnection.start()
    .then(()=>
      console.log('connection start'))
    .catch(err=>{
      console.log('Error while establishing the connection')
    });

    this.hubConnection.on("chatStation1", (dt) => {
      console.table(dt);
      this.mainDataSet.push(dt);
    })
  }

  setValue(value: any){
    this.txtBox = value.target.value;
    console.log(value.target.value);
  }

  postData(){
    let dataset = {
      "user": this.usr,
      "msgScript": this.txtBox
    };

    this.dataService.createData(dataset).subscribe((data: any) =>{
      console.log(data);
    }, error => {
      console.error(error);
    });

    this.txtBox = "";
  }
}
