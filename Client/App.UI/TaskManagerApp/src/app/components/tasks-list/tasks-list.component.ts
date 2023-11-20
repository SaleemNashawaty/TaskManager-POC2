import { Component, OnInit } from '@angular/core';
import { TaskModel } from 'src/app/data/models/task.model';
import { TasksWebService } from 'src/app/data/web-services/tasks.web.service';
import { AddNewTaskComponent } from '../add-new-task/add-new-task.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observe } from 'src/app/decorators/observe';
import { Observable, takeUntil } from 'rxjs';
import { TasksAsyncService } from 'src/app/data/services/tasks.async.service';
import { SignalRService } from 'src/app/data/web-services/signalR.service';


@Component({
  selector: 'tasks-list',
  templateUrl: './tasks-list.component.html',
  styleUrls: ['./tasks-list.component.scss']
})
export class TasksListComponent implements OnInit {

  tasksList: TaskModel[] = [];
  userId = Number(sessionStorage.getItem("UserId"));
  constructor(private tasksService: TasksAsyncService,private modalService: NgbModal,
    private signalRService: SignalRService) {
  }
  newTask() {
   this.modalService.open(AddNewTaskComponent, {backdrop: 'static', keyboard: false, windowClass:'addNewTaskModal' });
  } 
    ngOnInit() {
        this.signalRService.startConnection();
        this.signalRService.OnTaskAddedListener();   
      this.tasksService.populateData();
  }
  
  @Observe()
  private observeTasksListModel(destroyedObs: Observable<void>): void {
    this.tasksService.tasksListObj
      .pipe(
        takeUntil(destroyedObs)
      )
      .subscribe((data: TaskModel[]) => {
          this.tasksList=data;
      });
  }
}
