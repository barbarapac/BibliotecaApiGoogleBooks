import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { setTimeout } from 'timers';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  livro: livros[] = undefined;
  livroBusca: string = '';
  erro = false;
  sucess = false;
  warning = false;
  invalid = false;
  favoritado = false;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string
    ){ 
  }

  PesquisarLivro(cepBusca : string) {
    this.http.get<livros[]>(this.baseUrl + 'api/Livros/BuscaLivro/' + cepBusca).subscribe(result => {
      
      if (result){
        this.livro = result;
      } else{
        this.warning = true;
        setTimeout(() => {  this.warning = false; }, 4000);
      }

    }, error => {
      this.erro = true;
      setTimeout(() => {  this.erro = false; }, 5000);
    });
  }

  onClickButton(livro){
    this.http.post(this.baseUrl + 'api/Livros/', livro).subscribe(result => {
      livro.favorito = true;
      this.livro = undefined;
      this.livroBusca = '';

      this.sucess = true;
      setTimeout(() => {  this.sucess = false; }, 4000);
    }, error => {
      if (error.error == ""){
        this.erro = true;
        setTimeout(() => {  this.erro = false; }, 5000);
      } else {
        this.favoritado = true;
        setTimeout(() => {  this.favoritado = false; }, 5000);
      }

    });
  }
}

interface livros {
  id : string;
  titulo : string;
  descricao : string;
  categorias : string[];
  etag : string;
  autores : string[];
  capaLivro : string;
}
