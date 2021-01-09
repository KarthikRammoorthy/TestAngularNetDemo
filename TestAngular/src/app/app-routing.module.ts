import { ResponseComponent } from './response/response.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { ShellComponent } from './shell/shell.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: ShellComponent,
    pathMatch: 'full',
    data: {
      id: 'shell',
      label: 'Shell',
      breadcrumb: 'Home'
    }
  },
  {
    path: 'response',
    component: ResponseComponent,
    pathMatch: 'full',
    data: {
      id: 'response',
      label: 'Response',
      breadcrumb: 'Response'
    }
  },
  { path: '**', component: PagenotfoundComponent, data: { id: 'notfound'}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
