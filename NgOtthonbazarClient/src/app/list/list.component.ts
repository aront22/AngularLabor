import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Advertisement } from '../models';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  advertisements: Advertisement[] = [];
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getAdvertisements();
  }
  getAdvertisements() {
    this.http.get<Advertisement[]>('/api/advertisements')
      .subscribe(resp => this.advertisements = resp);
  }
}

