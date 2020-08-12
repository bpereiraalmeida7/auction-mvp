import { AuctionService } from './../../shared/services/auction.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Auction } from '../../shared/models/auction';

@Component({
  selector: 'app-auction-list',
  templateUrl: './auction-list.component.html',
  styleUrls: ['./auction-list.component.css']
})
export class AuctionListComponent implements OnInit {
  auction: Auction[] = [];
  dtOptions: DataTables.Settings = {};

  constructor(private auctionService: AuctionService) { }

  ngOnInit() {

    this.dtOptions = {
      pagingType: 'full_numbers',
      responsive: true,
      language: {
        processing: "Procesando...",
        search: "Buscar:",
        lengthMenu: "Mostrar _MENU_ elementos",
        info: "Mostrando de _START_ a _END_ de _TOTAL_ elementos",
        infoEmpty: "Mostrando nenhum elemento.",
        infoFiltered: "(filtrado _MAX_ elementos total)",
        infoPostFix: "",
        loadingRecords: "Carregando registros...",
        zeroRecords: "Nenhum registro encontrado.",
        emptyTable: "Não há dados disponiveis na tabela",
        paginate: {
          first: "Primero",
          previous: "Anterior",
          next: "Seguinte",
          last: "Último"
        },
        aria: {
          sortAscending: ": Ativar para ordenar a tabela em ordem ascendente",
          sortDescending: ": Ativar para ordenar a tabela em ordem descendente"
        }
      }
    };

    this.getAuction();
  }

  getAuction(){
    this.auctionService.getAll().subscribe(auction => { 
      this.auction = auction;
      console.log(this.auction)
    });
  }

  remove(auction) {
    this.auctionService.delete(auction.id).subscribe(() => {
      this.getAuction();
    });
  }
}
