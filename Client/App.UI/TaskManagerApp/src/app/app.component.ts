import { Component, OnInit } from '@angular/core';
import { Observable, takeUntil } from 'rxjs';
import { AuthService } from './data/services/auth.service';
import { Observe } from './decorators/observe';
import { Router } from '@angular/router';

    
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  isAuthenticated: boolean= this.authService.getAuth();
  constructor(private authService:AuthService, private router:Router) {
  }

  ngOnInit(){

  }
  signOut(){
    sessionStorage.clear();
    this.authService.setAuth(false);
  }
  getUserName(){
    return sessionStorage.getItem('UserName');
  }

  @Observe()
  private observeAppSettings(destroyedObs: Observable<void>): void {
    this.authService.isAuthenticatedObs
      .pipe(
        takeUntil(destroyedObs)
      )
      .subscribe(() => {
        this.isAuthenticated = this.authService.getAuth();
      });
  }
}
