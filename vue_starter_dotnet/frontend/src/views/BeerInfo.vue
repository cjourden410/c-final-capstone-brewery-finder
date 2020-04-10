<template>
<div class="base">
  <div class="beer">
    <h1>{{beer.name}}</h1>
    <h2>Details</h2>
    
    <table class="form">
      <tr>
        <td>{{beer.description}}</td>
      </tr>
      <tr>
        <td>Beer Type</td>
        <td>{{beer.beerType}}</td>
      </tr>
      <tr>
        <td>Beer ABV</td>
        <td>{{beer.abv}}%</td>
      </tr>
       <tr>
        <td><router-link tag="button" :to="{name: 'ratingsAndReviews', params: {id:beer.id}}">Rate: {{beer.name}}</router-link></td>
      </tr>
      <tr>
        <td><router-link v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')" tag="button" class="navibar" :to="{name: 'deleteBeer'}">Delete Beer</router-link></td>
      </tr>
    </table>
  </div>
</div>
</template>

<script>
import auth from "@/auth.js";

export default {
  name: "beer",
  props:{
    id: Number
  },
data(){
return {
  beer:{
    id: 0,
    name: "",
    discription: "",
    beerType: "",
    abv: "",
  }
}
},
methods:{
getBeer(id){
   let url = `${process.env.VUE_APP_REMOTE_API}/beers/${id}`;
    fetch(url)
    .then(response => {
      response.json()
      .then(json => {
        this.beer = json;
      })
    }).catch(err => {console.log(err)});
}
},
created() {
  this.getBeer(this.$route.params.id);
},
  watch: {
    $route: function() {
      this.user = auth.getUser();
    }
  }
}

</script>

<style scoped>
.beer {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
 padding: 10px;
  padding-bottom: 20px;
  text-align: center;
}
.form{
  margin: auto;
}
.base{
  width: auto;
  height: 600px;
  background-image: url('../assets/5.jpg');
}
</style>