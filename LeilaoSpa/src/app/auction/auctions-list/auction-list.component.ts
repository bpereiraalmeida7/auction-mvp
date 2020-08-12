import { AuctionService } from './../../shared/services/auction.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Auction } from '../../shared/models/auction';
import { UserService } from 'src/app/shared/services/users.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-auction-list',
  templateUrl: './auction-list.component.html',
  styleUrls: ['./auction-list.component.css']
})
export class AuctionListComponent implements OnInit {
  auction: Auction[];
  users: any = [];

  dtOptions: DataTables.Settings = {};
  now = new Date;

  constructor(private auctionService: AuctionService, private userService: UserService, private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.getAllUser();
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

  getAllUser() {
    this.userService.getAll().subscribe(users => {
      this.users = users;
    });
  }

  getAuction(){
    this.auctionService.getAll().subscribe(auction => { 
      this.convertDate(auction);
    });
  }

  convertDate(data){
    data.forEach(element => {
      let date = new Date(element.dataFinalizacao);
      let timestamp = date.getTime();
      element.dataFinalFormat = timestamp;
    });
    this.setName(data);
  }

  setName(data) {
    data.forEach(element => {
      var user = this.users.filter(e => {
        return e.Id = element.responsavel;
      });
      element.responsavelName = user[0].nome;
    });
    this.auction = data;
  }

  remove(auction) {
    this.auctionService.delete(auction.id).subscribe(() => {
      this.getAuction();
    });
  }
}
