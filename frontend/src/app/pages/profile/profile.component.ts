import { Component, OnInit } from '@angular/core';
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

  constructor(private accountService: AccountService, private router:Router) { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.accountService.currentUser$.subscribe(user => {
      this.user = user;
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/check");
  }

}
