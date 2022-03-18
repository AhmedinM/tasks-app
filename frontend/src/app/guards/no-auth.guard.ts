import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, Observable } from 'rxjs';
import { AccountService } from '../services/account.service';

@Injectable({
  providedIn: 'root'
})
export class NoAuthGuard implements CanActivate {
  
  constructor(private accountService: AccountService, private router: Router) {}

  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(user => {
        if (!user) return true;
        if (user && user.role !== "User") {
          if (user.role === "Admin") {
            this.router.navigate(['/admin/', user.id]);
            return false;
          } else {
            return true;
          }
        } else {
          this.router.navigateByUrl('/');
          return false;
        }
        
      })
    );
  }
  
}
