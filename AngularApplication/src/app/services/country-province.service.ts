import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delayWhen, Observable, retryWhen, shareReplay, tap, timer } from 'rxjs';
import { Country } from '../models/country';

@Injectable({
  providedIn: 'root'
})
export class CountryProvinceService {

  private countriesUrl = '/api/countries';

  constructor(private http: HttpClient) { }

  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.countriesUrl).pipe(
      shareReplay(),
      retryWhen(errors => {
        return errors
          .pipe(
            delayWhen(() => timer(1000)),
            tap(() => console.log('retrying...'))
          );
      })
    );
  }
}
