import { AuctionService } from '../../shared/services/auction.service';
import { UserService } from 'src/app/shared/services/users.service';
import { Component, OnInit } from '@angular/core';
import { Auction } from '../../shared/models/auction';
import { User } from 'src/app/shared/models/user';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-auction-form',
  templateUrl: './auction-form.component.html',
  styleUrls: ['./auction-form.component.css']
})
export class AuctionFormComponent implements OnInit {
  auction: Auction = new Auction();
  title: string = 'Novo Leilão';
  users: User[];

  submitted = false;
  auctionForm: FormGroup;
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private auctionService: AuctionService,
    private userService: UserService,
    public fb: FormBuilder
  ) { 
    this.mainForm();
  }

  mainForm() {
    this.auctionForm = this.fb.group({
      nomeItem: ['', [Validators.required]],
      valorInicial: ['', [Validators.required]],
      dataAbertura: ['', [Validators.required]],
      dataFinalizacao: ['', [Validators.required]],
      responsavel: ['', [Validators.required]]
    })
  }

  // Getter to access form control
  get myForm(){
    return this.auctionForm.controls;
  }

  ngOnInit() {
    this.getAllUser();
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) {
      this.auctionService.getById(id).subscribe(auction => {
        console.log(auction)
        this.auction = auction;
        this.title = 'Editar Leilão';
      });
    }

  }

  getAllUser() {
    this.userService.getAll().subscribe(users => {
      this.users = users;
    });
    
  }

  toggleVisibility(e){
    /* Checkbox - se o item é usado */
    this.auction.flagUsado = e.target.checked;
  }

  onSubmit() {
    this.submitted = true;
    if (!this.auctionForm.valid) {
      return false;
    } else {
      console.log(this.auction.valorInicial)
      this.auctionService.save(this.auction).subscribe(auction => {
        console.log(auction);
        this.router.navigate(['']);
      });
    }
  }
}
