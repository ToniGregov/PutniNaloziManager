import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PutniNalog } from '../Models/PutniNalog';
import { Putnik } from '../Models/Putnik';
import { Automobil } from '../Models/Automobil';
import { Trosak } from '../Models/Trosak';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public nalozi: PutniNalog[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<PutniNalog[]>(baseUrl + 'api/PutniNalozi').subscribe(result => {
      this.nalozi = result;
      console.log(result);
    }, error => console.error(error));
  }
}

