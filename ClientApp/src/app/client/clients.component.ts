import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Client } from './clients.models';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html'
})
export class ClientsComponent {
  public clients: Client[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Client[]>(baseUrl + 'api/clients').subscribe(result => {
      this.clients = result;
    }, error => console.error(error));
  }
}
