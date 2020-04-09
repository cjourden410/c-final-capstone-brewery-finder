<template>
  <div class="beer">
    <h1>{{beer.name}}</h1>
    <h2>Details</h2>
    <div>Welcome {{user.sub}}, {{user.rol}}</div>

    <table class="form">
      <tr>
        <td>{{beer.description}}</td>
      </tr>
      <tr>
        <td>Beer Type</td>
        <td>{{beer.type}}</td>
      </tr>
      <tr>
        <td>Beer ABV</td>
        <td>{{beer.abv}}</td>
      </tr>
    </table>
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
    name: "",
    discription: "",
    type: "",
    abv: "",
  }
}
},
methods:{
getBeer(id){
   let url = `${process.env.VUE_APP_REMOTE_API}/breweries/${id}`;
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
  this.getBeer(this.$route.parms.id);
}
}

</script>

<style scoped>
.beer {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
}
.form{
  margin: auto;
}
</style>