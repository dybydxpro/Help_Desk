import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MessageBroadcastComponent } from './components/message-broadcast/message-broadcast.component';

const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full'},
  { path: 'msg', component: MessageBroadcastComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
