import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {
  users: User[] = [];
  window = 1;
  error: any;
  error2: any;
  saved = false;
  adminId = 1;

  registerForm: FormGroup = this.fb.group({
    email: ['', [Validators.email, Validators.required]],
    password: ['', [Validators.required, Validators.minLength(3)]]
  });

  deleteForm: FormGroup = this.fb.group({
    password: ['', [Validators.required]]
  });

  constructor(private route: ActivatedRoute, private userService: UserService, private fb: FormBuilder, private accountService: AccountService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      var num = params["window"];
      if (num == 2 || num == 3) {
        this.window = num;
      } else {
        this.window = 1;
        this.getUsers();
      }
    });
  }

  getUsers() {
    this.userService.getUsers().subscribe(users => {
      this.users = users;
    });
  }

  registerAdmin() {
    this.accountService.addAdmin(this.registerForm.value.email, this.registerForm.value.password).subscribe(() => {
      this.saved = true
    }, err => {
      this.saved = false;
      this.error = err;
    });
  }

  deleteAdmin() {
    this.accountService.deleteAccount(this.adminId, this.deleteForm.value.password).subscribe(() => {
      this.logout();
    }, err => {
      this.error2 = err;
    });
  }

  logout() {
    localStorage.removeItem("user");
  }

}
