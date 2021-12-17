import { Component } from '@angular/core';
import { Loader } from './util/core/loader';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Gestão de Horários';

  getLoading() {
    return Loader.isLoading;
  }
}
