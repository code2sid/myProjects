import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{AppCompenent} from './app.component';

@NgModule({
imports:[BrowserModule],//builtin or custom module list
declarations:[AppCompenent],
exports:[],
providers:[],
bootstrap:[AppCompenent]

})
export class AppModule{
    
}