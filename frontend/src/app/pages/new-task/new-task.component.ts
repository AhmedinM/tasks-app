import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-new-task',
  templateUrl: './new-task.component.html',
  styleUrls: ['./new-task.component.scss']
})
export class NewTaskComponent implements OnInit {
  listId: number = 0;

  constructor(private router: Router, private route: ActivatedRoute, private taskService: TaskService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.listId = params['listId'];
    });
  }

  createTask(text: string) {
    this.taskService.createTask(text, this.listId).subscribe(() => {
      this.router.navigate(['lists/' + this.listId]);
    });
    
  }

  cancel() {
    this.router.navigate(['lists/' + this.listId]);
  }

}
