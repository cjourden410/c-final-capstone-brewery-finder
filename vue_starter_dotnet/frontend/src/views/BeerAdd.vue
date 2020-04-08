<template v-if="user.rol==='Brewer'">
  <div class="BeerAdd">
    <h1>Add a New Beer</h1>
    <form>
      <div>
        Name of Beer:
        <input type="text" v-model="beer.name" class="beerInput" placeholder="Bob's Beer" />
      </div>
      <div>
        Discription of Beer:
        <input type="text" v-model="beer.discription" class="beerInput" placeholder="Stuff about your beer" />
      </div>
      <div>
        Type of Beer:
        <input type="text" v-model="beer.type" class="beerInput" placeholder="Lager" />
      </div>
       <div>
        ABV of Beer:
        <input type="text" v-model="beer.abv" class="beerInput" placeholder="9.0" />
      </div>
       <div>
        Your Brewery:
        <input type="text" v-model="beer.brewery" class="beerInput" placeholder="Bob's Brewery" />
      </div>
    </form>
  </div>


<script>
import auth from "@/auth.js";

export default {
  name: "beerAdd",
  props: {},
  data(){
    return{
      beer:{
        name: "",
        discription: "",
        type: "",
        abv: "",
        brewery: ""
      },
      registrationErrors: false
    };
  },
  created(){
    this.user = auth.getUser();
  },
  methods:{
    addBeer(){
          let url = `${process.env.VUE_APP_REMOTE_API}/breweries`;

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
          });
        }
        else{
          alert(`There was an error: ${response.status}: ${response.statusText}`)
        }
      });
    }

  }
};
</script>

<style>

</style>