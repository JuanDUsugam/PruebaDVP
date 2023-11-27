import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonasRoutingModule } from './personas-routing.module';
import { StoreModule } from '@ngrx/store';

import { reducers, effects } from './store';
import { EffectsModule } from '@ngrx/effects';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PersonasRoutingModule,

    StoreModule.forFeature('persona', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class PersonasModule { }
