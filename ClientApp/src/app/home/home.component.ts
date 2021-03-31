import { Component, OnInit } from '@angular/core';
import { allowedNodeEnvironmentFlags } from 'process';
import jwt_decode from "jwt-decode";
import { AuthService } from 'src/service/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  account: string = '';
  password: string = '';

  constructor(private authService: AuthService) { }

  ngOnInit(): void {

  }

  async btnClick() {
    let result = await this.authService.login({ "Account": this.account, "Password": this.password });

    let token = result.result;
    let aaa = jwt_decode(token);
    debugger
    alert('你的帳號 : ' + aaa.name);
  }
}

