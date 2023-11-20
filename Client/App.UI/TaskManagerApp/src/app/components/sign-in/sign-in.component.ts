import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, takeUntil } from 'rxjs';
import { UserModel } from 'src/app/data/models/user.model';
import { AuthService } from 'src/app/data/services/auth.service';
import { UsersAsyncService } from 'src/app/data/services/users.async.service';
import { Observe } from 'src/app/decorators/observe';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss'],
})
export class SignInComponent implements OnInit {

  usersList: UserModel[] = [];
  selectedUser:any;
  constructor(private router: Router,private authService:AuthService, private userAsyncService:UsersAsyncService) {
  }

  async ngOnInit() {
    this.authService.setAuth(false);
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

OnChange(data:any){
this.selectedUser=data;
}
signIn(): void {

    sessionStorage.setItem("UserId",this.selectedUser.Id);
    sessionStorage.setItem("UserEmail",this.selectedUser.Email);
    sessionStorage.setItem("UserName",this.selectedUser.Name);
    this.authService.setAuth(true);
    this.router.navigate(['/MyList']);
  }
}