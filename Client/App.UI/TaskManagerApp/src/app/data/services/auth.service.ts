import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  private isAuthenticatedSbj = new BehaviorSubject<boolean>(false);
  public isAuthenticatedObs = this.isAuthenticatedSbj.asObservable();


  public setAuth(isAuthenticate: boolean) {
    if (isAuthenticate === true) {
      localStorage.setItem("isAuthenticated", 'true');
    } else { localStorage.setItem("isAuthenticated", 'false'); }
    this.isAuthenticatedSbj.next(isAuthenticate);
  }
  public getAuth(): boolean {
    var result=localStorage.getItem("isAuthenticated");
    if (result === 'true') {
      return true;
    } else { return false;}
  }
}