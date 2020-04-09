<template v-if="user.rol==='Brewer'">
<div class="base">
  <div class="BeerAdd">
    <h1>Add a New Beer</h1>
    <form>
      <div>
        Name of Beer:
        <input type="text" v-model="beer.name" class="beerInput" placeholder="Bob's Beer" />
      </div>
      <div>
        Discription of Beer:
        <input type="text" v-model="beer.description" class="beerInput" placeholder="Stuff about your beer" />
      </div>
      <div>
        Type of Beer:
        <input type="text" v-model="beer.beerType" class="beerInput" placeholder="Lager" />
      </div>
       <div>
        ABV of Beer:
        <input type="text" v-model="beer.abv" class="beerInput" placeholder="9.0" />
      </div>
       <div>
        Your Brewery ID:
        <input type="number" v-model="beer.breweryId" class="beerInput" placeholder="1" />
      </div>
      <button v-on:click="addBeer">Submit</button>
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
  created(){
    this.user = auth.getUser();
  },
  methods:{
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
<style scoped>
.BeerAdd {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
}
.beerInput {
  width: auto;
}
.base{
  width: auto;
  height: 600px;
  background-image: url('../assets/9.jpg');
}
</style>