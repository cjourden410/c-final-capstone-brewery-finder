<template>
<div class="base">
  <div class="beerList">
      <h1>Beer List</h1>
    <!-- <div>Welcome {{user.sub}}, {{user.rol}}</div> -->

      <beer-list :beers="beers" class="beer"></beer-list>
  </div>
</div>
</template>

<script>
import BeerList from "@/components/BeersList.vue";
export default {
name: 'beers',
components:{
  "beer-list": BeerList
},
data() {
  return{
    beers:[]
  }
},
methods: {
  GetBeers(){
    let url =`${process.env.VUE_APP_REMOTE_API}/breweries`;

    fetch(url)
        .then(response => {
          response.json()
            .then(json => {
              this.breweries = json;
            })
        }).catch(err => {
          console.log(err)
        });
  }
},
created(){
  this.GetBeers();
}
}
</script>

<style scoped>
.beerList {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
}
.beer {
  margin: auto;
}
.base{
  width: auto;
  height: 600px;
  background-image: url('../assets/4.jpg');
}
</style>