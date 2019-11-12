import { Component, OnInit, Input } from '@angular/core';
import { Part } from '../_models/part';
import { Package } from '../_models/Package';

@Component({
  selector: '[part]',
  templateUrl: './parts-list-item.component.html',
  styleUrls: ['./parts-list-item.component.css']
})
export class PartsListItemComponent implements OnInit {

  @Input() model: Part;
  @Input() packages: Package[];

  getPackageName(packageId: number): string {
    if (this.packages && this.packages.find(p => p.id == packageId))
      return this.packages.find(p => p.id == packageId).name;
  }

  constructor() { }

  ngOnInit() {
  }

}
