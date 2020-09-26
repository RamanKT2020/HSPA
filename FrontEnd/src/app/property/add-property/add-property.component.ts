import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';


@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})
export class AddPropertyComponent implements OnInit {

  @ViewChild('Form') addPropertyForm: NgForm;
  @ViewChild('formTabs') formTabs: TabsetComponent;

  constructor(private router : Router) { }

  ngOnInit() {
  }

  onSubmit() {
    console.log('Congrats, form submitted!');
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
    this.formTabs.tabs[tabId].active = true;
  }
}
