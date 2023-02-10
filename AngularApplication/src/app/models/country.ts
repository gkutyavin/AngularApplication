import { Province } from "./province";

export interface Country {
  id: number;
  name: string;
  provinces: Province[];
} 
