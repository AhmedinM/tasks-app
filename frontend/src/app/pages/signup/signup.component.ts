import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  registerForm: FormGroup = this.fb.group({
    email: ['', Validators.required],
    password: ['', [Validators.required, Validators.minLength(3)]],
    confirmPassword: ['', [Validators.required, this.matchValues('password')]]
  });

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
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

  register() {
    console.log(this.registerForm.value);
  }

}
