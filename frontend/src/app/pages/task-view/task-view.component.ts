import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { List } from 'src/app/models/list.model';
import { Task } from 'src/app/models/task.model';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';
import { ListService } from 'src/app/services/list.service';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-task-view',
  templateUrl: './task-view.component.html',
  styleUrls: ['./task-view.component.scss']
})
export class TaskViewComponent implements OnInit {
  listId = 0;
  // userId = 1;   //  privremeno
  userId: number | undefined = 0;
  user: any;
  listCheck = false;
  noList = false;
  noTask = false;
  lists: List[] = [];
  tasks: Task[] = [];

  constructor(private route: ActivatedRoute, private listService: ListService, private taskService: TaskService, private router: Router, private accountService: AccountService) { }

  ngOnInit(): void {
    this.getUser();
    this.route.params.subscribe((params: Params) => {
      this.listId = params['listId'];
      this.getLists(this.userId as number);
      if (this.listId != undefined) {
        this.listCheck = true;
        this.getTasks(this.listId);
      } else {
        this.listCheck = false;
      }
    });
  }

  getUser() {
    this.accountService.currentUser$.subscribe(user => {
      this.user = user;
      this.userId = this.user.id;
    });
  }

  getLists(userId: number) {
    this.listService.getLists(userId).subscribe(lists => {
      this.lists = lists;
      if (this.lists.length == 0) {
        this.noList = true;
      } else {
        this.noList = false;
      }
    });
  }

  getTasks(listId: number) {
    this.taskService.getTasks(listId).subscribe(tasks => {
      this.tasks = tasks;
      if (this.tasks.length == 0) {
        this.noTask = true;
      } else {
        this.noTask = false;
      }
    });
  }

  onTaskClick(taskId: number) {
    this.taskService.updateTaskStatus(taskId).subscribe(() => {
      this.getTasks(this.listId);
    });
  }

  editTask(id: string) {
    console.log(id);
  }

  deleteTask(taskId: number) {
    if(confirm("Do you want to delete this task?")) {
      this.taskService.deleteTask(taskId).subscribe(() => {
        this.getTasks(this.listId);
      });
    }
  }

  deleteList(listId: number) {
    if(confirm("Do you want to delete list?")) {
      this.listService.deleteList(listId).subscribe(() => {
        this.router.navigate(['lists/']);
      });
    }
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/check");
  }

}
