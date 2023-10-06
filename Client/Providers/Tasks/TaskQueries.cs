using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Providers.Tasks
{
    public static class TaskQueries
    {
        public static string GetTasks = @"query {
                                              tasks {
                                                      ID:id
                                                      Title:title
                                                      DateCreated:dateCreated
                                                      Description:description
                                                      DueDate:dueDate
                                                      Assignee:assignee {
                                                          Name:name
                                                      }
                                                      CreatedUser:createdUser {
                                                          Name:name
                                                      }
                                                      Status:status {
                                                          Name:name
                                                      }
                                                  }
                                              }";

        public static string AddTaskMutation = @"mutation AddTask($title: String!, $description:String ,$createdUserId:Int!,$assigneeId:Int,$statusId:Int!,$dateCreated: DateTime!, $dueDate:DateTime) {
    addTask(
        input: {title: $title, description: $description, createdUserId: $createdUserId, assigneeId: $assigneeId, statusId:$statusId,dateCreated:$dateCreated,dueDate:$dueDate}
    ) {
    
      
            Id:id
          
        
    }
}
";
    }
}
