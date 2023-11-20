import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { map, takeUntil } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { TasksAsyncService } from '../services/tasks.async.service';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  constructor( private tasksService:TasksAsyncService) { }
  public hubConnection: any;
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.signalR.url)
      .build();
    this.hubConnection.start()
    .then(() => console.log('Connection started'))
    .catch((err: string) => console.log('Error while starting connection: ' + err))
  }

  public OnTaskAddedListener = () => {
    this.hubConnection.on('ontaskadded', (res:any) => {
        console.log('New Message' + res);
        this.tasksService.populateData();
    });
  }
}

