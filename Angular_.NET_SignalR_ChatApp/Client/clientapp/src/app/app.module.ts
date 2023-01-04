import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './components/user/index/index.component';
import { CreateComponent } from './components/user/create/create.component';
import { ViewComponent } from './components/user/view/view.component';
import { EditComponent } from './components/user/edit/edit.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    CreateComponent,
    ViewComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
