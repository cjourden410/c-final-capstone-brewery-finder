<template>
<div class="base">
  <div class="BeerAdd mx-auto">
    <h1>Add a New Beer</h1>
    <form>
      <div>
        Name of Beer:
        <input type="text" v-model="beer.name" class="beerInput" placeholder="Bob's Beer" />
      </div>
      <div>
        Description of Beer:
        <input type="text" v-model="beer.description" class="beerInput" placeholder="Stuff about your beer" />
      </div>
      <div>
        Type of Beer:
        <input type="text" v-model="beer.beerType" class="beerInput" placeholder="Lager" />
      </div>
       <div>
        ABV of Beer:
        <!-- <input type="text" v-model="beer.abv" class="beerInput" placeholder="9.0" /> -->
        <input type="number" v-model="beer.abv" class="beerInput" placeholder="9.0" step="0.1" min="0" max="99.9"/>
      </div>
      <div>
        Image of your:
        <input type="text" v-model="beer.image" class="beerInput" placeholder="Link to your image" />
      </div>
       <div>
        Your Brewery ID:
        <select @change="getBrewery(chosenId)" v-model="beer.breweryId">
            <option
              v-for="brewery in breweries"
              :key="brewery.id"
              v-bind:value="brewery.id"
            >{{brewery.id}} {{brewery.name}}</option>
          </select>
        <!-- <input type="number" v-model="beer.breweryId" class="beerInput" placeholder="1" min="1"/> -->
      </div>
      <div v-if="selectedBrewery">
      <button v-on:click.prevent="addBeer">Submit</button>
      </div>
    </form>
  </div>
</div>
</template>
<script>
import auth from "@/auth.js";

export default {
  name: "beerAdd",
  props: {},
  data(){
    return{
      breweries: [],
      chosenId: Number,
      selectedBrewery: null,
      beer:{
        beerId: 0,
        name: "",
        description: "",
        beerType: "",
        abv: "",
        breweryId: 0,
        image: ""
      },
      registrationErrors: false
    };
  },
  
  methods:{
    getBrewery(id) {
      let url = `${process.env.VUE_APP_REMOTE_API}/breweries/${id}`;

      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.selectedBrewery = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    },
     GetBreweries() {
      // let url = `${process.env.VUE_APP_REMOTE_API}/breweries`;

      // fetch(url)
      //   .then(response => {
      //     response.json().then(json => {
      //       this.breweries = json;
      //     });
      //   })
      //   .catch(err => {
      //     console.log(err);
      //   });
       if(this.user.rol === 'Admin'){
        let url = `${process.env.VUE_APP_REMOTE_API}/breweries`;

      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.breweries = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    }
    else if (this.user.rol === 'Brewer'){
        let username = this.user.sub;
        let url = `${process.env.VUE_APP_REMOTE_API}/breweries/brewer/${username}`;
        
      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.breweries = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    }
    },
    addBeer(){
          let url = `${process.env.VUE_APP_REMOTE_API}/beers`;

      fetch(url,{
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.beer)
      }).then(response => {
        if(response.ok){
          response.json().then(json => {
            this.beer = json;
            alert(`Beer ${this.beer.name} was added!`)
            this.beer = "";
          });
        }
        else{
          alert(`There was an error: ${response.status}: ${response.statusText}`)
        }
      });
    }
  },
  created(){
    this.user = auth.getUser();
    this.GetBreweries();
  }
};
</script>
<style scoped>
.BeerAdd {
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 1000px;
  min-height: 300px;
}
.base {
  align-items: center;
  width: 100vw;
  height: 100vh;
  background-size: cover;
  overflow: hidden;
  /* position: fixed; */
  top: 1;
  left: 0;
  /* background-attachment: fixed; */
  min-width: 100%;
  min-height: 100%;
  background-image: url("../assets/13.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
@media only screen and (min-width: 1079px) {
  .base {
    position: fixed;
  }
}
.beerInput {
  width: auto;
}
button{
  border: 1px solid black;
  border-radius: 12px;
  margin: 3px;
  background-color: gainsboro;
}
</style>