export interface TaskModel{
    Id: number;
    Title:string;
    Description:string;
    DueDate:Date;
    AssignedToName:string;
    CreatedByName:string ;
    DateCreated:Date;
    Status:string;
}
export interface AddTaskModel{
    Title:string;
    Description:string;
    Duedate:Date;
    AssigneeId:number;
    CreatedUserId:number ;
    DateCreated:Date;
    StatusId:number;
}