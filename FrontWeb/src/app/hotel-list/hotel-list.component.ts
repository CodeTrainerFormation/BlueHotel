import { Component, OnInit } from '@angular/core';

import { Hotel } from '../model/hotel';
import { HotelService } from '../hotel.service';

@Component({
  selector: 'app-hotel-list',
  templateUrl: './hotel-list.component.html',
  styleUrls: ['./hotel-list.component.css']
})
export class HotelListComponent implements OnInit {

  hotels: Hotel[];

  constructor(private hotelService: HotelService) { }

  ngOnInit() {
    this.getHotels();
  }

  getHotels(): void{
    this.hotelService.getHotels()
      .subscribe(hotelList => this.hotels = hotelList);
  }
}
