import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonaNuevaComponent } from './persona-nueva.component';

const routes: Routes = [
  {
    path: '',
    component: PersonaNuevaComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonaNuevaRoutingModule { }
