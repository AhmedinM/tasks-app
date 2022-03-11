import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ListService } from 'src/app/services/list.service';

@Component({
  selector: 'app-edit-list',
  templateUrl: './edit-list.component.html',
  styleUrls: ['./edit-list.component.scss']
})
export class EditListComponent implements OnInit {
  listId = 0;

  constructor(private router: Router, private route: ActivatedRoute, private listService: ListService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.listId = params['listId'];
    });
  }

  saveList(title: string) {
    this.listService.updateList(this.listId, title).subscribe(() => {
      this.router.navigate(["/"]);
    });
  }

  cancel() { 
    this.router.navigate(["/lists"]);
  }
}
