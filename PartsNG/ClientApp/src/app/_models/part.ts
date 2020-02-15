import { PartProperty } from "./part-Property";
import { Property } from "./Property";
import { Package } from "./Package";

export class Part {
  id: number;
  name: string;
  count: number;
  packageId: number;
  package: Package;
  propertyId: number;
  property: Property;
  buyLink: string;
  position: string;
  partProperties: PartProperty[];
}
