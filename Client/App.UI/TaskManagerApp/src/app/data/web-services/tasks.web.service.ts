import { Injectable } from '@angular/core';
import { AddTaskModel, TaskModel } from '../models/task.model';
import { map, Observable } from 'rxjs';
import { UserModel } from '../models/user.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TasksWebService {

  apiPrefix= environment.apiUrl+"Task";
  constructor(private httpClient:HttpClient) {
  }
  getTasksByUserId(userId:number):Observable<TaskModel[]>{
    return this.httpClient.get<TaskModel[]>(this.apiPrefix);
  }
  addTask(model:AddTaskModel):Observable<number>{
    return this.httpClient.post<number>(this.apiPrefix,model);
  }
}