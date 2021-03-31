import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  async login(model: any) {
    return await this.httpClient.post<any>(
      environment.apiUrlPath,
      model).toPromise();
  }

}
