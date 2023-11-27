import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonaNuevaRoutingModule } from './persona-nueva-routing.module';
import { PersonaNuevaComponent } from './persona-nueva.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { SpinnerModule } from '@app/shared/indicators';


@NgModule({
  declarations: [
    PersonaNuevaComponent
  ],
  imports: [
    CommonModule,
    PersonaNuevaRoutingModule,

    MatToolbarModule,
    MatIconModule,
    MatFormFieldModule,
    MatButtonModule,
    FormsModule,
    MatInputModule,
    MatCardModule,
    FlexLayoutModule,
    SpinnerModule,
  ]
})
export class PersonaNuevaModule { }
