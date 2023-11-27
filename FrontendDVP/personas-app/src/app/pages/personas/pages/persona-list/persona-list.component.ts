import { Component, OnInit } from '@angular/core';
import * as fromRoot from '@app/store';
import * as fromList from '../../store/save';
import { Observable } from 'rxjs';
import { PersonaResponse } from '../../store/save';
import { Store, select } from '@ngrx/store';

@Component({
  selector: 'app-persona-list',
  templateUrl: './persona-list.component.html',
  styleUrls: ['./persona-list.component.scss']
})
export class PersonaListComponent implements OnInit{
  personas$ !: Observable<PersonaResponse[] | null>;
  loading$ !:Observable<boolean | null>;

  
  constructor(
    private store : Store<fromRoot.State>
  ){}


  ngOnInit(): void {
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading));
    this.personas$ = this.store.pipe(select(fromList.getPersonas));
  }
}
