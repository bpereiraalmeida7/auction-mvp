import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Auction } from '../../shared/models/auction';
import { AuctionService } from '../../shared/services/auction.service';

@Component({
  selector: 'app-auction-list-item',
  templateUrl: './auction-list-item.component.html',
  styleUrls: ['./auction-list-item.component.css']
})
export class AuctionListItemComponent implements OnInit {
  @Input()
  auction: Auction;

  @Output()
  onDeleteAuction = new EventEmitter()
  
  constructor(private auctionService: AuctionService) { }

  ngOnInit() {
  }

  onCompletedCheckChange(auction: Auction) {
    this.auctionService.save(auction).subscribe(auction => {
      console.log(auction);
    });
  }
}
