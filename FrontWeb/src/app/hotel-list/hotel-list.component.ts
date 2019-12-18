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

  addHotel():void{
    
    let hotel: Hotel = {
      name: 'Blue Hotel Miami',
      star: 3
    };

    this.hotelService.addHotel(hotel)
      .subscribe(hotel => this.hotels.push(hotel));
  }

  updateHotel(hotel: Hotel):void{

    let newHotel: Hotel = {
      hotelId: hotel.hotelId,
      name: 'Dark Blue Hotel Lauriston',
      star: 3
    };

    this.hotelService.updateHotel(newHotel)
      .subscribe(o => this.getHotels());
  }

  deleteHotel(hotel: Hotel): void{
    
    this.hotelService.deleteHotel(hotel)
      .subscribe(o => {
        this.hotels = this.hotels.filter(h => h !== hotel);
      });

  }
}
