import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { TasksWebService } from '../web-services/tasks.web.service';
import { UserModel } from '../models/user.model';
import { UsersWebService } from '../web-services/users.web.service';

@Injectable({
    providedIn: 'root'
})
export class UsersAsyncService {

    isPopulated = false;

    public loadingSbj = new BehaviorSubject<boolean>(false);
    public loadingObs = this.loadingSbj.asObservable();

    public usersListSbj = new ReplaySubject<UserModel[]>();
    public usersListObj = this.usersListSbj.asObservable();

    constructor(private userWebService: UsersWebService) { }

    populateData() {
        if (!this.isPopulated) {
            this.loadingSbj.next(true);
            this.userWebService.listUsersAsync()
                .subscribe(res => {
                    this.usersListSbj.next(res);
                    this.isPopulated = true;
                    this.loadingSbj.next(false);
                },
                    (err) => {
                        console.log(err);
                        this.loadingSbj.next(false);
                    });
        }
    }
}