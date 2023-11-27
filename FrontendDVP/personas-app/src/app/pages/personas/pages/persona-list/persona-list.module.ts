import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonaListRoutingModule } from './persona-list-routing.module';
import { PersonaListComponent } from './persona-list.component';


@NgModule({
  declarations: [
    PersonaListComponent
  ],
  imports: [
    CommonModule,
    PersonaListRoutingModule
  ]
})
export class PersonaListModule { }
