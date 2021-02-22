import { HttpClient } from '@angular/common/http';
import { PutniNalog } from '../Models/PutniNalog';
import { Putnik } from '../Models/Putnik';
import { Automobil } from '../Models/Automobil';
import { Trosak } from '../Models/Trosak';

export class PutniNaloziController {
  baseUrl: string;

  constructor(private http: HttpClient, baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  GetAllAutomobili() {
    return this.http.get<Automobil[]>(this.baseUrl + 'api/PutniNalozi/Automobili');
  }

  GetAutoById(id) {
    this.http.get<Automobil>(this.baseUrl + 'api/PutniNalozi/Automobili/Details/' + id).subscribe(result => {
      return result;
    }, error => console.error(error));
  }
}
