import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard.component';
import { AboutComponent } from './pages/about.components';

export const routes: Routes = [
{
    path: 'dashboard',
    component: DashboardComponent
},
{
    path: 'about',
    component: AboutComponent
} ,
{
    path: '**', // Specifies "anything else"
    redirectTo: 'dashboard'
}

];
