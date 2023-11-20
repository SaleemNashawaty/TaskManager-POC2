import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from '../models/user.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class UsersWebService {

    apiPrefix: string = environment.apiUrl + "User";

    constructor(private httpClient: HttpClient) {}
    
    listUsersAsync(): Observable<UserModel[]> {
        return this.httpClient.get<UserModel[]>(this.apiPrefix);
    }
}