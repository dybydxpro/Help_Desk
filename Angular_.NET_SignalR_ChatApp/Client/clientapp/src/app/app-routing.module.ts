import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './components/user/index/index.component';
import { CreateComponent } from './components/user/create/create.component';
import { ViewComponent } from './components/user/view/view.component';
import { EditComponent } from './components/user/edit/edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full'},
  { path: 'user', component: IndexComponent },
  { path: 'user/create', component: CreateComponent },
  { path: 'user/view/:id', component: ViewComponent },
  { path: 'user/edit/:id', component: EditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
