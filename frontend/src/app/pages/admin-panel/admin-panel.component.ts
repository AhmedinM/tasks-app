import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
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
  user: any;

  registerForm: FormGroup = this.fb.group({
    email: ['', [Validators.email, Validators.required]],
    password: ['', [Validators.required, Validators.minLength(3)]]
  });

  deleteForm: FormGroup = this.fb.group({
    password: ['', [Validators.required]]
  });

  constructor(private route: ActivatedRoute, private userService: UserService, private fb: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.getUser();
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

  getUser() {
    this.accountService.currentUser$.subscribe(user => {
      this.user = user;
    });
  }

  getUsers() {
    this.userService.getUsers(this.user.id).subscribe(users => {
      this.users = users;
    });
  }

  registerAdmin() {
    this.accountService.addAdmin(this.registerForm.value.email, this.registerForm.value.password).subscribe(() => {
      this.saved = true
      this.error = null;
    }, err => {
      this.saved = false;
      this.error = err;
    });
  }

  deleteAdmin() {
    if (confirm("Are you sure you want to delete your account?")) {
      this.accountService.deleteAccount(this.user.id, this.deleteForm.value.password).subscribe(() => {
        this.logout();
      }, err => {
        this.error2 = err;
      });
    }
  }

  deleteUser(id: number | undefined) {
    if (confirm("Are you sure you want to remove this user?") && id != undefined) {
      this.accountService.deleteUser(id).subscribe(() => {
        alert("User is removed.");
        this.getUsers();
      }, err => {
        console.log(err);
      });
    }
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/check");
  }

}
