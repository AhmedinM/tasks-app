import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { ListService } from 'src/app/services/list.service';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-new-task',
  templateUrl: './new-task.component.html',
  styleUrls: ['./new-task.component.scss']
})
export class NewTaskComponent implements OnInit {
  listId = 0;

  user: any;
  userId = 0;
  list: any;
  createForm: FormGroup = this.fb.group({
    text: ['', Validators.required]
  });

  constructor(private router: Router, private route: ActivatedRoute, private taskService: TaskService, private fb: FormBuilder, private accountService: AccountService, private listService: ListService) { }

  ngOnInit(): void {
    this.getUser();
    this.route.params.subscribe((params: Params) => {
      var id = params['listId'];
      
      if (id === 'undefined') {
        this.router.navigate(['lists/']);
      } else {
        this.listId = parseInt(id);
        this.getList();
      }
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

  createTask() {
    this.taskService.createTask(this.createForm.value.text, this.listId).subscribe(() => {
      this.router.navigate(['lists/' + this.listId]);
    });
    
  }

  cancel() {
    this.router.navigate(['lists/' + this.listId]);
  }

}
