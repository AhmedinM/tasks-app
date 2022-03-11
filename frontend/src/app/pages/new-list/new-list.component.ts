import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ListService } from 'src/app/services/list.service';

@Component({
  selector: 'app-new-list',
  templateUrl: './new-list.component.html',
  styleUrls: ['./new-list.component.scss']
})
export class NewListComponent implements OnInit {
  userId = 1;

  constructor(private router: Router, private listService: ListService,) { }

  ngOnInit(): void {
  }

  createList(title: string) {
    this.listService.createList(title, this.userId).subscribe(() => {
      this.router.navigate(['/lists']);
    });
  }

  cancel() {
    this.router.navigate(['/lists']);
  }

}
