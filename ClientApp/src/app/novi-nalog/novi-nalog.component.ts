import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { PutniNalog } from '../Models/PutniNalog';
import { Putnik } from '../Models/Putnik';
import { Automobil } from '../Models/Automobil';
import { Trosak } from '../Models/Trosak';
import { PutniNaloziController } from '../Controllers/PutniNaloziController';

@Component({
  selector: 'app-novi-nalog',
  templateUrl: './novi-nalog.component.html',
})
export class NoviNalogComponent{
  controller: PutniNaloziController;
  now = new Date(2021, 2, 17);
  baseUrl: string;
  odabraniTipPrijevoza: string;
  selectedAuto: string;
  IsHidden_AutoControl: boolean = false;
  IsAuto_Selected: boolean = false;
 
  putnik: Putnik[] = [{
    id: '0',
    ime: 'Pero',
    prezime: 'Perić',
  }]
  trosak: Trosak[] = [{
    opis: '',
    iznos: 0
  }]

  nalog: PutniNalog;
  redniBrojNalog: number;
  polazak: Date;
  povratak: Date;
  razlogPutovanja: string;
  putnici: Putnik[];
  polaziste: string;
  odrediste: string;
  prijevoz: string;
  automobil: Automobil = {
    id: '0',
    marka: 'Audi',
    naziv: 'A4',
    kilometraza: 10456,
    registracijskaOznaka: 'RI1234RI'
  }
  automobili: Automobil[] = [{
    id: '0',
    marka: 'Audi',
    naziv: 'A4',
    kilometraza: 10456,
    registracijskaOznaka: 'RI1234RI'}];
  komentar: string;
  emailZaOdobrenje: string;
  pocetnaKilometraza: number;
  zavrsnaKilometraza: number;
  troskovi: Trosak[];
  isLocked: boolean = false;

  IzradiNalog() {
    this.nalog = new PutniNalog();
    this.nalog.redniBrojNalog = this.redniBrojNalog;
    this.nalog.polazak = this.polazak;
    this.nalog.povratak = this.povratak;
    this.nalog.razlogPutovanja = this.razlogPutovanja;
    this.nalog.putnici = this.putnik;
    this.nalog.polaziste = this.polaziste;
    this.nalog.odrediste = this.odrediste;
    this.nalog.prijevoz = this.odabraniTipPrijevoza;
    this.nalog.automobil = this.automobil;
    this.nalog.komentar = this.komentar;
    this.nalog.emailZaOdobrenje = this.emailZaOdobrenje;
    this.nalog.pocetnaKilometraza = this.pocetnaKilometraza;
    this.nalog.zavrsnaKilometraza = this.zavrsnaKilometraza;
    this.nalog.troskovi = this.trosak;
    this.nalog.isLocked = this.isLocked;
  }


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

    //http.get<Automobil[]>(baseUrl + 'api/PutniNalozi/Automobili').subscribe(result => {
    //  this.automobili = result;
    //  console.log(result);
    //}, error => console.error(error));
  }

  onTipPrijevozaChange() {
    if (this.odabraniTipPrijevoza == 'Javni prijevoz') {
      this.IsHidden_AutoControl = false;
    } else {
      this.IsHidden_AutoControl = true;
    }
  }

  GetAutoById(id) {
    this.http.get<Automobil>(this.baseUrl + 'api/PutniNalozi/Automobili/Details/' + id).subscribe(result => {
      //this.automobil = result;
      this.pocetnaKilometraza = this.automobil.kilometraza;
      this.zavrsnaKilometraza = this.automobil.kilometraza;
      console.log(result);
    }, error => console.error(error));
  }
  onAutoSelectChange() {
    if (this.selectedAuto != 'Odaberite automobil:') {
      this.IsAuto_Selected = true;
      this.GetAutoById(this.automobili.find(e => (e.marka + ' ' + e.naziv) === this.selectedAuto).id);
    }
    else this.IsAuto_Selected = false;
  }

  onSubmit(form: NgForm) {

    this.IzradiNalog();

    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = { headers: headers };

    const body = JSON.stringify(this.nalog);
    this.http.post(this.baseUrl + 'api/PutniNalozi/Insert', body, options).subscribe(result => {
      console.log(result);
    }, error => console.error(error));;
  }


  

 
}




