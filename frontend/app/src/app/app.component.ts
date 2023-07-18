import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./components/header.component";
import { NavigationComponent } from "./components/navigation.component";

@Component({
    selector: 'app-root',
    standalone: true, // Angular 2 - 15 (16) didn't have this. You had to have a thing called an "Angular Module" that each component belonged to. Awkward + confusing. Currently on Angular 16 and doing standalone components is now the most recent thing
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    imports: [CommonModule, RouterOutlet, HeaderComponent, NavigationComponent]
})
export class AppComponent {
  title = 'Intro to Programming Sample App.'; // Controls the name of the webpage
  favcolor = 'Red';
}
