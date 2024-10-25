import { Component, Inject, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-hero',
  templateUrl: './add-hero.component.html',
})
export class AddHeroComponent {
  form: FormGroup;
  isSuccess = false;
  isFormSubmitted = false;

  http = inject(HttpClient);
  baseUrl: string = '';
  public brands: Brand[] = [];


  constructor(@Inject('BASE_URL') baseUrl: string, private fb: FormBuilder, private router: Router) {
    this.baseUrl = baseUrl;

    this.http.get<Brand[]>(`${this.baseUrl}api/brands/getall`).subscribe(result => {
      console.log(result)
      this.brands = result;
    }, error => console.error(error));

    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      alias: ['', [Validators.required, Validators.minLength(2)]]
    });
  }

  onSubmit() {
    this.isFormSubmitted = true;
    if (this.form.valid) {
      const hero: Hero = this.form.value;
      const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      this.http
        .post<Hero>(`${this.baseUrl}api/heroes/add`, hero, { headers })
        .subscribe(
          (result) => {
            this.isSuccess = true;
            this.form.reset();
            this.isFormSubmitted = false;
            this.router.navigate(['/']);
          },
          (error) => {
            this.isSuccess = false;
          }
        );
    }
  }

  getErrorMessage(controlName: string): string | null {
    const control = this.form.get(controlName);
    if (
      control &&
      control.invalid &&
      (this.isFormSubmitted || control.touched || control.dirty)
    ) {
      if (control.hasError('required')) {
        return `${
          controlName.charAt(0).toUpperCase() + controlName.slice(1)
        } field is required`;
      }
      if (control.hasError('minlength')) {
        return 'Minimum length is two characters';
      }
    }
    return null;
  }

  get name() {
    return this.form.get('name');
  }
}

interface Hero {
  Id: number;
  Name: string;
  Alias: string;
  BrandName: string;
  IsActive: boolean;
}

interface Brand{
  Id: number;
  Name: string;
}
