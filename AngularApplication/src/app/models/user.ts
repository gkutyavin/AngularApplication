import { Country } from "./country";
import { Province } from "./province";

export class User {
  login: string;
  password: string;
  passwordConfirm: string;
  agree: boolean;
  country: Country;
  province: Province;
} 
