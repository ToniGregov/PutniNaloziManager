import { Putnik } from './Putnik';
import { Automobil } from './Automobil';
import { Trosak } from './Trosak';

export class PutniNalog {
  redniBrojNalog: number;
  polazak: Date;
  povratak: Date;
  razlogPutovanja: string;
  putnici: Putnik[];
  polaziste: string;
  odrediste: string;
  prijevoz: string;
  automobil: Automobil;
  komentar: string;
  emailZaOdobrenje: string;
  pocetnaKilometraza: number;
  zavrsnaKilometraza: number;
  troskovi: Trosak[];
  isLocked: boolean;
}
