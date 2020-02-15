import { Component, OnInit } from '@angular/core';
import { PartsService } from '../_services/parts.service';
import { Part } from '../_models/part';
import { Property } from '../_models/property';
import { PropertiesService } from '../_services/properties.service';
import { Package } from '../_models/Package';
import { PackagesService } from '../_services/packages.service';

@Component({
  selector: 'app-parts',
  templateUrl: './parts.component.html',
  styleUrls: ['./parts.component.css']
})
export class PartsComponent implements OnInit {
  private parts: Part[];
  private properties: Property[];
  private packages: Package[];

  
  page = 1;
  pageSize = 15;
  collectionSize;

  get partList(): Part[] {
    return this.parts.slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  constructor(private partsService: PartsService, private propertiesService: PropertiesService, private packagesService: PackagesService) { }

  ngOnInit() {
    this.propertiesService.getProperties().subscribe(
      result => {
        this.properties = result;
      },
      error => console.log(error));
    this.packagesService.getPackages().subscribe(
      result => {
        this.packages = result;
      },
      error => console.log(error));
    this.partsService.getParts().subscribe(
      result => {
        this.parts = result;
        this.collectionSize = this.parts.length;
      },
      error => console.error(error));
  }

}
