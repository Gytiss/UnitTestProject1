using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Tasks.v1;
using Google.Apis.Tasks.v1.Data;
using Google.Apis.Util.Store;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;

namespace UnitTestProject1.Services
{
    public class GoogleTasks
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/tasks-dotnet-quickstart.json
        static string[] Scopes = { TasksService.Scope.Tasks };
        static string ApplicationName = "Google Tasks API .NET Quickstart";
        string JsonDirectory = @"\\server\4Users\GytisG\QA\client_secret1.json";
        //string JsonDirectory2 = @"C:\Users\Gytis\Documents\Visual Studio 2015\Projects\UnitTestProject1\UnitTestProject1\client_secret1.json";

        public void GoogleTasksList()
        {
            UserCredential credential;

            using (var stream =
                new FileStream(JsonDirectory, FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/tasks-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Tasks API service.
            var service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            TasklistsResource.ListRequest listRequest = service.Tasklists.List();
            listRequest.MaxResults = 10;

            
            // List task lists.
            IList<TaskList> taskLists = listRequest.Execute().Items;

            Console.WriteLine("Task Lists:");
            if (taskLists != null && taskLists.Count > 0)
            {
                foreach (var taskList in taskLists)
                {
                    Console.WriteLine("{0} ({1})", taskList.Title, taskList.Id);
                    TestContext.Progress.WriteLine("{0} ({1})", taskList.Title, taskList.Id);
                }
            }
        }

        public void InsertGoogleTasksList(int number, string name)
        {
            UserCredential credential;

            using (var stream =
                new FileStream(JsonDirectory, FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/tasks-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Tasks API service.
            var service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            TasklistsResource.ListRequest listRequest = service.Tasklists.List();
            listRequest.MaxResults = 10;


            // Insert task lists.
            for (int i = 1; i < number+1; i++)
            {
                TaskList list = new TaskList { Title = name + i };
                list = service.Tasklists.Insert(list).Execute();
                TestContext.Progress.WriteLine($"Inserted tasks list id: {list.Id}, task list Name: {list.Title}");
                Console.WriteLine(list.Id);
            }
            
        }

        public void DeleteGoogleTasksList()
        {
            UserCredential credential;

            using (var stream =
                new FileStream(JsonDirectory, FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/tasks-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Tasks API service.
            var service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            TasklistsResource.ListRequest listRequest = service.Tasklists.List();
            listRequest.MaxResults = 10;


            // List task lists.
            IList<TaskList> taskLists = listRequest.Execute().Items;
            Console.WriteLine("Task Lists:");
            if (taskLists != null && taskLists.Count > 0)
            {
                //service.Tasklists.Delete("MDgzMDUyMTM4OTA0ODEwMDc1ODg6MzY3NzExMTow").Execute();
                foreach (var taskList in taskLists.Skip(1))
                {
                    //service.Tasklists.
                    service.Tasklists.Delete(taskList.Id).Execute();
                    Console.WriteLine("{0} ({1})", taskList.Title, taskList.Id);
                    TestContext.Progress.WriteLine("Deleted task list {0} ({1})", taskList.Title, taskList.Id);
                }
            }

        }

        public void InsertGoogleTasks(int number, string title, string note, string timeDue, string folder)
        {
            UserCredential credential;

            using (var stream =
                new FileStream(JsonDirectory, FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/tasks-dotnet-quickstart.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Tasks API service.
            var service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            for (int i = 1; i < number + 1; i++)
            {
                string complete = "2017-10-15T12:00:00.000Z";
                DateTime completed = Convert.ToDateTime(complete);
                DateTime dt = Convert.ToDateTime(timeDue);
                Task task = new Task { Title = title + i };
                task.Notes = note;
                task.Due = dt;
                //task.Completed = completed;
                Task result = service.Tasks.Insert(task, folder).Execute();
                TestContext.Progress.WriteLine("Inserted task:  " + result.Title);

            }

        }

        public void DeleteGoogleTasks(string folder)
        {
            UserCredential credential;

            using (var stream =
                new FileStream(JsonDirectory, FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/tasks-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Tasks API service.
            var service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


            Tasks tasks = service.Tasks.List(folder).Execute();
            int nr = tasks.Items.Count;
            if (tasks.Items != null)
            {
                foreach (Task task in tasks.Items)
                {
                    service.Tasks.Delete(folder, task.Id).Execute();
                    TestContext.Progress.WriteLine("Deleted task:  " + task.Title);
                }
            }

        }

    }

}

