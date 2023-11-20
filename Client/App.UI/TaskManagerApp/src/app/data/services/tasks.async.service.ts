import { Injectable } from '@angular/core';
import { TaskModel } from '../models/task.model';
import { BehaviorSubject, map, Observable, ReplaySubject } from 'rxjs';
import { TasksWebService } from '../web-services/tasks.web.service';

@Injectable({
  providedIn: 'root'
})
export class TasksAsyncService {

    public loadingSbj = new BehaviorSubject<boolean>(false);
    public loadingObs = this.loadingSbj.asObservable();

    public tasksListSbj = new ReplaySubject<TaskModel[]>();
    public tasksListObj = this.tasksListSbj.asObservable();

    constructor(private taskWebService:TasksWebService) {}

    populateData() {
        var id=sessionStorage.getItem("UserId");
        if(id){
            this.loadingSbj.next(true);
            console.log(+id);
        this.taskWebService.getTasksByUserId(+id)
            .subscribe(res => {
                    this.tasksListSbj.next(res);
                    this.loadingSbj.next(false);
                },
                (err) => {
                    console.log(err);
                    this.loadingSbj.next(false);
                });
    }}
}