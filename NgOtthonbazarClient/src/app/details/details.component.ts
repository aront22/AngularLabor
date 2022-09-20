import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Advertisement } from '../models';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  advertisement: Advertisement | undefined;
  constructor(private route: ActivatedRoute, private http: HttpClient) { }
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.http.get<Advertisement>('api/advertisements/' + params['id'])
        .subscribe(resp => this.advertisement = resp);
    });
  }
}

