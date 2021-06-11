import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Job } from './jobs.models';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html'
})
export class JobsComponent {
  public jobs: Job[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Job[]>(baseUrl + 'api/jobs').subscribe(result => {
      this.jobs = result;
    }, error => console.error(error));
  }
}

