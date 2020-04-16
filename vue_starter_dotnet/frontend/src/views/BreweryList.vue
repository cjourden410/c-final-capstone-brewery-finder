<template>
  <div class="base">
    <div class="breweryList mx-auto">
    <h1>Brewery List</h1>
    
    <brewery-list :breweries="breweries" class="brewlist"></brewery-list>
  </div>
  </div>
</template>

<script>
import auth from '../auth';
import BreweryList from "@/components/BreweriesList.vue";

export default {
  name: 'breweries',
  components:{
    "brewery-list": BreweryList
  },
  data() {
    return{
      user: null,
      breweries: []
    }
  },
  methods: {
    GetBreweries(){
      let url = `${process.env.VUE_APP_REMOTE_API}/breweries`;
    
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
  created() {
    this.user = auth.getUser();
    this.GetBreweries();
  }
}
</script>

<style scoped>
.breweryList {
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 1000px;
  min-height: 600px;
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
  background-image: url("../assets/9.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
@media only screen and (min-width: 1079px) {
  .base {
    position: fixed;
  }
}
.brewlist{
  margin: auto;
}
</style>