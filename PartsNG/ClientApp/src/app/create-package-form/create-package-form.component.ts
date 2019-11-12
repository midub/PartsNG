import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { Package } from '../_models/Package';
import { PackagesService } from '../_services/packages.service';
import { PartType } from '../_models/part-type.enum';

@Component({
  selector: 'app-create-package-form',
  templateUrl: './create-package-form.component.html',
  styleUrls: ['./create-package-form.component.css']
})
export class CreatePackageFormComponent implements OnInit {
  @Input()
  packages: Package[];

  private submitted;
  private loading;

  form: FormGroup;
  get f() { return this.form.controls; }

  PartTypes = Object.keys(PartType).filter(value => isNaN(+value[0]));

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder, private packagesService: PackagesService, private router: Router) { }

  ngOnInit() {
    this.submitted = false;
    this.loading = false;
    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      partType: [null, Validators.compose([Validators.required])]
    });
  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', centered: true, size: 'sm', scrollable: true }).result.then((result) => {

    }, (reason) => {

    });
  }

  create(modal: any) {
    this.submitted = true;
    if (this.form.invalid)
      return;

    this.loading = true;
    var data = this.form.value;

    this.packagesService.postPackage(data as Package).subscribe(
      result => {
        modal.close('Created');
        this.packages.push(result);
      },
      error => {
        console.log(error);
      }
    );
    this.ngOnInit();
  }
}
