import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Country } from '../../models/country';
import { Province } from '../../models/province';
import { User } from '../../models/user';
import { CountryProvinceService } from '../../services/country-province.service';
import { UserService } from '../../services/user.service';
import CustomValidators from '../custom.validation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  title = 'Angular Application';
  isLinear = true;
  step1FormGroup: FormGroup;
  step2FormGroup: FormGroup;
  errors = errorMessages;
  countries: Country[] = [];
  provinces: Province[] = [];
  user = new User();
  userSavedSuccess: boolean | null;

  constructor(
    private formBuilder: FormBuilder,
    private countryProvinceService: CountryProvinceService,
    private userService: UserService,
    private snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.step1FormGroup = this.formBuilder.group({
      login: ['', Validators.required],
      passwordGroup: this.formBuilder.group({
        password: ['', [
          Validators.required,
          Validators.pattern(regExps['password'])
        ]],
        confirmPassword: ['', Validators.required]
      }, { validator: CustomValidators.match('password', 'confirmPassword') }),
      agree: [false, Validators.required]
    });

    this.step2FormGroup = this.formBuilder.group({
      country: ['', Validators.required],
      province: ['', Validators.required]
    });

    this.getCountries();
  }

  submit() {
    this.userService.addUser(this.user).subscribe(b => this.openSnackBar(b ? 'Success' : 'Fail', 'Close'));
  }

  getCountries() {
    this.countryProvinceService.getCountries().subscribe(countries => this.countries = countries);
  }

  changeCountry(country: Country) {
    this.step2FormGroup.get('province')!.reset();
    this.provinces = country.provinces;
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action);
  }
}

export const regExps: { [key: string]: RegExp } = {
  password: /(?=.*[A-Z])(?=.*[0-9]).*$/
};

export const errorMessages: { [key: string]: string } = {
  email: 'Login must be a valid email',
  password: 'Password must contain min 1 digit and min 1 uppercase letter',
  confirmPassword: 'Confirm password must be the same with password',
  country: 'Country is a required field',
  province: 'Province is a required field'
};
