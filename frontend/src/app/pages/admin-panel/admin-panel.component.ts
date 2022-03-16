import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {
  users: User[] = [];
  window = 1;

  constructor(private route: ActivatedRoute, private userService: UserService) { }

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

}
