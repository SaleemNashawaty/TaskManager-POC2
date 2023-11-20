import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TasksListComponent } from './components/tasks-list/tasks-list.component';
import { SignInComponent } from './components/sign-in/sign-in.component';

const routes: Routes = [ {
  path: '',
  redirectTo: 'signIn',
  pathMatch: 'full',
},
{
  path: 'MyList',
  component: TasksListComponent,
},
{
  path: 'signIn',
  component: SignInComponent,
},
{
  path: '**',
  redirectTo: 'signIn',
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
