import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Package } from '../_models/Package';
import { Part } from '../_models/part';
import { Property } from '../_models/Property';
import { PartsService } from '../_services/parts.service';
import { PropertiesService } from '../_services/properties.service';
import { NoWhitespaceValidator } from '../_validators/no-whitespace.validator';

@Component({
  selector: 'app-edit-part-form',
  templateUrl: './edit-part-form.component.html',
  styleUrls: ['./edit-part-form.component.css']
})
export class EditPartFormComponent implements OnInit {

  @Input() part: Part
  @Input() parts: Part[]
  @Input() properties: Property[]
  @Input() packages: Package[]

  private submitted;
  private loading;
  private edited;

  form: FormGroup;
  get f() { return this.form.controls; }
  get partPropertiesFormGroup() {
    return this.form.get('partProperties') as FormArray;
  }

  partPropertiesList: FormArray;

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder, private partsService: PartsService, private propertiesService: PropertiesService, private router: Router) { }

  ngOnInit() {
    this.submitted = false;
    this.loading = true;

    this.form = this.formBuilder.group({
      name: [this.part.name, Validators.compose([Validators.required, NoWhitespaceValidator()])],
      count: [this.part.count, Validators.compose([Validators.required, Validators.min(0)])],
      packageId: [this.part.packageId],
      buyLink: [this.part.buyLink, Validators.compose([NoWhitespaceValidator()])],
      position: [this.part.position, Validators.compose([NoWhitespaceValidator()])],
      partProperties: this.formBuilder.array([this.createPartProperty()]),
      newProperty: ['']
    });

    this.partPropertiesList = this.form.get("partProperties") as FormArray;

    this.removePartProperty(0);

    if(this.part.partProperties)
      this.part.partProperties.forEach(pp => this.addPartProperty(this.createPartProperty(pp.propertyId, pp.value)));
    this.loading = false;
  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: "modal-basic-title", centered: true, size: "lg", scrollable: true }).result.then((result) => {
      this.edited = false;
    }, (reason) => {

    });
  }

  edit(modal: any) {
    this.submitted = true;
    if (this.form.invalid)
      return;

    this.loading = true;
    var data = this.form.value;
    data.id = this.part.id;
    data.packageId = +data.packageId;
    data.partProperties.forEach(pp => pp.propertyId = +pp.propertyId);

    this.partsService.putPart(data as Part).subscribe(
      result => {
        this.part = data;
        this.parts[this.parts.findIndex(p => p.id == this.part.id)] = this.part;
        this.edited = true;
      },
      error => {
        console.log(error);
        this.edited = false;
      }
    );

  }

  cancel(modal: any) {
    modal.close('Edited');
    this.ngOnInit();
  }

  createPartProperty(propertyId: number = 0, value: string = null): FormGroup {
    return this.formBuilder.group({
      partId: [this.part.id],
      propertyId: [propertyId, Validators.compose([Validators.required, Validators.min(1)])],
      value: [value, Validators.compose([Validators.required])]
    })
  }

  addPartProperty(formGroup: FormGroup = null) {
    if (formGroup == null)
      formGroup = this.createPartProperty();
    this.partPropertiesList.push(formGroup);
  }

  removePartProperty(i: number) {
    this.partPropertiesList.removeAt(i);
  }

  getPartPropertyFormGroup(index: string | number): FormGroup {
    this.partPropertiesList = this.form.get("partProperties") as FormArray;
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
