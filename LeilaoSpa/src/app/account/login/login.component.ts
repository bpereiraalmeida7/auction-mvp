import { Router } from '@angular/router';
import { AccountService } from '../../shared/services/account.service';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login = {
    Usuario: '',
    Senha: ''
  };

  error: '';

  constructor(
    private accountService: AccountService,
    private router: Router,
    private spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.spinner.show();
    window.localStorage.removeItem("token");
  }

  async onSubmit() {
    try {
      const result = await this.accountService.login(this.login);
      console.log(`Login efetuado: ${result}`);

      // navego para a rota vazia novamente
      this.router.navigate(['']);
      this.spinnerTimeout();
    } catch (error) {
      this.error = error;
      this.spinnerTimeout();
    }
  }

  spinnerTimeout() {
    setTimeout(() => {
      /** spinner ends after 3 seconds */
      this.spinner.hide();
    }, 1000);
  }
}
