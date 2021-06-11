import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Instalator } from './intalators.models';

@Component({
  selector: 'app-instalator',
  templateUrl: './instalator.component.html'
})
export class InstalatorsComponent {
  public instalators: Instalator[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Instalator[]>(baseUrl + 'api/instalators').subscribe(result => {
      this.instalators = result;
    }, error => console.error(error));
  }
}
