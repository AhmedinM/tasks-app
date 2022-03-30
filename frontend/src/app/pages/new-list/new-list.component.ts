import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { ListService } from 'src/app/services/list.service';

@Component({
  selector: 'app-new-list',
  templateUrl: './new-list.component.html',
  styleUrls: ['./new-list.component.scss']
})
export class NewListComponent implements OnInit {
  userId = 0;
  user: any;
  createForm: FormGroup = this.fb.group({
    title: ['', Validators.required]
  });

  constructor(private router: Router, private listService: ListService, private fb: FormBuilder, private route: ActivatedRoute, private accountService: AccountService) { }

  ngOnInit(): void {
    this.getUser();
    this.route.params.subscribe((params: Params) => {
      var id = params['userId'];

      if (id === 'undefined') {
        this.router.navigate(['lists/']);
      } else {
        var tempId = parseInt(id);
        if (tempId != this.userId) {
          this.router.navigateByUrl("/");
        }
      }
    });
  }

  getUser() {
    this.accountService.currentUser$.subscribe(user => {
      this.user = user;
      this.userId = this.user.id;
    });
  }

  createList() {
    this.listService.createList(this.createForm.value.title, this.userId).subscribe(() => {
      this.router.navigate(['/lists']);
    });
  }

  cancel() {
    this.router.navigate(['/lists']);
  }

}
