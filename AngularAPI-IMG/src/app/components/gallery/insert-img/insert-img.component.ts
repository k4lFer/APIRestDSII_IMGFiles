import { Component, inject } from '@angular/core';
import { FormBuilder,FormGroup,FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpService } from '../../../http.service';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button'; 
import { MatFormFieldControl, MatFormFieldModule } from '@angular/material/form-field';
import { NgIf } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSnackBarModule } from '@angular/material/snack-bar';


@Component({
  selector: 'app-insert-img',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, MatInputModule, MatButtonModule, MatFormFieldModule ,ReactiveFormsModule, NgIf, MatSnackBarModule],
  templateUrl: './insert-img.component.html',
  styleUrl: './insert-img.component.css'
})
export class InsertImgComponent {
  galleryForm: FormGroup;
  upFiles: File | null = null;


  constructor(private formBuilder: FormBuilder, private httpService: HttpService, private _snackBar: MatSnackBar) {
     this.galleryForm = this.formBuilder.group({
      // upFiles: [null],
      description: ['', Validators.required]
       
     });
  }

  onFileChange(event: any) {
    if (event.target.files && event.target.files.length > 0) {
      this.upFiles = event.target.files[0]; 
    }
    
 }
   
 /* onSubmit() {
    const formData = new FormData();
    const file = this.galleryForm.get('upFiles')!.value;
    if (file && file instanceof File) { // Asegúrate de que 'file' es un objeto File
       formData.append('dtoGallery.ImageFile', file, file.name);
       formData.append('dtoGallery.description', this.galleryForm.get('description')!.value);
   
       this.httpService.insertGallery(formData).subscribe(
         () => {
           console.log("Éxito");
         },
         (error) => {
           console.error("Error al enviar la solicitud:", error);
         }
       );
    } else {
       console.error("No se seleccionó ningún archivo o el valor no es un objeto File.");
    }
   }  */


/*   onSubmit() {
    if (!this.upFiles) {
      console.error("No se seleccionó ningún archivo.");
      return;
    }

    const galleryData = new FormData();
    galleryData.append('dtoGallery.files', this.upFiles, this.upFiles.name);
    galleryData.append('dtoGallery.description', this.galleryForm.get('description')!.value);

    this.httpService.insertGallery(galleryData).subscribe(
      {
        next:response => {
          console.log("Enviado:", response)
          const messages = response.mo.listMessage;
          const messageType = response.mo.type;

          // Muestra los mensajes en un alerta
          messages.forEach((message: any) => {
            alert(`${messageType}: ${message}`);
          });
        },
          error: error =>{
            console.error("Error al enviar la solicitud:", error);
            alert("Error al enviar la solicitud: " + error.message);
          }
  
        });
        
      }
      */


      onSubmit() {
        if (!this.upFiles) {
           console.error("No se seleccionó ningún archivo.");
           this._snackBar.open(`Error: No se seleccionó ningún archivo`, 'Cerrar', {
            duration: 5000, 
            horizontalPosition: 'center',
            verticalPosition: 'top',
          });
           return;
        }
       
        const galleryData = new FormData();
        galleryData.append('dtoGallery.files', this.upFiles, this.upFiles.name);
        galleryData.append('dtoGallery.description', this.galleryForm.get('description')!.value);
       
        this.httpService.insertGallery(galleryData).subscribe({
           next: response => {
             console.log("Enviado:", response);
             const messages = response.mo.listMessage;
             const messageType = response.mo.type;
       
             messages.forEach((message: any) => {
               this._snackBar.open(`${messageType}: ${message}`, 'Cerrar', {
                 duration: 5000, 
                 horizontalPosition: 'center',
                 verticalPosition: 'top',
               });
             });
           },
           error: error => {
             console.error("Error al enviar la solicitud:", error);
             this._snackBar.open("Error al enviar la solicitud: " + error.message, 'Cerrar', {
               duration: 5000,
               horizontalPosition: 'center',
               verticalPosition: 'bottom',
             });
           }
        });
       }
       
}




   

