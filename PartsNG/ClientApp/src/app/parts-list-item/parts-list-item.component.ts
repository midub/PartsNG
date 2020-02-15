import { Component, OnInit, Input } from '@angular/core';
import { Part } from '../_models/part';
import { Package } from '../_models/Package';
import { Property } from '../_models/Property';

@Component({
  selector: '[partListItem]',
  templateUrl: './parts-list-item.component.html',
  styleUrls: ['./parts-list-item.component.css']
})
export class PartsListItemComponent implements OnInit {

  @Input() model: Part;
  @Input() parts: Part[];
  @Input() packages: Package[];
  @Input() properties: Property[];

  getPackageName(): string {
    if (this.packages && this.packages.find(p => p.id == this.model.packageId))
      return this.packages.find(p => p.id == this.model.packageId).name;
  }

  constructor() { }

  ngOnInit() {
  }

}
