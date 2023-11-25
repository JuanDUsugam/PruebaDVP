import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as fromRoot from '@app/store';
import * as fromUser from '@app/store/usuario';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'client-inmueble-app';

  user$ !: Observable<fromUser.UsuarioResponse>;
  isAuthorized$ !: Observable<boolean>;


  constructor(
    private store: Store<fromRoot.State>,
    private router: Router
    ){}
  ngOnInit() {
    this.user$ = this.store.pipe(select(fromUser.getUser)) as Observable<fromUser.UsuarioResponse>;
    this.isAuthorized$ = this.store.pipe(select(fromUser.getIsAuthorized)) as Observable<boolean>;

    this.store.dispatch(new fromUser.Init());
  }
  
  onSignOut() : void{
    localStorage.removeItem('token');
    this.store.dispatch(new fromUser.SignOut());
    this.router.navigate(['/auth/login']);
  }
}
