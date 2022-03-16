import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Task } from 'src/app/models/task.model';
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

  editForm: FormGroup = this.fb.group({
    text: ['', Validators.required]
  });

  constructor(private router: Router, private route: ActivatedRoute, private taskService: TaskService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      var lId = params['listId'];
      var tId = params['taskId'];
      
      if (lId === 'undefined' || tId === 'undefined') {
        this.router.navigate(['lists/']);
      } else {
        this.listId = parseInt(lId);
        this.taskId = parseInt(tId);
        this.getTask();
      }
      // this.initializeForm();
    });
  }

  // initializeForm() {
  //   this.editForm = new FormGroup({
  //     text: new FormControl(this.task.text, Validators.required)
  //   });
  // }

  getTask() {
    this.taskService.getTask(this.taskId).subscribe(task => {
      this.task = task;
      // this.text = this.task.text;
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
