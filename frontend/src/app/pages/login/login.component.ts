import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  error: any;

  loginForm: FormGroup = this.fb.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
  });

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  // matchValues(matchTo: string): ValidatorFn {
  //   return (control: AbstractControl) => {
  //     return control?.value === control?.parent?.controls[matchTo].value ? null : {isMatching: true};
  //   }
  // }

  login() {
    // console.log(this.loginForm.value);
    // PIPE ili SUBSCRIBE
    this.accountService.login(this.loginForm.value.email, this.loginForm.value.password).subscribe( () => {
      this.router.navigateByUrl("/lists");
    }, err => {
      this.error = err;
    });
  }

}
