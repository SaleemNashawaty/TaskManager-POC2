import { Component, OnInit } from "@angular/core";
import { FormBuilder , FormControl, Validators} from '@angular/forms';
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Observable, takeUntil } from "rxjs";
import { AddTaskModel, TaskModel } from "src/app/data/models/task.model";
import { UserModel } from "src/app/data/models/user.model";
import { UsersAsyncService } from "src/app/data/services/users.async.service";
import { TasksWebService } from "src/app/data/web-services/tasks.web.service";
import { Observe } from "src/app/decorators/observe";

@Component({
  selector: 'add-new-task',
  templateUrl: './add-new-task.component.html',
  styleUrls: ['./add-new-task.component.scss']
})
export class AddNewTaskComponent implements OnInit {
  
  usersList:UserModel[]=[];
  addTaskForm = this.formBuilder.group({
    Title: new FormControl(),
    Description: new FormControl(),
    DueDate:new FormControl(),
    Assignee:new FormControl()
  });
constructor(private formBuilder: FormBuilder,private modalService: NgbModal, private userAsyncService:UsersAsyncService, private taskWebService:TasksWebService) {
}
async ngOnInit() {
  this.userAsyncService.populateData();
}


@Observe()
private observeUsersListModel(destroyedObs: Observable<void>): void {
  this.userAsyncService.usersListObj
    .pipe(
      takeUntil(destroyedObs)
    )
    .subscribe((data: UserModel[]) => {
        this.usersList=data;
    });
}
save(): void {
  this.addTaskForm.markAllAsTouched();
  if(this.addTaskForm.valid){
  let addTaskModel:AddTaskModel = 
  {
    Title:this.addTaskForm?.value?.Title,
    Description:this.addTaskForm?.value?.Description,
    Duedate: this.addTaskForm?.value?.DueDate,
    AssigneeId:this.addTaskForm?.value?.Assignee,
    CreatedUserId:Number(sessionStorage.getItem('UserId')),
    DateCreated:new Date(),
    StatusId:2
  }
   this.taskWebService.addTask(addTaskModel).subscribe(res=>{  this.modalService.dismissAll();});
}
}
clearForm(): void {
  this.addTaskForm.reset();
}

close(){
  this.clearForm();
  this.modalService.dismissAll();}
}
