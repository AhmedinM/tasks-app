import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.scss']
})
export class EditTaskComponent implements OnInit {
  listId: number = 0;
  taskId: number = 0;
  task: any;
  // text = "";
  // editForm: FormGroup;

  constructor(private router: Router, private route: ActivatedRoute, private taskService: TaskService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.listId = params['listId'];
      this.taskId = params['taskId'];
      this.getTask();
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
    // console.log(this.editForm.value.text);
    this.taskService.updateTask(this.taskId, this.task.text).subscribe(() => {
      this.router.navigate(["lists/" + this.listId]);
    });
  }

  cancel() {
    this.router.navigate(["lists/" + this.listId]);
  }

}
