import { Part } from "./part";
import { User } from "oidc-client";

export class Order {
  id: number;
  part: Part;
  count: number;
  user: User;
}
