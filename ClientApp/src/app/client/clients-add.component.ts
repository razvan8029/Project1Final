import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Client } from './clients.models';

@Component({
  selector: 'app-client-add',
  templateUrl: './client-add.component.html'
})
export class ClientsAddComponent {
  public client: Client[];
    router: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    //http.get<Client[]>(baseUrl + 'api/clients').subscribe(result => {
      //this.clients = result;
    //}, error => console.error(error));
  }

  public saveClient() {
    this.http.post(this.baseUrl + 'api/PostClient', this.client).subscribe(result => {
      this.router.navigateByUrl("/client");
    }, error => console.error(error))
  }
}
