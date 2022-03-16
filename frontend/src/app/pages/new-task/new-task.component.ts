import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-new-task',
  templateUrl: './new-task.component.html',
  styleUrls: ['./new-task.component.scss']
})
export class NewTaskComponent implements OnInit {
  listId = 0;
  createForm: FormGroup = this.fb.group({
    text: ['', Validators.required]
  });

  constructor(private router: Router, private route: ActivatedRoute, private taskService: TaskService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      var id = params['listId'];
      
      if (id === 'undefined') {
        this.router.navigate(['lists/']);
      } else {
        this.listId = parseInt(id);
      }
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
