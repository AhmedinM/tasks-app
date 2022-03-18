import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, Observable } from 'rxjs';
import { AccountService } from '../services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private accountService: AccountService, private router: Router) {}

  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(user => {
        if (user) return true;
        this.router.navigateByUrl('/check');
        return false;
      })
    );

  // canActivate(): boolean {
  //   var token = localStorage.getItem("user");
  //   if (token) {
  //     return true;
  //   } else {
  //     this.router.navigate(["/check"]);
  //     return false;
  //   }
  }
  
}
