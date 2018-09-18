import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchEmployeeComponent } from '../fetchemployee/fetchemployee.component';
import { EmployeeService } from '../services/empservice.service';

@Component({
  templateUrl: './AddEmployee.component.html'
})

export class CreateEmployee implements OnInit {
  employeeForm: FormGroup;
  title: string = "Create";
  id: number;
  errorMessage: any;
  departmentList: Array<any> = [];
  public emp: EmployeeService[];


  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _employeeService: EmployeeService, private _router: Router) {
    if (this._avRoute.snapshot.params["id"]) {
      this.id = this._avRoute.snapshot.params["id"];
    }

    this.employeeForm = this._fb.group({
      id: 0,
      name: ['', [Validators.required]],
      surname: ['', [Validators.required]],
      address: ['', [Validators.required]],
      qualification: ['', [Validators.required]],
      contactNumber: ['', [Validators.required]],
      departmentId: ['', [Validators.required]]
    })
  }

  ngOnInit() {

    this._employeeService.getDepartmentList().subscribe(
      data => this.departmentList = data
    )

    if (this.id > 0) {
      this.title = "Edit";
      this._employeeService.getEmployeeById(this.id)
        .subscribe(resp => this.employeeForm.setValue(resp)
          , error => this.errorMessage = error);
    }

  }

  save() {

    if (!this.employeeForm.valid) {
      return;
    }

    if (this.title == "Create") {
      this._employeeService.saveEmployee(this.employeeForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-employee']);
        }, error => this.errorMessage = error)
    }
    else if (this.title == "Edit") {
      this._employeeService.updateEmployee(this.employeeForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-employee']);
        }, error => this.errorMessage = error)
    }
  }

  cancel() {
    this._router.navigate(['/fetch-employee']);
  }

  get name() { return this.employeeForm.get('name'); }
  get surname() { return this.employeeForm.get('surname'); }
  get address() { return this.employeeForm.get('address'); }
  get qualification() { return this.employeeForm.get('qualification'); }
  get contactNumber() { return this.employeeForm.get('contactNumber'); }
  get departmentId() { return this.employeeForm.get('departmentId'); }
}
interface DepartmentData {
  departmentid: number;
  departmentName: string;
} 
