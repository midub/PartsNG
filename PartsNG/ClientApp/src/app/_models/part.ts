import { PartProperty } from "./part-Property";
import { Property } from "./Property";

export class Part {
  id: number;
  name: string;
  count: number;
  Property: Property;
  buyLink: string;
  position: string;
  partProperties: PartProperty;
}
