<img src="https://user-images.githubusercontent.com/11803107/79746139-e20c5b80-82df-11ea-8039-21680c5b9e35.jpg" width="220" height="60">

# Poke App

Poke App é um aplicativo desenvolvido em Xamarin Forms e Prism. O principal objetivo aqui, era utilizar a PokéApi e realizar algumas funcionalidades específicas, tais como:



*  Consumir PokéApi
*  Listar Pokemon
*  Aplicar filtro por tipos de pokemon
*  Realizar paginação dos dados
*  Exibir dados do pokemons em uma popup
*  Construir uma galeria de imagens

## Desenvolvimento
Durante o desenvolvimento, foram utilizadas algumas bibliotecas para que o mesmo fosse mais produtivo. Irei listar abaixo cada uma delas e justificar o seu uso.

* Flurl - O Flurl é um construtor de URLs modernos e fluentes, assíncronos, testáveis, portáteis, carregados de buzzword e uma biblioteca cliente HTTP para .NET. Tal ferramenta foi utilizada por prover uma maneira mais fácil e intuitiva de consumir apis, que após ter seu endpoint definido ela passar a ser uma extension da classe String.

* Prism - Framework MVVM que permite uma separação dos conceitos de UI e seu comportamento. Foi utilizado por fornecer um grande ganho de produtividade como por exemplo passagem de parâmentros para as ViewModels através dos métodos OnNavigatedTo e OnNavigatedFrom ou o uso do EventAggregator onde é permitido trabalhar com Pub e Sub.
Também trabalha com injeção de dependência onde podemos registrar nossos services por exemplo, caso queiramos trabalhar com um design pattern.

* CardsView - Plugin que nos possibilta trabalhar com o esquema de cards, o mesmo possui vários tipos de controles para o card em si e é de fácil implementação.

* Lottie - Plugin desenvolvido pela conhecida Airbnb, onde o mesmo nos possibilita utilizar animações em nossas aplicações, dando mais vida aos nossos apps.

* Rg.Plugins.Popup - Como o próprio nome sugere, ele nos permite trabalhar com Popups em nossa aplicação.

* Xamarin Essentials - O Xamarin.Essentials fornece desenvolvedores com APIs de plataforma cruzada para seus aplicativos móveis.
O Android, iOS e UWP oferecem APIs de plataforma e sistema operacional exclusivos nos quais os desenvolvedores podem acessar tudo que estiver no C# aproveitando o Xamarin. O Xamarin.Essentials oferece uma API única entre plataformas que funciona com qualquer aplicativo Xamarin.Forms, Android, iOS ou UWP e que pode ser acessado no código compartilhado, independentemente da forma como a interface do usuário é criada. Nesta aplicação foi utilizado a ferramente de conectividade, para verificar em cada requisição se o usuário possui internet.

* FFImageLoading - Plugin que auxilia no carregamento de imagens. Ele tem suporte a imagens de erro, cache em memória, suporte qualquer tipo de imagem, mais velocidade no carregamento, entre outras funcionalidades.

* Xamarin.Forms.Extended.InfiniteScrolling - É um plugin para scroll infinito em nosso listview. Foi utilizado no projeto para realizar a paginação das urls retornadas da api. 

## Screenshots


<table>
  <thead>
    <th>SPLASH</th>
    <th>LISTA DE POKEMONS</th>
    <th>DETALHE POKEMON</th>
    <th>GALERIA</th>
  </thead>
  <tbody>
    <tr>
      <td><img src="https://github.com/kainaalmeida/pokeapp/blob/master/Screenshots/splash.png"/></td>
      <td><img src="https://github.com/kainaalmeida/pokeapp/blob/master/Screenshots/pokemons.png"/></td>
      <td><img src="https://github.com/kainaalmeida/pokeapp/blob/master/Screenshots/popup.png"/></td>
      <td><img src="https://github.com/kainaalmeida/pokeapp/blob/master/Screenshots/galeria.png"/></td>
    </tr>
  </tbody>
 </table>
 
 <table>
  <thead>
    <th>SPLASH</th>
    <th>LISTA DE POKEMONS</th>
    <th>DETALHE POKEMON</th>
    <th>GALERIA</th>
  </thead>
  <tbody>
    <tr>
      <td><img src="https://github.com/kainaalmeida/pokeapp/blob/master/Screenshots/splashAndroid.jpg"/></td>
      <td><img src="https://github.com/kainaalmeida/pokeapp/blob/master/Screenshots/pokemonsAndroid.jpg"/></td>
      <td><img src="https://github.com/kainaalmeida/pokeapp/blob/master/Screenshots/popupAndroid.jpg"/></td>
      <td><img src="https://github.com/kainaalmeida/pokeapp/blob/master/Screenshots/galeriaAndroid.jpg"/></td>
    </tr>
  </tbody>
 </table>




