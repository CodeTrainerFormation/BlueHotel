import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { Hotel } from './model/hotel';

@Injectable({
  providedIn: 'root'
})
export class HotelService {

  private apiUrl = 'https://localhost:44390/api/hotels';
  private httpOptions = {
    headers: new HttpHeaders({'content-type': 'application/json'})
  };

  constructor(
    private http: HttpClient) { }

  getHotels() : Observable<Hotel[]>{
    return this.http.get<Hotel[]>(this.apiUrl);
  }

  getHotel(hotelId: number) : Observable<Hotel>{
    return this.http.get<Hotel>(`${this.apiUrl}/${hotelId}`);
  }

  addHotel(hotel: Hotel) : Observable<Hotel>{
    return this.http.post<Hotel>(this.apiUrl, hotel, this.httpOptions);
  }

  updateHotel(hotel: Hotel) : Observable<any>{
    const url = `${this.apiUrl}/${hotel.hotelId}`;
    return this.http.put<Hotel>(url, hotel, this.httpOptions);
  }

  deleteHotel(hotel: Hotel | number) : Observable<Hotel>{
    const id: number = typeof hotel === 'number' ? hotel : hotel.hotelId;
    const url = `${this.apiUrl}/${id}`;
    
    return this.http.delete<Hotel>(url);
  }

}
