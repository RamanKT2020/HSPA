import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
//import { IProperty } from 'src/app/model/iproperty';
import { IPropertyBase } from 'src/app/model/ipropertybase';
//import { IProperty } from '../IProperty.interface';


@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})
export class AddPropertyComponent implements OnInit {

  //@ViewChild('Form') addPropertyForm: NgForm; //used for template-driven form;
  @ViewChild('formTabs') formTabs: TabsetComponent;

  addPropertyForm: FormGroup;
  nextClicked: boolean;


  propertyTypes: Array<string> = ['House', 'Apartment', 'Duplex'];
  furnishTypes: Array<string> = ['Fully', 'Semi', 'Unfurnished'];

  propertyView: IPropertyBase = {
    Id: null,
    Name: '',
    Price: null,
    SellRent: null,
    PType: null,
    FType: null,
    BHK: null,
    BuiltArea: null,
    City: null,
    RTM: null

  };

  constructor(private fb: FormBuilder, private router : Router) { }

  ngOnInit() {
    this.createAddPropertyForm();
  }

  createAddPropertyForm() {
    this.addPropertyForm = this.fb.group({

      BasicInfo: this.fb.group({
        SellRent: [null, Validators.required],
        PType: [null, Validators.required],
        Name: [null, Validators.required]
      }),
      PriceInfo: this.fb.group({
        Price: [null, Validators.required],
        BuiltArea: [null, Validators.required]
      })

    });
  }

  // ------------------
  //  Getter methods
  //-------------------

  get BasicInfo() {
    return this.addPropertyForm.controls.BasicInfo as FormGroup;
  }
  get SellRent() {
    return this.BasicInfo.controls.SellRent as FormControl;
  }

  get BHK() {
    return this.BasicInfo.controls.BHK as FormControl;
  }

  get RTM() {
    return this.BasicInfo.controls.RTM as FormControl;
  }


  get PriceInfo() {
    return this.addPropertyForm.controls.PriceInfo as FormGroup;
  }

  get Price() {
    return this.PriceInfo.controls.Price as FormControl;
  }

  onSubmit() {
    console.log('Congrats, form submitted!');
    console.log('SellRent=' + this.addPropertyForm.value.BasicInfo.SellRent);
    console.log(this.addPropertyForm);
  }



  //  This way of referencing the Form works as well
  // onSubmit(Form: NgForm) {
  //   console.log('Congrats, form submitted!');
  //   console.log(Form);
  // }

  onBack() {
    this.router.navigate(['/']);
  }

  selectTab(tabId: number) {
    this.nextClicked = true;
    //if (IsCurrentTabValid) {
      this.formTabs.tabs[tabId].active = true;
    //}
  }
}
