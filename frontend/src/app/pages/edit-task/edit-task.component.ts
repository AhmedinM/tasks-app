import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Task } from 'src/app/models/task.model';
import { AccountService } from 'src/app/services/account.service';
import { ListService } from 'src/app/services/list.service';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.scss']
})
export class EditTaskComponent implements OnInit {
  listId: number = 0;
  taskId: number = 0;
  task: Task = {id: 0};

  user: any;
  userId = 0;
  list: any;

  editForm: FormGroup = this.fb.group({
    text: ['', Validators.required]
  });

  constructor(private router: Router, private route: ActivatedRoute, private taskService: TaskService, private fb: FormBuilder, private accountService: AccountService, private listService: ListService) { }

  ngOnInit(): void {
    this.getUser();
    this.route.params.subscribe((params: Params) => {
      var lId = params['listId'];
      var tId = params['taskId'];
      
      if (lId === 'undefined' || tId === 'undefined') {
        this.router.navigate(['lists/']);
      } else {
        this.listId = parseInt(lId);
        this.getList();
        this.taskId = parseInt(tId);
        this.getTask();
      }
      // this.initializeForm();
    });
  }

  getUser() {
    this.accountService.currentUser$.subscribe(user => {
      this.user = user;
      this.userId = this.user.id;
    });
  }

  getList() {
    this.listService.getList(this.listId).subscribe(list => {
      this.list = list;
      if (list.userId != this.userId) {
        this.router.navigateByUrl("/");
      }
    }, err => {
      this.router.navigateByUrl("/");
    });
  }

  getTask() {
    this.taskService.getTask(this.taskId).subscribe(task => {
      this.task = task;
      // this.text = this.task.text;
      if (task.listId != this.listId) {
        this.router.navigateByUrl("/");
      }
    }, err => {
      this.router.navigateByUrl("/");
    });
  }

  saveTask() {
    this.taskService.updateTask(this.taskId, this.editForm.value.text).subscribe(() => {
      this.router.navigate(["lists/" + this.listId]);
    });
  }

  cancel() {
    this.router.navigate(["lists/" + this.listId]);
  }

}
