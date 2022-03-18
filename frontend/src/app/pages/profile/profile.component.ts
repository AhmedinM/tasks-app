import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  email = '';
  user: any;
  saved = false;
  error: any;
  deleteError: any;

  passwordForm: FormGroup = this.fb.group({
    password: ['', [Validators.required, Validators.minLength(3)]],
    confirmPassword: ['', [Validators.required, this.matchValues('password')]]
  });
  deleteForm: FormGroup = this.fb.group({
    password: ['', [Validators.required, Validators.minLength(3)]],
  });

  constructor(private accountService: AccountService, private router:Router, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getUser();
    this.saved = false;
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      const controls = control?.parent?.controls as { [key: string]: AbstractControl; };
      let matchToControl = null;
      if (controls) matchToControl = controls[matchTo];
      return control?.value === matchToControl?.value
        ? null : { isMatching: true }
    }
  }

  getUser() {
    this.accountService.currentUser$.subscribe(user => {
      this.user = user;
    });
  }

  changePassword() {
    this.accountService.changePassword(this.passwordForm.value.password, this.user.id).subscribe(() => {
      this.saved = true;
    }, err => {
      this.error = err;
    });
  }

  deleteUser() {
    if (confirm("Are you sure you want to delete your account?")) {
      this.accountService.deleteAccount(this.user.id, this.deleteForm.value.password).subscribe(() => {
        this.logout();
      }, err => {
        this.deleteError = err;
      });
    }
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/check");
  }

}
