import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { LayoutModule } from "@progress/kendo-angular-layout";
import { CommonModule } from "@angular/common";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LabelModule } from "@progress/kendo-angular-label";
import { IconsModule } from "@progress/kendo-angular-icons";
import { InputsModule } from "@progress/kendo-angular-inputs";
import { ButtonsModule } from "@progress/kendo-angular-buttons";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { TasksListComponent } from './components/tasks-list/tasks-list.component';
import { AddNewTaskComponent } from './components/add-new-task/add-new-task.component';
import { HttpClientModule } from '@angular/common/http';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { SignInComponent } from './components/sign-in/sign-in.component';
@NgModule({
  declarations: [
    AppComponent,
    TasksListComponent,
    AddNewTaskComponent,
    SignInComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DateInputsModule,
    HttpClientModule,
    LayoutModule,
    BrowserAnimationsModule,
    GridModule,
    FormsModule,
    DropDownsModule,
    LabelModule,
    IconsModule,
    ButtonsModule,
    InputsModule,
    ReactiveFormsModule,
    CommonModule,
    NgbModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
