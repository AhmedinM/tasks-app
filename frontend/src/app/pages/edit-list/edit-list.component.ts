import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { List } from 'src/app/models/list.model';
import { AccountService } from 'src/app/services/account.service';
import { ListService } from 'src/app/services/list.service';

@Component({
  selector: 'app-edit-list',
  templateUrl: './edit-list.component.html',
  styleUrls: ['./edit-list.component.scss']
})
export class EditListComponent implements OnInit {
  listId = 0;
  list: List = {};
  user: any;
  userId = 0;

  editForm: FormGroup = this.fb.group({
    title: ['', Validators.required]
  });

  constructor(private router: Router, private route: ActivatedRoute, private listService: ListService, private fb: FormBuilder, private accountService: AccountService) { }

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

  saveList() {
    this.listService.updateList(this.listId, this.editForm.value.title).subscribe(() => {
      this.router.navigate(["/lists", this.listId]);
    });
  }

  cancel() { 
    this.router.navigate(["/lists", this.listId]);
  }
}
