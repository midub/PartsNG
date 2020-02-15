import { Component, OnInit, Input } from '@angular/core';
import { Part } from '../_models/part';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { PartsService } from '../_services/parts.service';
import { Router } from '@angular/router';
import { Property } from '../_models/Property';
import { Package } from '../_models/Package';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { NoWhitespaceValidator } from '../_validators/no-whitespace.validator';
import { PropertiesService } from '../_services/properties.service';

@Component({
  selector: 'app-create-part-form',
  templateUrl: './create-part-form.component.html',
  styleUrls: ['./create-part-form.component.css']
})
export class CreatePartFormComponent implements OnInit {
  @Input()
  parts: Part[]
  @Input()
  properties: Property[]
  @Input()
  packages: Package[]

  private submitted;
  private loading;
  private created;

  form: FormGroup;
  get f() { return this.form.controls; }
  get partPropertiesFormGroup() {
    return this.form.get('partProperties') as FormArray;
  }

  partPropertiesList: FormArray;

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder, private partsService: PartsService, private propertiesService: PropertiesService, private router: Router) { }

  ngOnInit() {
    this.submitted = false;
    this.loading = false;
    this.form = this.formBuilder.group({
      name: ['', Validators.compose([Validators.required, NoWhitespaceValidator()])],
      count: [null, Validators.compose([Validators.required, Validators.min(0)])],
      packageId: [null],
      buyLink: ['', Validators.compose([NoWhitespaceValidator()])],
      position: ['', Validators.compose([NoWhitespaceValidator()])],
      partProperties: this.formBuilder.array([this.createPartProperty()]),
      newProperty: ['']
    });

    this.partPropertiesList = this.form.get('partProperties') as FormArray;
  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', centered: true, size: 'lg', scrollable: true }).result.then((result) => {
      this.created = false;
    }, (reason) => {

    });
  }

  create(modal: any) {
    this.submitted = true;
    if (this.form.invalid)
      return;

    this.loading = true;
    var data = this.form.value;

    this.partsService.postPart(data as Part).subscribe(
      result => {
        this.parts.push(result);
        this.created = true;
      },
      error => {
        console.log(error);
        this.created = false;
      }
    );

    this.ngOnInit();
  }

  cancel(modal: any) {
    modal.close('Created');
    this.ngOnInit();
  }

  createPartProperty(): FormGroup {
    return this.formBuilder.group({
      partId: [0],
      propertyId: [0, Validators.compose([Validators.required, Validators.min(1)])],
      value: [null, Validators.compose([Validators.required])]
    })
  }

  addPartProperty() {
    this.partPropertiesList.push(this.createPartProperty());
  }

  removePartProperty(i: number) {
    this.partPropertiesList.removeAt(i);
  }

  getPartPropertyFormGroup(index: string | number): FormGroup {
    this.partPropertiesList = this.form.get('partProperties') as FormArray;
    const formGroup = this.partPropertiesList.controls[index] as FormGroup;
    return formGroup;
  }

  addNewProperty() {
    var property = new Property();
    property.name = this.form.value.newProperty;
    console.log(this.form.value);
    this.propertiesService.postProperty(property).subscribe(
      result => {
        this.properties.push(result);
      },
      error => {
        console.log(error);
      }
    );
  }
}
