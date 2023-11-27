import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@app/guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'nuevo',
    loadChildren: () => import ('./pages/persona-nueva/persona-nueva.module').then(m => m.PersonaNuevaModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'list',
    loadChildren: () => import ('./pages/persona-list/persona-list.module').then(m => m.PersonaListModule),
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonasRoutingModule { }
