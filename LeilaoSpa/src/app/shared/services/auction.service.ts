import { environment } from '../../../environments/environment';
import { Auction } from '../models/auction';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Auction[]>(`${environment.api}/api/itensLeilao`);
  }

  getById(id: string) {
    return this.http.get<Auction>(`${environment.api}/api/itensLeilao/${id}`);
  }

  save(auction: Auction) {
    if (auction.id) {
      return this.http.put<Auction>(`${environment.api}/api/itensLeilao/${auction.id}`, auction);
    } else {
      return this.http.post<Auction>(`${environment.api}/api/itensLeilao`, auction);
    }
  }

  delete(id: number) {
    return this.http.delete(`${environment.api}/api/itensLeilao/${id}`);
  }
}
