import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './favoritos.component.html'
})
export class FavoritosComponent {
  livros: livro[] = [];
  sucess = false;
  erro = false;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string) 
  {
    this.ObterLivros();
  }
  
  ObterLivros(){
    this.http.get<livro[]>(this.baseUrl + 'api/Livro/ListaLivrosFavoritos').subscribe(result => {
      this.livros = result;
    }, 
    error => {
      this.erro = true;
      setTimeout(() => {  this.erro = false; }, 5000);
    });}

  onClickButton(id){
    this.http.delete(this.baseUrl + 'api/Livro/' + id).subscribe(result => {
      this.sucess = true;
      this.ObterLivros();
      setTimeout(() => {  this.sucess = false; }, 4000);
    }, error => {
      this.erro = true;
      setTimeout(() => {  this.erro = false; }, 5000);
    });}  
}

interface livro {
  id : string;
  titulo : string;
  descricao : string;
  categorias : string[];
  etag : string;
  autores : string[];
  capaLivro : string;
}