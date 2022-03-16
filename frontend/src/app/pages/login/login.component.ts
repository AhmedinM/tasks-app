import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup = this.fb.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
  });

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
  }

  // matchValues(matchTo: string): ValidatorFn {
  //   return (control: AbstractControl) => {
  //     return control?.value === control?.parent?.controls[matchTo].value ? null : {isMatching: true};
  //   }
  // }

  login() {
    console.log(this.loginForm.value);
  }

}
